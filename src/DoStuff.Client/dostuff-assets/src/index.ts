import { UmbEntryPointOnInit } from '@umbraco-cms/backoffice/extension-api';
import { ManifestTypes } from '@umbraco-cms/backoffice/extension-registry';

// load up the manifests here.
import { manifests as dashboardManifests } from './dashboards/manifest.ts';

const manifests: Array<ManifestTypes> = [...dashboardManifests];

export const onInit: UmbEntryPointOnInit = (_host, extensionRegistry) => {
	// register the here.
	extensionRegistry.registerMany(manifests);
};
