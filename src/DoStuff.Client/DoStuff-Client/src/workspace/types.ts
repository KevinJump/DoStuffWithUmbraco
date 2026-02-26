import { UmbContextToken } from "@umbraco-cms/backoffice/context-api";
import { DoStuffTimeWorkspaceContext } from "./time-workspace.context";

export const DOSTUFF_WORKSPACE_ALIAS = "DoStuff.Workspace";
export const DOSTUFF_WORKSPACE_CONTEXT_ALIAS = "DoStuff.Workspace.Context";

export const DOSTUFF_WORKSPACE_CONTEXT =
  new UmbContextToken<DoStuffTimeWorkspaceContext>(
    "UmbWorkspaceContext",
    DOSTUFF_WORKSPACE_CONTEXT_ALIAS,
  );
