using DoStuff.Core;


using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace DoStuff.Client.Composers;

/// <summary>
///  Startup Handler to add the DoStuff section to the admin group of the site.
/// </summary>
/// <remarks>
///  You could run this as a migration, we've done it here as a startup handler, to show how that works.
///  and because we didn't want to have more migration code in the client library, when the bulk of that
///  example lives in the core. 
/// </remarks>
internal class ApplicationStartedAddSectionHandler : INotificationAsyncHandler<UmbracoApplicationStartedNotification>
{
    private readonly IUserGroupService _userGroupService;
    private readonly IKeyValueService _keyValueService;

    public ApplicationStartedAddSectionHandler(IUserGroupService userGroupService, IKeyValueService keyValueService)
    {
        _userGroupService = userGroupService;
        _keyValueService = keyValueService;
    }

    public async Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
    {
        // using the key value service as a store of whether we've already run this code or not,
        // to avoid doing it more than once, which would be a problem as we're updating the admin group,
        // and we don't want to do that more than once.
        var hasRun = _keyValueService.GetValue($"{DoStuffConstants.SectionAlias}-Setup");
        if (hasRun is not null && hasRun == "true") return;

        // find the admin group
        var adminGroup = await _userGroupService.GetAsync(Umbraco.Cms.Core.Constants.Security.AdminGroupKey);
        if (adminGroup is null) return;

        // add the section to the admin group if it doesn't already have it.
        if (adminGroup.AllowedSections.Contains(DoStuffConstants.SectionAlias) is false)
        {
            adminGroup.AddAllowedSection(DoStuffConstants.SectionAlias);
            await _userGroupService.UpdateAsync(adminGroup, Umbraco.Cms.Core.Constants.Security.SuperUserKey);
        }

        // set the key value to say we've done it. 
        _keyValueService.SetValue($"{DoStuffConstants.SectionAlias}-Setup", "true");
    }
}
