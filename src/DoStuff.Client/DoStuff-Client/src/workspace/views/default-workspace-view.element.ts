import {
  css,
  customElement,
  html,
  state,
  when,
} from "@umbraco-cms/backoffice/external/lit";
import { UUITextStyles } from "@umbraco-cms/backoffice/external/uui";
import { UmbLitElement } from "@umbraco-cms/backoffice/lit-element";
import DoStuffTimeWorkspaceContext, {
  DOSTUFF_WORKSPACE_CONTEXT,
} from "../time-workspace.context";
import { TimeSettings, TimeZoneDisplayTime } from "../../api";

@customElement("do-stuff-default-workspace-view-element")
export class DoStuffDefaultWorkspaceViewElement extends UmbLitElement {
  #workspaceContext?: DoStuffTimeWorkspaceContext;

  @state()
  private localTime: string = "";

  @state()
  private serverTime?: string = "";

  @state()
  private settings?: TimeSettings | undefined;

  @state()
  private timeZoneTimes?: TimeZoneDisplayTime[];

  private interval?: number;

  constructor() {
    super();

    this.consumeContext(DOSTUFF_WORKSPACE_CONTEXT, (context) => {
      if (!context) return;
      this.#workspaceContext = context;

      // observe the local and server time from the workspace context,
      // and update the state in this view when they change.
      this.observe(this.#workspaceContext.localtime, (localTime) => {
        this.localTime = localTime ?? "";
      });

      this.observe(this.#workspaceContext.servertime, (serverTime) => {
        this.serverTime = serverTime;
      });

      this.observe(this.#workspaceContext.timeZoneTimes, (timeZoneTimes) => {
        this.timeZoneTimes = timeZoneTimes ?? undefined;
      });

      this.observe(this.#workspaceContext.timeSettings, (settings) => {
        if (!settings) return;
        this.settings = settings;
        this.#setupInterval(settings.refreshInterval);
      });
    });
  }

  #setupInterval(interval: number) {
    if (this.interval) {
      clearInterval(this.interval);
    }

    this.interval = setInterval(() => {
      // fetch the time every interval to show that it updates,
      // in a real scenario you might want to do this differently!,
      // but this is just to show how you can call the workspace context
      // from the view.
      this.getLocalTime();
      this.getServerTime();
      this.getTimeZoneTimes();
    }, interval);
  }

  destroy(): void {
    if (this.interval) {
      clearInterval(this.interval);
    }
  }

  private getLocalTime() {
    if (!this.#workspaceContext) return;
    this.#workspaceContext.getLocalTime();
  }

  private async getServerTime() {
    if (!this.#workspaceContext) return;
    await this.#workspaceContext.getServerTime();
  }

  private async getTimeZoneTimes() {
    if (!this.#workspaceContext) return;
    if (!this.settings?.timeZones) return;
    await this.#workspaceContext.getTimeZoneTimes(this.settings.timeZones);
  }

  override render() {
    return html`<umb-body-layout>
      <div class="layout">
        <uui-box
          .headline=${this.localize.term("doStuff_defaultWorkspaceTitle")}
        >
          <umb-localize key="doStuff_defaultWorkspaceIntro"></umb-localize>
        </uui-box>
        <div class="split">
          <uui-box .headline=${this.localize.term("doStuff_browserTimeTitle")}>
            ${this.renderTime(this.localTime)}
          </uui-box>
          <uui-box .headline=${this.localize.term("doStuff_serverTimeTitle")}>
            ${this.renderTime(this.serverTime)}
          </uui-box>
        </div>
        <uui-box .headline=${this.localize.term("doStuff_timeZoneTimesTitle")}>
          ${this.renderTimeZoneTimes()}
        </uui-box>
      </div>
    </umb-body-layout>`;
  }

  private renderTime(time?: string) {
    return html`<div class="time-box">
      ${when(
        !time,
        () => html`<uui-loader-circle></uui-loader-circle>`,
        () => html`<p class="time">${time}</p>`,
      )}
    </div>`;
  }

  private renderTimeZoneTimes() {
    if (!this.timeZoneTimes)
      return html`<uui-loader-circle></uui-loader-circle>`;

    if (this.timeZoneTimes.length === 0)
      return html`<p>Add time zones in the settings to see those times</p>`;

    return html`<uui-table>
      <uui-table-head>
        <uui-table-head-cell>Name</uui-table-head-cell>
        <uui-table-head-cell>Timezone</uui-table-head-cell>
        <uui-table-head-cell>Time</uui-table-head-cell>
      </uui-table-head>
      ${this.timeZoneTimes.map((timeZoneTime) => {
        return html`<uui-table-row>
          <uui-table-cell>${timeZoneTime.name}</uui-table-cell>
          <uui-table-cell>${timeZoneTime.id}</uui-table-cell>
          <uui-table-cell>${timeZoneTime.value}</uui-table-cell>
        </uui-table-row>`;
      })}
    </uui-table>`;
  }

  static override styles = [
    UUITextStyles,
    css`
      .layout {
        display: flex;
        flex-direction: column;
        gap: var(--uui-size-layout-1);
      }

      .split {
        display: grid;
        grid-template-columns: 1fr 1fr;
        gap: var(--uui-size-layout-1);
      }

      .time-box {
        text-align: center;
      }

      uui-loader-circle {
        font-size: var(--uui-type-h1-size);
      }

      .time {
        font-weight: 900;
        font-size: var(--uui-type-h1-size);
      }

      uui-table {
        width: 100%;
      }
    `,
  ];
}

export default DoStuffDefaultWorkspaceViewElement;

declare global {
  interface HTMLElementTagNameMap {
    "do-stuff-default-workspace-view-element": DoStuffDefaultWorkspaceViewElement;
  }
}
