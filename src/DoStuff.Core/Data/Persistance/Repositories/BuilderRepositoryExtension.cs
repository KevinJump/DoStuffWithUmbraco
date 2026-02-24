using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data.Persistance.Repositories;

internal static class BuilderRepositoryExtension
{
    public static IUmbracoBuilder AddDoStuffRepositories(this IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<ITimeSettingsRepository, TimeSettingsRepository>();
        return builder;
    }
}
