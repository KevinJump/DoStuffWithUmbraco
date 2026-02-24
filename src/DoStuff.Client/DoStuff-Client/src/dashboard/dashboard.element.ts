import { customElement, html } from "@umbraco-cms/backoffice/external/lit";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";

@customElement("do-stuff-dashboard-element")
export class DoStuffDashboardElement extends UmbLitElement {
  override render() {
    return html`<umb-body-layout
      .headline=${this.localize.term("doStuff_dashboardTitle")}
    >
      <uui-box>
        <umb-localize key="doStuff_dashboardIntro"></umb-localize>
      </uui-box>
    </umb-body-layout>`;
  }
}

export default DoStuffDashboardElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-dashboard-element": DoStuffDashboardElement;
  }
}
