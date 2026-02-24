using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Mapping;

namespace DoStuff.Core.Data.Mapping;

internal static class BuilderMappingExtension
{
    public static IUmbracoBuilder AddDoStuffMappingDefinitions(this IUmbracoBuilder builder)
    {
        builder.WithCollectionBuilder<MapDefinitionCollectionBuilder>()
            .Add<TimeSettingsMappingDefinition>();
        return builder;
    }
}
