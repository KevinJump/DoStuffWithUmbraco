using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Startup;

public class DoStuffCoreComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddDoStuffCore();
    }
}
