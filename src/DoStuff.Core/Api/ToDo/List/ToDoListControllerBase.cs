using Asp.Versioning;

using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Web.Common.Routing;

namespace DoStuff.Core.Api.ToDo.List;

[ApiExplorerSettings(GroupName = "ToDo Lists")]
[BackOfficeRoute("DoStuff/Api/v{version:apiVersion}/ToDo/List")]
public class ToDoListControllerBase : ToDoControllerBase
{
	protected readonly IToDoListService _listService;

	public ToDoListControllerBase(IToDoListService listService)
	{
		_listService = listService;
	}
}
