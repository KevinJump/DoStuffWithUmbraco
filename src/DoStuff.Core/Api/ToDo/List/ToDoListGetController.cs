using Asp.Versioning;

using DoStuff.Core.Data.Models;
using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Core.Models;

namespace DoStuff.Core.Api.ToDo.List;

/// <summary>
///  Get methods for a todo list. 
/// </summary>
public class ToDoListGetController : ToDoListControllerBase
{
	public ToDoListGetController(IToDoListService listService)
		: base(listService)
	{}

	[HttpGet("Get")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<ToDoList>(StatusCodes.Status200OK)]
	public ToDoList? Get(int id)
		=> _listService.Get(id);

	[HttpGet("List")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<IEnumerable<ToDoList>>(StatusCodes.Status200OK)]
	public IEnumerable<ToDoList> List()
		=> _listService.GetAll();

	[HttpGet("GetPaged")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<PagedModel<ToDoList>>(StatusCodes.Status200OK)]
	public PagedModel<ToDoList> GetPaged(int page)
		=> _listService.GetAllPaged(page, 20);

	[HttpGet("Count")]
	[MapToApiVersion("1.0")]
	[ProducesResponseType<int>(StatusCodes.Status200OK)]
	public int Count() 
		=> _listService.Count();

}
