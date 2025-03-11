import { manifests as entrypoints } from "./entrypoints/manifest";

// out manifests
import { manifests as sections } from "./sections/manifest";
import { manifests as localizations } from "./lang/manifest";

// Job of the bundle is to collate all the manifests from different parts of the extension and load other manifests
// We load this bundle from umbraco-package.json
export const manifests: Array<UmbExtensionManifest> = [
  ...entrypoints,
  ...sections,
  ...localizations,
];
