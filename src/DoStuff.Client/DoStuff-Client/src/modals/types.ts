import { UmbModalToken } from "@umbraco-cms/backoffice/modal";
import { TimeZoneSetting } from "../api";

export type TimeZonePickerModalData = {};

export type TimeZonePickerModalResult = {
  timezone: TimeZoneSetting;
};

export const DOSTUFF_TIMEZONE_PICKER_MODAL_ALIAS =
  "do-stuff-timezone-picker-modal";

export const DOSTUFF_TIMEZONE_PICKER_MODAL = new UmbModalToken<
  TimeZonePickerModalData,
  TimeZonePickerModalResult
>(DOSTUFF_TIMEZONE_PICKER_MODAL_ALIAS, {
  modal: {
    type: "sidebar",
    size: "small",
  },
});
