import { UmbEntryPointOnInit } from '@umbraco-cms/backoffice/extension-api';

// load up the manifests here.
import { manifests as contextManifests } from './context/manifest.ts';
import { manifests as dashboardManifests } from './dashboards/manifest.ts';

export const onInit: UmbEntryPointOnInit = (_host, extensionRegistry) => {
    
    // register them here. 
    extensionRegistry.registerMany([
        ...contextManifests,
        ...dashboardManifests
    ]);
};
