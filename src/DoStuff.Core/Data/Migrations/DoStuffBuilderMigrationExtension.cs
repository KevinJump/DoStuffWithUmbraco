using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Migrations;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace DoStuff.Core.Data.Migrations;

//
// Run a 'Core' migration, just like Umbraco does. 
// 
// It can be simpler and cleaner to use PackageMigrations, 
// but if you need full control over how the migration runs
// and when etc, then the core migrations offer more flexibility.
//

/// <summary>
///  extension so we can add the migrations to umbraco in a composer.
/// </summary>
internal static class DoStuffBuilderMigrationExtension
{
	public static IUmbracoBuilder AddDoStuffMigrations(this IUmbracoBuilder builder)
	{
		builder.AddNotificationHandler<
			UmbracoApplicationStartingNotification,
			DoStuffMigrationsApplicationStartingHandler>();

		return builder;
	}
}

/// <summary>
///  migrations run in a notification, then you can tell if 
///  umbraco is installed before you start.
/// </summary>
public class DoStuffMigrationsApplicationStartingHandler :
	INotificationHandler<UmbracoApplicationStartingNotification>
{
	private readonly ICoreScopeProvider _scopeProvider;
	private readonly IKeyValueService _keyValueService;
	private readonly IMigrationPlanExecutor _migrationPlanExecutor;

	public DoStuffMigrationsApplicationStartingHandler(
		ICoreScopeProvider scopeProvider,
		IKeyValueService keyValueService,
		IMigrationPlanExecutor migrationPlanExecutor)
	{
		_scopeProvider = scopeProvider;
		_keyValueService = keyValueService;
		_migrationPlanExecutor = migrationPlanExecutor;
	}

	public void Handle(UmbracoApplicationStartingNotification notification)
	{
		// only run our notification if Umbraco is installed / not upgrading.
		if (notification.RuntimeLevel != Umbraco.Cms.Core.RuntimeLevel.Run)
			return;

		// run the migration plan via the Umbraco upgrader.
		var upgrader = new Upgrader(new DoStuffMigrationPlan());
		upgrader.Execute(_migrationPlanExecutor, _scopeProvider, _keyValueService);
	}
}
