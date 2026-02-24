import { DOSTUFF_WORKSPACE_ALIAS } from "../types";

const saveAction: UmbExtensionManifest = {
  type: "workspaceAction",
  kind: "default",
  alias: "doStuff.time.saveAction",
  name: "Save Time Settings",
  api: () => import("./save-action.js"),
  meta: {
    look: "primary",
    color: "positive",
    label: "#buttons_save",
  },
  conditions: [
    {
      alias: "Umb.Condition.WorkspaceAlias",
      match: DOSTUFF_WORKSPACE_ALIAS,
    },
  ],
};

export const manifests = [saveAction];
