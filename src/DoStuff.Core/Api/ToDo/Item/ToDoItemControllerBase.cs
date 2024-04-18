using Asp.Versioning;

using DoStuff.Core.Data.Services;

using Microsoft.AspNetCore.Mvc;

using Umbraco.Cms.Web.Common.Routing;

namespace DoStuff.Core.Api.ToDo.Item;

[ApiExplorerSettings(GroupName = "ToDo Items")]
[BackOfficeRoute("DoStuff/Api/v{version:apiVersion}/ToDo/Item")]
public class ToDoItemControllerBase : ToDoControllerBase
{
	protected readonly IToDoItemService _itemService;

	public ToDoItemControllerBase(IToDoItemService itemService)
	{
		_itemService = itemService;
	}
}
