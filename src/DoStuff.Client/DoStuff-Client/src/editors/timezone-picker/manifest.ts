const timezonePickerManifest: UmbExtensionManifest = {
  type: "propertyEditorUi",
  alias: "DoStuff.TimezonePicker",
  name: "DoStuff Timezone Picker",
  element: () => import("./timezone-picker.element"),
  meta: {
    label: "DoStuff Timezone Picker",
    icon: "umb:clock",
    group: "pickers",
    propertyEditorSchemaAlias: "DoStuff.TimezonePicker",
    supportsReadOnly: true,
    settings: {
      properties: [],
    },
  },
};

export const manifests = [timezonePickerManifest];
