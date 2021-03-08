using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;

namespace DoStuff.Core.Sections
{
    public class CustomSectionComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Sections().Append<CustomSection>();

            builder.AddNotificationHandler<UmbracoApplicationStarting, CustomSectionAppStartingHandler>();
        }
    }
}
