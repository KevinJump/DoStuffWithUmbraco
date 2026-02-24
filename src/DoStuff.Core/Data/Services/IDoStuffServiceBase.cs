using Umbraco.Cms.Core.Models;

namespace DoStuff.Core.Data.Services;

public interface IDoStuffServiceBase<TModel> where TModel : class
{
    Task DeleteAsync(int id);
    Task<IEnumerable<TModel>> GetAllAsync(params int[] ids);
    Task<TModel?> GetAsync(int id);
    Task<PagedModel<TModel>> GetPagedAsync(int page, int pageSize, params int[] ids);
    Task<TModel?> SaveAsync(TModel model);
}