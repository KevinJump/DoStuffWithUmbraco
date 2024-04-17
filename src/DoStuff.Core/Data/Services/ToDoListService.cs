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
	public ToDoListService(
		IProfilingLogger logger,
		IToDoListRepository baseRepository,
		ICoreScopeProvider scopeProvider)
		: base(logger, baseRepository, scopeProvider)
	{
	}
}
