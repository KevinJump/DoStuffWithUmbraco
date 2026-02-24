using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistance.Models;

using NPoco;

using Umbraco.Cms.Core.Mapping;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Infrastructure.Scoping;
using Umbraco.Extensions;

namespace DoStuff.Core.Data.Persistance.Repositories;

internal abstract class DoStuffRepositoryBase<TDTOModel, TModel> : IDoStuffRepositoryBase<TModel>
    where TModel : class
{
    const int _maxSqlParamCount = 2000; // Sqlite parameter limit on list parameters.

    protected readonly IScopeAccessor ScopeAccessor;
    protected readonly IUmbracoMapper Mapper;
    protected string Tablename;

    public DoStuffRepositoryBase(IScopeAccessor scopeAccessor, IUmbracoMapper mapper, string tableName)
    {
        ScopeAccessor = scopeAccessor;
        Mapper = mapper;
        Tablename = tableName;
    }

    protected IScope AmbientScope
    {
        get => ScopeAccessor.AmbientScope ??
                throw new InvalidOperationException("No ambient scope found. Ensure that the repository is being used within a scope.");
    }

    protected IUmbracoDatabase Database => AmbientScope.Database;
    protected ISqlContext SqlContext => AmbientScope.SqlContext;
    protected Sql<ISqlContext> Sql => SqlContext.Sql();

    protected virtual Sql<ISqlContext> GetBaseQuery(bool isCount)
        => isCount
            ? Sql.SelectCount().From<TDTOModel>()
            : Sql.Select($"[{Tablename}].*").From<TDTOModel>();

    protected virtual string GetBaseWhereClause()
        => $"WHERE [{Tablename}].Id = @id";

    public async Task<TModel?> GetAsync(int id)
    {
        var sql = GetBaseQuery(false)
            .Where(GetBaseWhereClause(), new { id });

        var dto = await Database.FirstOrDefaultAsync<TDTOModel>(sql);
        if (dto is null) return default;

        return Mapper.Map<TModel>(dto);
    }

    public async Task<IEnumerable<TModel>> GetAllAsync(params int[] ids)
    {
        if (ids.Length == 0) return await DoGetAllAsync();

        int[] uniqueIds = [.. ids.Distinct()];
        if (uniqueIds.Length <= _maxSqlParamCount)
            return await DoGetAllAsync(uniqueIds);

        // if we get here , we have more than 2000 ids in the list, 
        // and for sql we can't just ask for them. 
        // ideally you would want to be using a paged query for this.
        // but if you just want to get everything, group them
        // in to batches.

        List<TModel> results = [];

        foreach (var batch in uniqueIds.InGroupsOf(_maxSqlParamCount))
        {
            var batchArray = batch.ToArray();
            results.AddRange(await DoGetAllAsync(batchArray));
        }

        return results;


    }

    protected async Task<IEnumerable<TModel>> DoGetAllAsync(params int[] ids)
    {
        var sql = GetBaseQuery(false);

        if (ids.Length == 0)
        {
            sql.Where($"[{Tablename}].Id > 0");
        }
        else
        {
            sql.Where($"[{Tablename}].Id IN (@ids)", new { ids });
        }

        var results = await Database.FetchAsync<TDTOModel>(sql);
        return Mapper.Map<IEnumerable<TModel>>(results) ?? [];
    }

    public async Task<PagedModel<TModel>> GetPagedAsync(int pageIndex, int pageSize, params int[] ids)
    {
        ids = ids.Distinct().ToArray();

        // if we've asked for thousands of items, and we are on a page where we would
        // need to get them, you would have to be doing something clever to get them
        // for the basic example we are going to throw
        // (in practice this would be page 200+ on a with a page size of 10 - and 
        // ONLY when the ids have been passed, if you are just paging evertthing this
        // isn't a problem.
        if (ids.Length > _maxSqlParamCount && pageSize * pageIndex > _maxSqlParamCount)
            throw new IndexOutOfRangeException($"Cannot page when more than {_maxSqlParamCount} ids are passed and the page index is such that it would require fetching more than {_maxSqlParamCount} items.");

        var sql = GetBaseQuery(false);

        if (ids.Length > 0)
            sql.Where($"[{Tablename}].Id IN (@ids)", new { ids });

        sql.OrderBy($"[{Tablename}].Id");

        var results = await Database.PageAsync<TDTOModel>(pageIndex, pageSize, sql);

        if (ids.Length > _maxSqlParamCount)
        {
            // again if we are past _maxSqlParamCount
            // the returned size and page count will be wrong, so we can 'fix' it here.
            // its not "real" however as we will still throw if people go past the limit.
            results.TotalItems = ids.Length;
            results.TotalPages = (long)Math.Ceiling((double)ids.Length / pageSize);
        }

        return new PagedModel<TModel>(results.TotalItems, Mapper.Map<IEnumerable<TModel>>(results.Items) ?? []);
    }

    public PagedModel<TModel> GetPagedAsync(int pageIndex, int pageSize, Sql<ISqlContext> sql)
    {
        var results = Database.Page<TDTOModel>(pageIndex, pageSize, sql);
        return new PagedModel<TModel>(results.TotalItems, Mapper.Map<IEnumerable<TModel>>(results.Items) ?? []);
    }

    public virtual async Task<TModel?> SaveAsync(TModel model)
    {
        var dto = Mapper.Map<TDTOModel>(model);
        if (dto is null)
            throw new InvalidOperationException("Cannot map model to DTO.");

        using (var transaction = Database.GetTransaction())
        {
            await Database.SaveAsync(dto);
            transaction.Complete();
        }

        return Mapper.Map<TModel>(dto);
    }

    public virtual async Task DeleteAsync(int id)
    {
        using (var transaction = Database.GetTransaction())
        {
            await Database.DeleteAsync(id);
            transaction.Complete();
        }
    }
}
