using DoStuff.Core.RepoPattern.Migrations;
using DoStuff.Core.RepoPattern.Persistance;
using DoStuff.Core.RepoPattern.Services;

using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Logging;
using Umbraco.Core.Migrations;
using Umbraco.Core.Migrations.Upgrade;
using Umbraco.Core.Scoping;
using Umbraco.Core.Services;

namespace DoStuff.Core.RepoPattern
{
    public class DoStuffRepoPatternComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // configuration object for the repos
            composition.RegisterUnique<DoStuffRepoOptions>();

            // register our repository
            composition.RegisterUnique<MyListRepo>();

            // register our service 
            composition.RegisterUnique<MyListService>();

            // component for migration (db creation)
            composition.Components()
                .Append<DoStuffRepoPatternComponent>();
        }
    }

    public class DoStuffRepoPatternComponent : IComponent
    {
        private readonly IScopeProvider scopeProvider;
        private readonly IMigrationBuilder migrationBuilder;
        private readonly IKeyValueService keyValueService;
        private readonly IProfilingLogger logger;

        public DoStuffRepoPatternComponent(
            IScopeProvider scopeProvider,
            IMigrationBuilder migrationBuilder,
            IKeyValueService keyValueService,
            IProfilingLogger logger)
        {
            this.scopeProvider = scopeProvider;
            this.migrationBuilder = migrationBuilder;
            this.keyValueService = keyValueService;
            this.logger = logger;
        }

        public void Initialize()
        {
            var upgrader = new Upgrader(new RepoPatternMigrationPlan());
            upgrader.Execute(scopeProvider, migrationBuilder, keyValueService, logger);
        }

        public void Terminate()
        {
            // shut down 
        }
    }
}
