import { DOSTUFF_TIMEZONE_PICKER_MODAL_ALIAS } from "./types.js";

const timezonePickerModal: UmbExtensionManifest = {
  type: "modal",
  alias: DOSTUFF_TIMEZONE_PICKER_MODAL_ALIAS,
  name: "DoStuff Timezone Picker Modal",
  js: () => import("./timezone-picker-modal.element.js"),
};

export const manifests = [timezonePickerModal];
