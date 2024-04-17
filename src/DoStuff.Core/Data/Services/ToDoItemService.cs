using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Persistence;

using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Scoping;

namespace DoStuff.Core.Data.Services;
internal class ToDoItemService : DoStuffServiceBase<ToDoItem>, IToDoItemService
{
	// the todo item repo (with extra methods on base)
	private readonly IToDoItemRepository _repository;

	public ToDoItemService(
		IProfilingLogger logger,
		IToDoItemRepository repository,
		ICoreScopeProvider scopeProvider)
		: base(logger, repository, scopeProvider)
	{
		_repository = repository;
	}

	public IEnumerable<ToDoItem> GetItemsInList(Guid key)
	{
		using (_scopeProvider.CreateCoreScope(autoComplete: true))
		{
			return _repository.GetItemsInList(key);
		}
	}
}
