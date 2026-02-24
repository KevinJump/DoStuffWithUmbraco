import { DOSTUFF_WORKSPACE_ALIAS } from "../types.js";

const viewManifests: UmbExtensionManifest[] = [
  {
    type: "workspaceView",
    alias: "DoStuff.DefaultWorkspaceView",
    name: "DoStuff Default Workspace View",
    js: () => import("./default-workspace-view.element.js"),
    weight: 500,
    meta: {
      label: "#doStuff_defaultWorkspaceViewName",
      pathname: "default",
      icon: "icon-alarm-clock",
    },
    conditions: [
      {
        alias: "Umb.Condition.WorkspaceAlias",
        match: DOSTUFF_WORKSPACE_ALIAS,
      },
    ],
  },
  {
    type: "workspaceView",
    alias: "DoStuff.SettingsWorkspaceView",
    name: "DoStuff Settings Workspace View",
    js: () => import("./settings-workspace-view.element.js"),
    weight: 200,
    meta: {
      label: "#doStuff_settingsWorkspaceViewName",
      pathname: "settings",
      icon: "icon-settings",
    },
    conditions: [
      {
        alias: "Umb.Condition.WorkspaceAlias",
        match: DOSTUFF_WORKSPACE_ALIAS,
      },
    ],
  },
];

export const manifests = [...viewManifests];
