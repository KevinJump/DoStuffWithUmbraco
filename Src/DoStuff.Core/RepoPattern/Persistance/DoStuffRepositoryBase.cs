using NPoco;

using System;
using System.Collections.Generic;
using System.Linq;

using Umbraco.Core;
using Umbraco.Core.Logging;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.SqlSyntax;
using Umbraco.Core.Scoping;

namespace DoStuff.Core.RepoPattern.Persistance
{
    public abstract class DoStuffRepositoryBase<TModel> : IDoStuffRepository<TModel> where TModel : class
    {
        const int maxParams = 2000; // SqlCE limit on SELECT IN Statements

        protected readonly IScopeAccessor scopeAccessor;
        protected readonly IProfilingLogger logger;
        protected string tableName;

        protected DoStuffRepositoryBase(
            IScopeAccessor scopeAccessor,
            IProfilingLogger logger)
        {
            this.scopeAccessor = scopeAccessor;
            this.logger = logger;
        }

        protected IScope AmbientScope
        {
            get
            {
                var scope = scopeAccessor.AmbientScope;
                if (scope == null)
                    throw new InvalidOperationException("Cannot run repository without an ambient scope");

                return scope;
            }
        }

        protected IUmbracoDatabase Database => AmbientScope.Database;
        protected ISqlContext SqlContext => AmbientScope.SqlContext;
        protected Sql<ISqlContext> Sql() => SqlContext.Sql();
        protected ISqlSyntaxProvider SqlSyntax => SqlContext.SqlSyntax;


        protected virtual Sql<ISqlContext> GetBaseQuery(bool isCount)
        {
            return isCount
                ? Sql().SelectCount().From<TModel>()
                : Sql().Select($"{tableName}.*").From<TModel>();
        }

        protected virtual string GetBaseWhereClause()
            => $"{tableName}.Id = @Id";

        #region Gettters

        public virtual TModel Get(int id)
        {
            var sql = GetBaseQuery(false)
                    .Where(GetBaseWhereClause(), new { Id = id });

            var dto = Database.FirstOrDefault<TModel>(sql);
            if (dto == null) return default(TModel);

            return dto;
        }

        public virtual IEnumerable<TModel> GetAll(params int[] ids)
        {
            if (ids.Length == 0) return DoGetAll();

            var uniqueIds = ids.Distinct().ToArray();


            if (ids.Length <= maxParams)
            {
                return DoGetAll(uniqueIds);
            }

            // if we have more than maxParams of ids, we can't just 
            // do where Id in (id list) because it will break (SQLCE)
            // so we split into groups of maxParam, and run multiple
            // queries

            List<TModel> results = new List<TModel>();
            foreach (var groupOfIds in uniqueIds.InGroupsOf(maxParams))
            {
                results.AddRange(DoGetAll(groupOfIds.ToArray()));
            }

            return results;
        }

        /// <summary>
        ///  do the actual get, once the main function has tidied up
        ///  our ids, and split into groups if needed
        /// </summary>
        private IEnumerable<TModel> DoGetAll(params int[] ids)
        {
            var sql = GetBaseQuery(false);
            if (ids.Length > 0)
            {
                sql.Where($"{tableName}.Id in (@Ids)", new { Ids = ids });
            }
            else
            {
                sql.Where($"{tableName}.Id > 0");
            }

            return Database.Fetch<TModel>(sql);
        }

        public PagedResult<TModel> GetAllPaged(int page, int pageSize, params int[] ids)
        {
            ids = ids.Distinct().ToArray();

            if (ids.Length > maxParams && page * pageSize > maxParams)
            {
                // we are asking for things beyond the max params limit 
                // for simplicity of sample, we are just throwing 
                throw new IndexOutOfRangeException("to many results");
            }

            var sql = GetBaseQuery(false);

            if (ids.Length > 0)
                sql.Where($"{tableName}.id in (@Ids)", new { Ids = ids.Take(maxParams) });

            // if you are going to page, you need to order by something
            sql.OrderBy($"{tableName}.id");

            var results = Database.Page<TModel>(page, pageSize, sql);

            if (ids.Length > maxParams)
            {
                // again if there are more than max params, guess 
                results.TotalItems = ids.Length;
                results.TotalPages = (long)Math.Ceiling((decimal)ids.Length / pageSize);
            }


            return new PagedResult<TModel>(results.TotalItems, results.CurrentPage, results.ItemsPerPage)
            {
                Items = results.Items
            };
        }

        public PagedResult<TModel> GetPaged(int page, int pageSize, Sql<ISqlContext> sql)
        {
            var results = Database.Page<TModel>(page, pageSize, sql);

            return new PagedResult<TModel>(results.TotalItems, results.CurrentPage, results.ItemsPerPage)
            {
                Items = results.Items
            };
        }

        #endregion

        #region Saving 

        public virtual TModel Save(TModel item)
        {
            var dto = item; // if we where mapping, we would do that.

            using (var transaction = Database.GetTransaction())
            {
                Database.Save(dto);
                transaction.Complete();
            }

            return dto;
        }

        #endregion

        #region Deleting 

        public virtual void Delete(int id)
        {
            using (var transaction = Database.GetTransaction())
            {
                Database.Delete<TModel>(id);
                transaction.Complete();
            }
        }

        #endregion


        public virtual int Count()
        {
            var sql = GetBaseQuery(true);
            return Database.ExecuteScalar<int>(sql);
        }
    }
}
