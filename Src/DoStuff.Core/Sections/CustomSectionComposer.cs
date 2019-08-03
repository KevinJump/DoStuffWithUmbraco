using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;

namespace DoStuff.Core.Sections
{
    public class CustomSectionComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // register the section 
            composition.Sections().Append<CustomSection>();

            // register the component that adds the section
            // to the admin group 
            composition.Components().Append<CustomSectionComponent>();
        }
    }
}
