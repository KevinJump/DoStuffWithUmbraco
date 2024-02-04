using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core;
public class DoStuffComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddDoStuff();
    }
}

