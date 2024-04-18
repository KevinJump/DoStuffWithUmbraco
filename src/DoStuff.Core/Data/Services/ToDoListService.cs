using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;

/// <summary>
///  to do list service, 
/// </summary>
internal class ToDoListService : DoStuffServiceBase<ToDoList>,
	IToDoListService
{
	private readonly IToDoListRepository _repository;

	public ToDoListService(
		IProfilingLogger logger,
		IToDoListRepository baseRepository,
		ICoreScopeProvider scopeProvider)
		: base(logger, baseRepository, scopeProvider)
	{
		_repository = baseRepository;
	}

	public IEnumerable<ToDoList> GetByNode(Guid nodeKey)
	{
		using(var scope = _scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _repository.GetByNode(nodeKey);
		}
	}
}
