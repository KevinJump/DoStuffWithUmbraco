using NPoco;

using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Infrastructure.Persistence;

namespace DoStuff.Core.Data.Persistance.Repositories;

public interface IDoStuffRepositoryBase<TModel> where TModel : class
{
    Task DeleteAsync(int id);
    Task<IEnumerable<TModel>> GetAllAsync(params int[] ids);
    Task<TModel?> GetAsync(int id);
    Task<PagedModel<TModel>> GetPagedAsync(int pageIndex, int pageSize, params int[] ids);
    PagedModel<TModel> GetPagedAsync(int pageIndex, int pageSize, Sql<ISqlContext> sql);
    Task<TModel?> SaveAsync(TModel model);
}