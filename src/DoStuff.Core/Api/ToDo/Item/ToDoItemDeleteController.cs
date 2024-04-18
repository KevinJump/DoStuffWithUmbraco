using Asp.Versioning;

using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace DoStuff.Core.Api.ToDo.Item;

[ApiVersion("1.0")]
public class ToDoItemDeleteController : ToDoItemControllerBase
{
	public ToDoItemDeleteController(IToDoItemService itemService) 
		: base(itemService)
	{ }


	[HttpDelete("Delete")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	public void Delete(int id)
		=> _itemService.Delete(id);
}
