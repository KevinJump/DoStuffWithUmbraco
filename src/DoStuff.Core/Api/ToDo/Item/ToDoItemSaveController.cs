using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Api.ToDo.Item;
[ApiVersion("1.0")]
public class ToDoItemSaveController : ToDoItemControllerBase
{
	public ToDoItemSaveController(IToDoItemService itemService)
		: base(itemService)
	{ }

	[HttpPost("Save")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<ToDoItem>(StatusCodes.Status200OK)]
	public ToDoItem? Save(ToDoItem item)
		=> _itemService.Save(item);

}
