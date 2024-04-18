using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Api.ToDo.List;

[ApiVersion("1.0")]
public class ToDoListSaveController : ToDoListControllerBase
{
	public ToDoListSaveController(IToDoListService listService) 
		: base(listService)
	{
	}

	[HttpPost("Save")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<ToDoList>(StatusCodes.Status200OK)]
	public ToDoList? Save(ToDoList list)
		=> _listService.Save(list);
}
