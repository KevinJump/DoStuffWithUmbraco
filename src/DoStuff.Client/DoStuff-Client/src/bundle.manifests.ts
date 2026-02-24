import { manifests as entrypoints } from "./entrypoints/manifest.js";
import { manifests as sectionManifests } from "./section/manifest.js";
import { manifests as dashboardManifests } from "./dashboard/manifest.js";
import { manifests as localizationManifests } from "./lang/manifest.js";
import { manifests as menuManifests } from "./menus/manifest.js";
import { manifests as workspaceManifests } from "./workspace/manifest.js";
import { manifests as editorManifests } from "./editors/manifest.js";
import { manifests as modalManifests } from "./modals/manifest.js";

import "./components/index.js";

// Job of the bundle is to collate all the manifests from different parts of the extension and load other manifests
// We load this bundle from umbraco-package.json
export const manifests: Array<UmbExtensionManifest> = [
  ...entrypoints,
  ...sectionManifests,
  ...dashboardManifests,
  ...localizationManifests,
  ...menuManifests,
  ...workspaceManifests,
  ...editorManifests,
  ...modalManifests,
];
