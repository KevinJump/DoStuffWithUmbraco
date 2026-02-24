import {
  UmbSubmittableWorkspaceContext,
  UmbWorkspaceActionBase,
} from "@umbraco-cms/backoffice/workspace";
import { DOSTUFF_WORKSPACE_CONTEXT } from "../time-workspace.context";

export class DoStuffSaveTimeSettingsAction extends UmbWorkspaceActionBase<UmbSubmittableWorkspaceContext> {
  override async execute() {
    const context = await this.getContext(DOSTUFF_WORKSPACE_CONTEXT);
    context?.submit();
  }
}

export const api = DoStuffSaveTimeSettingsAction;
