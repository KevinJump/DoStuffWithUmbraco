using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace DoStuff.Core.Data.Persistance.Migrations;

internal static class BuilderMigrationPlanExtensions
{
    public static IUmbracoBuilder AddDoStuffMigrationPlan(this IUmbracoBuilder builder)
    {
        builder.AddNotificationAsyncHandler<UmbracoApplicationStartingNotification, MigrationApplicationStartingHandler>();
        return builder;
    }
}

internal class MigrationApplicationStartingHandler :
    INotificationAsyncHandler<UmbracoApplicationStartingNotification>
{
    private readonly ICoreScopeProvider _scopeProvider;
    private readonly IKeyValueService _keyValueService;
    private readonly IRuntimeState _runtimeState;
    private readonly IMigrationPlanExecutor _migrationPlanExecutor;

    public MigrationApplicationStartingHandler(
        ICoreScopeProvider scopeProvider,
        IKeyValueService keyValueService,
        IRuntimeState runtimeState,
        IMigrationPlanExecutor migrationPlanExecutor)
    {
        _scopeProvider = scopeProvider;
        _keyValueService = keyValueService;
        _runtimeState = runtimeState;
        _migrationPlanExecutor = migrationPlanExecutor;
    }

    public async Task HandleAsync(UmbracoApplicationStartingNotification notification, CancellationToken cancellationToken)
    {
        // we don't run our migration until the site has been installed / isn't upgrading.
        if (_runtimeState.Level < RuntimeLevel.Run) return;

        var upgrader = new Upgrader(new DoStuffMigrationPlan());
        await upgrader.ExecuteAsync(_migrationPlanExecutor, _scopeProvider, _keyValueService);

    }
}

