using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Services;

namespace DoStuff.Core.Sections
{
    /// <summary>
    ///  Umbraco Component (runs at startup) 
    /// </summary>
    /// <remarks>This doesn't run unless it's registered in the Composer</remarks>
    public class CustomSectionComponent : IComponent
    {
        private readonly IUserService userService;
        private readonly IKeyValueService keyValueService;
        private readonly IProfilingLogger logger;

        private const string setupKey = "doStuffSection_installed";

        public CustomSectionComponent(
            IUserService userService, 
            IKeyValueService keyValueService,
            IProfilingLogger  logger)
        {
            this.userService = userService;
            this.keyValueService = keyValueService;
            this.logger = logger;
        }


        public void Initialize()
        {
            // a quick version of only run once. 
            // for a more complete set of methods see Migrations samples
            var installed = keyValueService.GetValue(setupKey);
            if (installed == null || installed != "installed")
            {
                AddSection("admin", CustomSection.SectionAlias);
                keyValueService.SetValue(setupKey, "installed");
            }
        }

        /// <summary>
        ///  add the given section to the given user group 
        /// </summary>
        /// <remarks>
        ///  if umbraco throws an exception here, we capture it
        ///  because if we don't umbraco won't startup and that
        ///  might be a bad thing :( 
        /// </remarks>
        /// <param name="groupAlias"></param>
        /// <param name="sectionAlias"></param>
        private void AddSection(string groupAlias, string sectionAlias)
        {
            using (logger.DebugDuration<CustomSectionComponent>($"Adding Section {sectionAlias} to {groupAlias}"))
            {
                var group = userService.GetUserGroupByAlias(groupAlias);
                if (group != null)
                {
                    if (!group.AllowedSections.Contains(sectionAlias))
                    {
                        group.AddAllowedSection(sectionAlias);

                        try
                        {
                            userService.Save(group);
                            logger.Info<CustomSectionComponent>($"Section {sectionAlias} added to {groupAlias} group");
                        }
                        catch (Exception ex)
                        {
                            logger.Warn<CustomSectionComponent>("Error adding section {0} to group {1} [{2}]",
                                sectionAlias, groupAlias, ex.Message);
                        }
                    }
                }
            }
        }

        public void Terminate()
        {
            // umbraco is shutting down -
        }
    }
}
