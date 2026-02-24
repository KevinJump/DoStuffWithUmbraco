import {
  css,
  customElement,
  html,
  property,
  repeat,
} from "@umbraco-cms/backoffice/external/lit";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import { TimeZoneSetting } from "../api";
import { umbOpenModal } from "@umbraco-cms/backoffice/modal";
import { DOSTUFF_TIMEZONE_PICKER_MODAL } from "../modals/types";

@customElement("do-stuff-timezone-setting-picker-element")
export class DoStuffTimezoneSettingPickerElement extends UmbLitElement {
  @property({ type: Array })
  settings: TimeZoneSetting[] = [];

  async #onAddClick() {
    // Handle add button click
    const result = await umbOpenModal(this, DOSTUFF_TIMEZONE_PICKER_MODAL, {});
    this.dispatchEvent(new CustomEvent("change", { detail: result }));
  }

  #onRemove(id: string) {
    // Handle remove button click
    this.dispatchEvent(new CustomEvent("remove", { detail: { id } }));
  }

  override render() {
    return html`${this.#renderSettings()} ${this.#renderAddButton()}`;
  }

  #renderSettings() {
    return html`<uui-ref-list>
      ${repeat(
        this.settings,
        (setting) => setting.id,
        (setting) =>
          html`<uui-ref-node
            .name=${setting.name ?? setting.id}
            .detail=${setting.id}
          >
            <uui-action-bar slot="actions">
              <uui-button
                .label=${this.localize.term("general_remove")}
                @click=${() => this.#onRemove(setting.id)}
              ></uui-button>
            </uui-action-bar>
          </uui-ref-node>`,
      )}
    </uui-ref-list>`;
  }

  #renderAddButton() {
    return html`<uui-button
      id="btn-add"
      look="placeholder"
      @click=${this.#onAddClick}
      .label=${this.localize.term("general_add")}
    ></uui-button>`;
  }

  static override styles = [
    css`
      #btn-add {
        display: block;
      }
    `,
  ];
}

export default DoStuffTimezoneSettingPickerElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-timezone-setting-picker-element": DoStuffTimezoneSettingPickerElement;
  }
}
