using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Api.ToDo.List;

[ApiExplorerSettings(GroupName = "ToDoList")]
public class ToDoListControllerBase : ToDoControllerBase
{
	protected readonly IToDoListService _listService;

	public ToDoListControllerBase(IToDoListService listService)
	{
		_listService = listService;
	}
}
