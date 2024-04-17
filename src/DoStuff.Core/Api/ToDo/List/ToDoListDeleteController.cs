using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Api.ToDo.List;
public class ToDoListDeleteController : ToDoListControllerBase
{
	public ToDoListDeleteController(IToDoListService listService)
		: base(listService)
	{
	}

	[HttpDelete("Delete")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<IEnumerable<ToDoList>>(StatusCodes.Status200OK)]
	public void Delete(int id)
		=> _listService.Delete(id);
}
