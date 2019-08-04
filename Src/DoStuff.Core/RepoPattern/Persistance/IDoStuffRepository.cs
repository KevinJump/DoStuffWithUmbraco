using System.Collections.Generic;
using NPoco;
using Umbraco.Core.Models;
using Umbraco.Core.Persistence;

namespace DoStuff.Core.RepoPattern.Persistance
{
    public interface IDoStuffRepository<TModel> where TModel : class
    {
        int Count();
        void Delete(int id);
        TModel Get(int id);
        IEnumerable<TModel> GetAll(params int[] ids);
        PagedResult<TModel> GetAllPaged(int page, int pageSize, params int[] ids);
        PagedResult<TModel> GetPaged(int page, int pageSize, Sql<ISqlContext> sql);
        TModel Save(TModel item);
    }
}