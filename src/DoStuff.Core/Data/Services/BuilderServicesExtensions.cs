using Microsoft.Extensions.DependencyInjection;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data.Services;

internal static class BuilderServicesExtensions
{
    public static IUmbracoBuilder AddDoStuffServices(this IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<ITimeService, TimeService>();
        builder.Services.AddSingleton<ITimeSettingsService, TimeSettingsService>();
        return builder;
    }
}
