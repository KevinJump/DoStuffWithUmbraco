using DoStuff.Core.Data.Mapping;
using DoStuff.Core.Data.Migrations;
using DoStuff.Core.Data.Persistence;
using DoStuff.Core.Data.Services;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data;
internal static class ToDoDataBuilderExtensions
{
	public static IUmbracoBuilder AddDoStuffDataLayer(this IUmbracoBuilder builder)
	{
		// migrations to create the database tables
		builder.AddDoStuffMigrations();

		// map definitions from dto to models. 
		builder.AddToDoListMappingDefinitions();

		// add the repositories.
		builder.AddToDoPersistance();

		// add the services
		builder.AddToDoServices();

		return builder;
	}
}
