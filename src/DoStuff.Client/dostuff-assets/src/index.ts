import { UMB_AUTH_CONTEXT } from '@umbraco-cms/backoffice/auth';
import { UmbEntryPointOnInit } from '@umbraco-cms/backoffice/extension-api';
import { ManifestTypes } from '@umbraco-cms/backoffice/extension-registry';

// load up the manifests here.
import { manifests as dashboardManifests } from './dashboards/manifest.ts';
import { OpenAPI } from './api/index.ts';

const manifests: Array<ManifestTypes> = [...dashboardManifests];

export const onInit: UmbEntryPointOnInit = (_host, extensionRegistry) => {
	// register the here.
	extensionRegistry.registerMany(manifests);

	// when we have auth, consume it in our Api Client
	_host.consumeContext(UMB_AUTH_CONTEXT, (_auth) => {
		const umbOpenApi = _auth.getOpenApiConfiguration();
		OpenAPI.TOKEN = umbOpenApi.token;
		OpenAPI.BASE = umbOpenApi.base;
		OpenAPI.WITH_CREDENTIALS = umbOpenApi.withCredentials;
	});
};
