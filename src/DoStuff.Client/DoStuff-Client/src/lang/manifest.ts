const localizationManifests: UmbExtensionManifest[] = [
  {
    type: "localization",
    alias: "DoStuff.Lang.en",
    name: "DoStuff Localization - English",
    js: () => import("./files/en.js"),
    meta: {
      culture: "en",
    },
  },
];

export const manifests = [...localizationManifests];
