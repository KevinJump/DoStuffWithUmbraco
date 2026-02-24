import { UmbControllerBase } from "@umbraco-cms/backoffice/class-api";
import { tryExecute } from "@umbraco-cms/backoffice/resources";
import { TimeService, TimeZoneSetting } from "../api";

export class DoStuffTimeRepository extends UmbControllerBase {
  /**
   * Get the current time from the API
   * @returns Current time
   */
  async getTime() {
    return (await tryExecute(this, TimeService.getCurrentTime())).data;
  }

  async getTimeWithTimezone(timezone: string) {
    return (
      await tryExecute(
        this,
        TimeService.getTimezoneTime({ query: { timezone } }),
      )
    ).data;
  }

  async getTimeZones() {
    return (await tryExecute(this, TimeService.getTimeZones())).data;
  }

  async getTimeZoneTimes(timezones: TimeZoneSetting[]) {
    return (
      await tryExecute(this, TimeService.getTimeZoneTimes({ body: timezones }))
    ).data;
  }
}
