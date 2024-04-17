using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;

namespace DoStuff.Core.Data.Mapping;
internal static class MappingBuilderExtension
{
	/// <summary>
	///  builder extension so we can add to site.
	/// </summary>
	/// <remarks>
	///  added to either another extension or a composer
	///  <code>
	///		builder.AddToDoListMappings();
	///  </code>
	/// </remarks>
	public static IUmbracoBuilder AddToDoListMappingDefinitions(this IUmbracoBuilder builder)
	{
		builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
			.Add<ToDoListMappingDefinitionss>()
			.Add<ToDoItemMappingDefinitions>();

		return builder;

	}
}
