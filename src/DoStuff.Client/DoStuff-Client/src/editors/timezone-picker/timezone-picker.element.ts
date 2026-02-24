import {
  customElement,
  html,
  nothing,
  property,
} from "@umbraco-cms/backoffice/external/lit";
import { TimeZoneInfo } from "../../api";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { UmbPropertyEditorUiElement } from "@umbraco-cms/backoffice/property-editor";
import { DoStuffTimeRepository } from "../../repository/time-repository";
import { UmbChangeEvent } from "@umbraco-cms/backoffice/event";

@customElement("dostuff-timezone-picker")
export class DoStuffTimezoneSelectElement
  extends UmbLitElement
  implements UmbPropertyEditorUiElement
{
  @property()
  value?: string;

  @property({ attribute: false })
  public set config(config: any) {
    if (!config) return;
  }

  @property({ type: Array })
  timeZones?: TimeZoneInfo[];

  async connectedCallback(): Promise<void> {
    super.connectedCallback();

    // the property editor is standalone, it might not be running
    // with access to the workspace context, so in this instance
    // we are directly calling the repository to fetch the time zones
    var repo = new DoStuffTimeRepository(this);
    this.timeZones = await repo.getTimeZones();
  }

  #onChange(e: InputEvent) {
    this.value = (e.target as HTMLInputElement).value;
    this.dispatchEvent(new UmbChangeEvent());
  }

  override render() {
    if (!this.timeZones) return nothing;

    return html`<dostuff-timezone-list-element
      .timeZones=${this.timeZones}
      .value=${this.value}
      @change=${this.#onChange}
    ></dostuff-timezone-list-element>`;
  }
}

export { DoStuffTimezoneSelectElement as element };

declare global {
  interface HTMLElementTagNameMap {
    "dostuff-timezone-picker": DoStuffTimezoneSelectElement;
  }
}
