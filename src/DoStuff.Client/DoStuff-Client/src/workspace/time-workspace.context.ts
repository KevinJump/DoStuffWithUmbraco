import {
  UmbEditableWorkspaceContextBase,
  UmbSubmittableWorkspaceContext,
} from "@umbraco-cms/backoffice/workspace";
import { DOSTUFF_TIME_ITEM_ALIAS } from "../constants";
import { UmbControllerHost } from "@umbraco-cms/backoffice/controller-api";
import { DOSTUFF_WORKSPACE_ALIAS, DOSTUFF_WORKSPACE_CONTEXT } from "./types";
import { DoStuffTimeRepository } from "../repository/time-repository";
import {
  UmbArrayState,
  UmbObjectState,
  UmbStringState,
} from "@umbraco-cms/backoffice/observable-api";
import { TimeSettings, TimeZoneDisplayTime, TimeZoneSetting } from "../api";
import { DoStuffTimeSettingsRepository } from "../repository/timeSettings-repository";

export class DoStuffTimeWorkspaceContext
  extends UmbEditableWorkspaceContextBase<TimeSettings>
  implements UmbSubmittableWorkspaceContext
{
  public readonly workspaceAlias = DOSTUFF_WORKSPACE_ALIAS;
  #timeRepository = new DoStuffTimeRepository(this);
  #settingsRepository = new DoStuffTimeSettingsRepository(this);

  constructor(host: UmbControllerHost) {
    super(host, DOSTUFF_WORKSPACE_ALIAS);

    this.provideContext(DOSTUFF_WORKSPACE_CONTEXT, this);
    this.loadTimeSettings();

    this.view.setTitle("Time");
  }

  #localTime = new UmbStringState(undefined);
  localtime = this.#localTime.asObservable();

  #serverTime = new UmbStringState(undefined);
  servertime = this.#serverTime.asObservable();

  #timeZoneTimes = new UmbArrayState<TimeZoneDisplayTime>([], (x) => x.id);
  timeZoneTimes = this.#timeZoneTimes.asObservable();

  #timeSettings = new UmbObjectState<TimeSettings | undefined>(undefined);
  timeSettings = this.#timeSettings.asObservable();

  readonly unique = this.#timeSettings.asObservablePart((data) => data?.key);

  getUnique(): string | null | undefined {
    return "default";
  }

  getData(): TimeSettings | undefined {
    return this.#timeSettings.value;
  }

  getEntityType(): string {
    return DOSTUFF_TIME_ITEM_ALIAS;
  }

  async submit() {
    const settings = this.#timeSettings.value;
    if (!settings) return;
    await this.#settingsRepository.saveTimeSettings(settings);
  }

  getLocalTime() {
    const time = new Date().toLocaleTimeString();
    this.#localTime.setValue(time);
    return time;
  }

  async getServerTime() {
    const time = await this.#timeRepository.getTime();
    this.#serverTime.setValue(time);
    return time;
  }

  async getTimezoneTime(timezone: string) {
    const time = await this.#timeRepository.getTimeWithTimezone(timezone);
    this.#serverTime.setValue(time);
    return time;
  }

  async getTimeZones() {
    return await this.#timeRepository.getTimeZones();
  }

  async loadTimeSettings() {
    const settings = await this.#settingsRepository.getTimeSettings();
    this.#timeSettings.setValue(settings);
    return settings;
  }

  async updateTimeSettings(settings: TimeSettings) {
    // update the time settings , but don't save them
    this.#timeSettings.setValue(settings);
  }

  async getTimeZoneTimes(timezones: TimeZoneSetting[]) {
    const times = await this.#timeRepository.getTimeZoneTimes(timezones);
    this.#timeZoneTimes.setValue(times ?? []);
    return times;
  }
}

export { DoStuffTimeWorkspaceContext as api };
