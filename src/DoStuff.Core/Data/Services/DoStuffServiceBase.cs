using DoStuff.Core.Data.Persistance.Repositories;

using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;

internal class DoStuffServiceBase<TModel> : IDoStuffServiceBase<TModel> where TModel : class
{
    protected readonly IDoStuffRepositoryBase<TModel> _baseRepository;
    protected readonly ICoreScopeProvider _scopeProvider;

    public DoStuffServiceBase(IDoStuffRepositoryBase<TModel> baseRepository, ICoreScopeProvider coreScopeProvider)
    {
        _baseRepository = baseRepository;
        _scopeProvider = coreScopeProvider;
    }

    public virtual async Task<TModel?> GetAsync(int id)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _baseRepository.GetAsync(id);
        }
    }

    public virtual async Task<IEnumerable<TModel>> GetAllAsync(params int[] ids)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _baseRepository.GetAllAsync(ids);
        }
    }

    public virtual async Task<PagedModel<TModel>> GetPagedAsync(int page, int pageSize, params int[] ids)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _baseRepository.GetPagedAsync(page, pageSize, ids);
        }
    }

    public virtual async Task<TModel?> SaveAsync(TModel model)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            return await _baseRepository.SaveAsync(model);
        }
    }

    public virtual async Task DeleteAsync(int id)
    {
        using (_scopeProvider.CreateCoreScope(autoComplete: true))
        {
            await _baseRepository.DeleteAsync(id);
        }
    }
}
