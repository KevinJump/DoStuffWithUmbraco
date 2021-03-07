
using Microsoft.Extensions.Logging;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Scoping;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Migrations.Upgrade;

namespace DoStuff.Core.Migrations
{
    /// <summary>
    ///  short hand composer if you are just registering a component 
    /// </summary>
    public class MigrationComponentComposer : ComponentComposer<MigrationComponent>, IUserComposer
    { }

    public class MigrationComponent : IComponent
    {
        private readonly IScopeProvider scopeProvider;
        private readonly IMigrationBuilder migrationBuilder;
        private readonly IKeyValueService keyValueService;

        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger<Upgrader> logger;

        public MigrationComponent(
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

        public void Initialize()
        {
            // register and run our migration plan 
            var upgrader = new Upgrader(new DoStuffMigrationPlan());
            upgrader.Execute(scopeProvider, migrationBuilder, keyValueService, logger, loggerFactory);
        }

        public void Terminate()
        {
            // umbraco closing down
        }
    }
}
