using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core.Sections
{
    public class CustomSectionComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.Sections().Append<CustomSection>();

            builder.Components().Append<CustomSectionComponent>();
        }
    }
}
