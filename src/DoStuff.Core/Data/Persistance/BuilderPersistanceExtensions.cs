using DoStuff.Core.Data.Mapping;
using DoStuff.Core.Data.Persistance.Migrations;
using DoStuff.Core.Data.Persistance.Repositories;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data.Persistance;

internal static class BuilderPersistanceExtensions
{
    public static IUmbracoBuilder AddDoStuffPersistance(this IUmbracoBuilder builder)
    {
        builder
            .AddDoStuffMigrationPlan()
            .AddDoStuffRepositories()
            .AddDoStuffMappingDefinitions();

        return builder;
    }
}
