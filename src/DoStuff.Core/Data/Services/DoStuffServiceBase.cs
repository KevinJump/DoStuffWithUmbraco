using DoStuff.Core.Data.Persistence;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;

/// <summary>
///  base class with the basic crud operations
/// </summary>
/// <remarks>
///  Having a base class just means we don't need to do all the crud 
///  operations every time we want to create a new service. 
/// </remarks>
internal class DoStuffServiceBase<TModel> : IDoStuffServiceBase<TModel>
	where TModel : class
{
	protected readonly IProfilingLogger _logger;
	protected readonly IDoStuffRepositoryBase<TModel> _baseRepository;

	protected ICoreScopeProvider _scopeProvider;

	public DoStuffServiceBase(
		IProfilingLogger logger,
		IDoStuffRepositoryBase<TModel> baseRepository,
		ICoreScopeProvider scopeProvider)
	{
		_logger = logger;
		_baseRepository = baseRepository;
		_scopeProvider = scopeProvider;
	}

	public virtual TModel? Get(int id)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _baseRepository.Get(id);
		}
	}

	public virtual IEnumerable<TModel> GetAll(params int[] ids)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _baseRepository.GetAll(ids);
		}
	}

	public virtual PagedModel<TModel> GetAllPaged(int page, int pageSize, params int[] ids)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _baseRepository.GetAllPaged(page, pageSize, ids);
		}
	}

	public virtual TModel? Save(TModel item)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _baseRepository.Save(item);
		}
	}

	public virtual void Delete(int id)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			_baseRepository.Delete(id);
		}
	}

	public int Count()
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _baseRepository.Count();
		}
	}

}
