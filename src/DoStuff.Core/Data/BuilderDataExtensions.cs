using DoStuff.Core.Data.Persistance;
using DoStuff.Core.Data.Services;

using System;
using System.Collections.Generic;
using System.Text;

using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Data;

internal static class BuilderDataExtensions
{
    public static IUmbracoBuilder AddDoStuffDataLayer(this IUmbracoBuilder builder)
    {
        builder
            .AddDoStuffPersistance()
            .AddDoStuffServices();

        return builder;
    }
}
