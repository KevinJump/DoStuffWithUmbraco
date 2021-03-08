
using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  Register an event handler, so we can do stuff when the site starts.
    /// </summary>
    public class MigrationComponentComposer : IUserComposer
    {
        public void Compose(IUmbracoBuilder builder)
        {
            builder.AddNotificationHandler<UmbracoApplicationStarting, MigrationAppStartingHandler>();
        }
    }

    public class MigrationAppStartingHandler : INotificationHandler<UmbracoApplicationStarting>
    {
        private readonly IScopeProvider scopeProvider;
        private readonly IMigrationBuilder migrationBuilder;
        private readonly IKeyValueService keyValueService;

        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<Upgrader> logger;

        public MigrationAppStartingHandler(
            IScopeProvider scopeProvider,
            IMigrationBuilder migrationBuilder,
            IKeyValueService keyValueService,
            ILoggerFactory loggerFactory)
        {
            this.scopeProvider = scopeProvider;
            this.migrationBuilder = migrationBuilder;
            this.keyValueService = keyValueService;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<Upgrader>();
        }

        public void Handle(UmbracoApplicationStarting notification)
        {
            if (notification.RuntimeLevel >= Umbraco.Cms.Core.RuntimeLevel.Run)
            {
                // register and run our migration plan 
                var upgrader = new Upgrader(new DoStuffMigrationPlan());
                upgrader.Execute(scopeProvider, migrationBuilder, keyValueService, logger, loggerFactory);
            }
        }
    }
}
