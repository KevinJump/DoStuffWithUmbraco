import {
  css,
  customElement,
  html,
  state,
} from "@umbraco-cms/backoffice/external/lit";
import { UmbModalBaseElement } from "@umbraco-cms/backoffice/modal";
import { TimeZonePickerModalData, TimeZonePickerModalResult } from "./types";
import { DOSTUFF_WORKSPACE_CONTEXT } from "../workspace/time-workspace.context";
import { TimeZoneInfo, TimeZoneSetting } from "../api";
import { UUITextStyles } from "@umbraco-cms/backoffice/external/uui";

@customElement("do-stuff-timezone-picker-modal")
export class DoStuffTimezonePickerModalElement extends UmbModalBaseElement<
  TimeZonePickerModalData,
  TimeZonePickerModalResult
> {
  @state()
  timezones?: TimeZoneInfo[] = [];

  @state()
  selectedTimezone?: string;

  @state()
  timezoneName: string = "";

  constructor() {
    super();

    this.consumeContext(DOSTUFF_WORKSPACE_CONTEXT, async (context) => {
      if (!context) return;
      this.timezones = await context?.getTimeZones();
    });
  }

  #onCancel() {
    this.modalContext?.reject();
  }

  #onSubmit() {
    this.modalContext?.setValue({
      timezone: {
        id: this.selectedTimezone,
        name:
          this.timezoneName.length > 0
            ? this.timezoneName
            : this.selectedTimezone,
      } as TimeZoneSetting,
    } as TimeZonePickerModalResult);
    this.modalContext?.submit();
  }

  #onTimezoneChange(e: CustomEvent) {
    this.selectedTimezone = e.detail.value;

    if (this.timezoneName.length == 0) {
      this.timezoneName = this.selectedTimezone ?? "..";
    }
  }

  #onInputChange(e: InputEvent) {
    this.timezoneName = (e.target as HTMLInputElement).value;
  }

  override render() {
    return html`<umb-body-layout headline="Timezone Picker Modal">
      <uui-box .headline=${this.localize.term("doStuff_addNewTimezoneSetting")}>
        <umb-property-layout
          .label=${this.localize.term("doStuff_timezoneName")}
          .description=${this.localize.term("doStuff_timezoneNameDescription")}
        >
          <uui-input
            slot="editor"
            .label=${this.localize.term("doStuff_timezoneName")}
            @change=${this.#onInputChange}
            .value=${this.timezoneName}
          ></uui-input>
        </umb-property-layout>

        <umb-property-layout
          .label=${this.localize.term("doStuff_selectTimezone")}
          .description=${this.localize.term(
            "doStuff_selectTimezoneDescription",
          )}
        >
          <dostuff-timezone-list-element
            slot="editor"
            .timeZones=${this.timezones}
            @change=${this.#onTimezoneChange}
          ></dostuff-timezone-list-element>
        </umb-property-layout>
      </uui-box>
      <div slot="actions">${this.#renderActions()}</div>
    </umb-body-layout>`;
  }

  #renderActions() {
    return html`<uui-button
        label=${this.localize.term("general_cancel")}
        @click=${this.#onCancel}
        >Cancel</uui-button
      >
      <uui-button
        look="primary"
        color="positive"
        label=${this.localize.term("general_submit")}
        @click=${this.#onSubmit}
        .disabled=${!this.selectedTimezone}
      ></uui-button>`;
  }

  static override styles = [
    UUITextStyles,
    css`
      uui-input {
        width: 100%;
      }
    `,
  ];
}

export default DoStuffTimezonePickerModalElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-timezone-picker-modal": DoStuffTimezonePickerModalElement;
  }
}
