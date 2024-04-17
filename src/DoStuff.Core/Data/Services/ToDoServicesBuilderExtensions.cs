using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data.Services;
internal static class ToDoServicesBuilderExtensions
{
	public static IUmbracoBuilder AddToDoServices(this IUmbracoBuilder builder)
	{
		builder.Services.AddSingleton<IToDoListService, ToDoListService>();
		builder.Services.AddSingleton<IToDoItemService, ToDoItemService>();

		return builder;
	}
}
