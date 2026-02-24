import {
  customElement,
  html,
  nothing,
  property,
} from "@umbraco-cms/backoffice/external/lit";
import { TimeZoneInfo } from "../api";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";

@customElement("dostuff-timezone-list-element")
export class DoStuffTimezoneListElement extends UmbLitElement {
  @property({ type: Array })
  timeZones?: TimeZoneInfo[];

  @property()
  value?: string;

  #onChange(e: InputEvent) {
    this.value = (e.target as HTMLInputElement).value;

    this.dispatchEvent(
      new CustomEvent("change", {
        detail: {
          value: this.value,
        },
      }),
    );
  }

  override render() {
    if (!this.timeZones) return nothing;

    const options: Array<Option> = [
      ...this.timeZones.map((timeZone) => ({
        value: timeZone.id,
        name: `${timeZone.displayName} (UTC${timeZone.baseUtcOffset})`,
        selected: this.value === timeZone.id,
      })),
    ];

    return html`<uui-select
      label="Select Time Zone"
      .options=${options}
      @change=${this.#onChange}
    >
    </uui-select>`;
  }
}

export default DoStuffTimezoneListElement;

declare global {
  interface HTMLElementTagNameMap {
    "dostuff-timezone-list": DoStuffTimezoneListElement;
  }
}
