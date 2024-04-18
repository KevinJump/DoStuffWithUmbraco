using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Core.Models;

namespace DoStuff.Core.Api.ToDo.Item;

[ApiVersion("1.0")]
public class ToDoItemGetController : ToDoItemControllerBase
{
	public ToDoItemGetController(IToDoItemService itemService)
		: base(itemService)
	{
	}

	[HttpGet("Get")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<ToDoItem>(StatusCodes.Status200OK)]
	public ToDoItem? Get(int id)
		=> _itemService.Get(id);

	[HttpGet("List")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<IEnumerable<ToDoItem>>(StatusCodes.Status200OK)]
	public IEnumerable<ToDoItem> List()
		=> _itemService.GetAll();

	[HttpGet("Items")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<IEnumerable<ToDoItem>>(StatusCodes.Status200OK)]
	public IEnumerable<ToDoItem> GetForList(Guid listKey)
		=> _itemService.GetItemsInList(listKey);

	[HttpGet("GetPaged")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<PagedModel<ToDoItem>>(StatusCodes.Status200OK)]
	public PagedModel<ToDoItem> GetPaged(int page)
		=> _itemService.GetAllPaged(page, 20);

	[HttpGet("Count")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<int>(StatusCodes.Status200OK)]
	public int Count()
		=> _itemService.Count();
}
