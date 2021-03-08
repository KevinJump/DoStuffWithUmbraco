using System;
using System.Linq;

using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;

namespace DoStuff.Core.Sections
{
    public class CustomSectionAppStartingHandler : INotificationHandler<UmbracoApplicationStarting>
    {
        private const string SetupKey = "doStuffSection_installed";

        private readonly ILogger<CustomSectionAppStartingHandler> logger;
        private readonly IUserService userService;
        private readonly IKeyValueService keyValueService;

        public CustomSectionAppStartingHandler(
            ILogger<CustomSectionAppStartingHandler> logger,
            IKeyValueService keyValueService,
            IUserService userService
            )
        {
            this.logger = logger;
            this.keyValueService = keyValueService;
            this.userService = userService;
        }

        public void Handle(UmbracoApplicationStarting notification)
        {
            if (notification.RuntimeLevel >= Umbraco.Cms.Core.RuntimeLevel.Run)
            {
                var installed = keyValueService.GetValue(SetupKey);
                if (installed != null && installed != "installed")
                {
                    AddSection(Constants.Security.AdminGroupAlias, CustomSection.SectionAlias);
                    keyValueService.SetValue(SetupKey, "installed");
                }
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


    }
}
