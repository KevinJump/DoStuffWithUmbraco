import { customElement } from "@umbraco-cms/backoffice/external/lit";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { html } from "lit-element/lit-element.js";
import DoStuffTimeWorkspaceContext from "./time-workspace.context";

@customElement("do-stuff-time-workspace-element")
export class DoStuffTimeWorkspaceElement extends UmbLitElement {
  /** @ts-ignore - the context is initalize in this element and consumed by the views */
  #workspaceContext: DoStuffTimeWorkspaceContext;

  constructor() {
    super();
    this.#workspaceContext = new DoStuffTimeWorkspaceContext(this);
  }

  override render() {
    return html`<umb-workspace-editor
      headline="DoStuff Time Workspace"
    ></umb-workspace-editor>`;
  }
}

export default DoStuffTimeWorkspaceElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-time-workspace-element": DoStuffTimeWorkspaceElement;
  }
}
