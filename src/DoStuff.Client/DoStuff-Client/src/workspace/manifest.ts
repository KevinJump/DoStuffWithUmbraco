import { DOSTUFF_WORKSPACE_ALIAS } from "./types.js";

import { manifests as viewManifests } from "./views/manifest.js";
import { manifests as actionManifests } from "./actions/manifest.js";
import { DOSTUFF_TIME_ITEM_ALIAS } from "../constants.js";

var workspace: UmbExtensionManifest = {
  type: "workspace",
  kind: "default",
  alias: DOSTUFF_WORKSPACE_ALIAS,
  name: "DoStuff Workspace Context",
  api: () => import("./time-workspace.context.js"),
  meta: {
    entityType: DOSTUFF_TIME_ITEM_ALIAS,
  },
};

export const manifests = [workspace, ...viewManifests, ...actionManifests];
