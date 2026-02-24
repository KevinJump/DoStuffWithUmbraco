import { UmbControllerBase } from "@umbraco-cms/backoffice/class-api";
import { tryExecute } from "@umbraco-cms/backoffice/resources";
import { TimeSettings, TimeSettingsService } from "../api";

export class DoStuffTimeSettingsRepository extends UmbControllerBase {
  async getTimeSettings() {
    return (await tryExecute(this, TimeSettingsService.getTimeSettings())).data;
  }

  async saveTimeSettings(settings: TimeSettings) {
    return (
      await tryExecute(
        this,
        TimeSettingsService.saveTimeSettings({ body: settings }),
      )
    ).data;
  }
}
