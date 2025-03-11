using DoStuff.Client.Composers;
using DoStuff.Core;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff;

public class DoStuffComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddDoStuffCore();
        builder.AddDoStuffClient();
    }
}