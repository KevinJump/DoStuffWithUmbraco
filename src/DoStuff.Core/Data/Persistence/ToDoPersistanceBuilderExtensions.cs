using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data.Persistence;
internal static class ToDoPersistenceBuilderExtensions
{
	public static IUmbracoBuilder AddToDoPersistance(this IUmbracoBuilder builder)
	{
		// add the repositories 
		builder.Services.AddSingleton<IToDoListRepository, ToDoListRepository>();
		builder.Services.AddSingleton<IToDoItemRepository, ToDoItemRepository>();

		// return 
		return builder;
	}
}
