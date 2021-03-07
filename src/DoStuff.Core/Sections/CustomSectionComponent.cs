using System;
using System.Linq;

using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Services;

namespace DoStuff.Core.Sections
{
    public class CustomSectionComponent : IComponent
    {
        private const string SetupKey = "doStuffSection_installed";

        private ILogger<CustomSection> logger;
        private IUserService userService;
        private IKeyValueService keyValueService;

        public CustomSectionComponent(IUserService userService,
            IKeyValueService keyValueService,
            ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<CustomSection>();

            this.userService = userService;
            this.keyValueService = keyValueService;
        }

        public void Initialize()
        {
            // a quick once only run check 
            // for a more complete example look at the migrations sample code.
            var installed = keyValueService.GetValue(SetupKey);
            if (installed == null || installed != "installed")
            {
                AddSection("admin", CustomSection.SectionAlias);
                keyValueService.SetValue(SetupKey, "installed");
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
            logger.LogDebug("Adding {section} to {group}", sectionAlias, groupAlias);

            var group = userService.GetUserGroupByAlias(groupAlias);
            if (group != null)
            {
                if (!group.AllowedSections.Contains(sectionAlias))
                {
                    group.AddAllowedSection(sectionAlias);

                    try
                    {
                        userService.Save(group);
                        logger.LogInformation("Section {section} added to {group} group", sectionAlias, groupAlias);
                    }
                    catch (Exception ex)
                    {
                        logger.LogWarning(ex, "Error adding section {section} to group {group}",
                            sectionAlias, groupAlias);
                    }
                }
            }
        }

        public void Terminate()
        {
            // nothing to clean up
        }
    }
}
