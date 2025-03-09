using DoStuff.Client.Composers;
using DoStuff.Client.DependencyInjection;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Client;
public class DoStuffClientComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddDoStuffClientApi();
        builder.AddDoStuffManifestReader();
    }
}
