import {
  css,
  customElement,
  html,
  state,
} from "@umbraco-cms/backoffice/external/lit";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import DoStuffTimeWorkspaceContext, {
  DOSTUFF_WORKSPACE_CONTEXT,
} from "../time-workspace.context";
import { TimeSettings } from "../../api";
import { UUITextStyles } from "@umbraco-cms/backoffice/external/uui";
import { UmbPropertyValueData } from "@umbraco-cms/backoffice/property";

@customElement("do-stuff-settings-workspace-view-element")
export class DoStuffSettingsWorkspaceViewElement extends UmbLitElement {
  #workspaceContext?: DoStuffTimeWorkspaceContext;

  @state()
  settings?: TimeSettings;

  constructor() {
    super();

    this.consumeContext(DOSTUFF_WORKSPACE_CONTEXT, async (context) => {
      if (!context) return;
      this.#workspaceContext = context;

      this.observe(this.#workspaceContext.timeSettings, (settings) => {
        this.settings = settings ?? undefined;
      });
    });
  }

  // #onTimezoneChange(e: Event) {
  //   const oldValue = this.data;
  //   this.data = (e.target as UmbPropertyDatasetElement).value;
  //   this.requestUpdate("data", oldValue);
  // }

  @state()
  data: UmbPropertyValueData[] = [
    {
      alias: "timezone",
      value: "",
    },
  ];

  #onUpdateValue(e: Event) {
    if (!this.settings) return;
    const value = (e.target as HTMLInputElement).value;
    const refreshInterval = parseFloat(value) * 1000;

    this.#workspaceContext?.updateTimeSettings({
      ...this.settings,
      refreshInterval,
    });

    this.#workspaceContext?.updateTimeSettings(this.settings);
  }

  #onAddTimeZoneSetting(e: CustomEvent) {
    if (!this.settings) return;

    const newSettings = {
      ...this.settings,
      timeZones: [...(this.settings.timeZones ?? []), e.detail.timezone],
    };

    this.#workspaceContext?.updateTimeSettings(newSettings);
  }

  #onRemoveTimeZoneSetting(e: CustomEvent) {
    if (!this.settings) return;

    const newSettings = {
      ...this.settings,
      timeZones: this.settings.timeZones?.filter((tz) => tz.id !== e.detail.id),
    };

    this.#workspaceContext?.updateTimeSettings(newSettings);
  }

  override render() {
    return html`<umb-body-layout>
      <div class="layout">
        <uui-box .headline=${this.localize.term("doStuff_timeSettingsTitle")}>
          <umb-localize key="doStuff_timeSettingsIntro"></umb-localize>
        </uui-box>
        <uui-box .headline=${this.localize.term("doStuff_timezones")}>
          ${this.#renderTimeZones()}
        </uui-box>
        <uui-box .headline=${this.localize.term("doStuff_refreshInterval")}>
          ${this.#renderRefreshSlider()}
        </uui-box>
      </div>
    </umb-body-layout>`;
  }

  #renderTimeZones() {
    return html`<umb-property-layout
      .label=${this.localize.term("doStuff_timezones")}
      .description=${this.localize.term("doStuff_timezonesDescription")}
    >
      <do-stuff-timezone-setting-picker-element
        slot="editor"
        .settings=${this.settings?.timeZones ?? []}
        @change=${this.#onAddTimeZoneSetting}
        @remove=${this.#onRemoveTimeZoneSetting}
      ></do-stuff-timezone-setting-picker-element
    ></umb-property-layout>`;
  }

  #renderRefreshSlider() {
    var value = (this.settings?.refreshInterval ?? 0) / 1000;

    return html` <umb-property-layout
      .label=${this.localize.term("doStuff_refreshInterval")}
      .description=${this.localize.term("doStuff_refreshIntervalDescription")}
    >
      <uui-slider
        slot="editor"
        label="Refresh Interval"
        min="0.1"
        max="2.0"
        step="0.1"
        value="${value}"
        @change=${this.#onUpdateValue}
      ></uui-slider
    ></umb-property-layout>`;
  }

  static override styles = [
    UUITextStyles,
    css`
      .layout {
        display: flex;
        flex-direction: column;
        gap: var(--uui-size-layout-1);
      }
    `,
  ];
}

export default DoStuffSettingsWorkspaceViewElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-settings-workspace-view-element": DoStuffSettingsWorkspaceViewElement;
  }
}
