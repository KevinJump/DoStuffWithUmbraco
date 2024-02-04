import { ManifestGlobalContext } from "@umbraco-cms/backoffice/extension-registry";

/**
 * @description global context, accessible across all of umbraco. 
 */
const globalContexts: ManifestGlobalContext = {
    type: 'globalContext',
    alias: 'dostuff.context',
    name: 'DoStuff global context',
    js: () => import('./dostuff.context.js')
};

export const manifests = [globalContexts];