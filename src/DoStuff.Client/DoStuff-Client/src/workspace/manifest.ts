import { DOSTUFF_TIME_ITEM_ALIAS } from "../constants.js";
import {
  DOSTUFF_WORKSPACE_ALIAS,
  DOSTUFF_WORKSPACE_CONTEXT_ALIAS,
} from "./types.js";

import { manifests as viewManifests } from "./views/manifest.js";
import { manifests as actionManifests } from "./actions/manifest.js";

var workspace: UmbExtensionManifest = {
  type: "workspace",
  alias: DOSTUFF_WORKSPACE_ALIAS,
  name: "DoStuff Workspace",
  js: () => import("./time-workspace.element.js"),
  meta: {
    entityType: DOSTUFF_TIME_ITEM_ALIAS,
  },
};

var workspaceContext: UmbExtensionManifest = {
  type: "workspaceContext",
  alias: DOSTUFF_WORKSPACE_CONTEXT_ALIAS,
  name: "DoStuff Workspace Context",
  js: () => import("./time-workspace.context.js"),
};

export const manifests = [
  workspace,
  workspaceContext,
  ...viewManifests,
  ...actionManifests,
];
