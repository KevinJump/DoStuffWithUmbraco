using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.Sections;

namespace DoStuff.Core.Sections
{
    /// <summary>
    ///  Custom Section Interface, see CustomSectionComposer for how
    ///  this is registered in umbraco, CustomSectionComponent ads the 
    ///  section to the admin group so it appears by default.
    /// </summary>
    public class CustomSection : ISection
    {
        /// <summary>
        ///  Alias for the section
        /// </summary>
        /// <remarks>
        ///  It makes sense to make this a constant (you don't have to)
        ///  because you end up refrencing it in things like tree's and 
        ///  dashboards.
        /// </remarks>
        public const string SectionAlias = "doStuffSection";

        #region ISection Interface 

        /// <summary>
        ///  Alias of section, used in urls, trees etc
        /// </summary>
        public string Alias => SectionAlias;

        /// <summary>
        ///  name of the section - this isn't what the user sees
        ///  they see a value from the lang file
        /// </summary>
        public string Name => "Do Stuff Section";

        #endregion
    }
}
