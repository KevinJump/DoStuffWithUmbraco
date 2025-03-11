const localizations: UmbExtensionManifest[] = [
  {
    type: "localization",
    alias: "do-stuff-localization-en",
    name: "Do Stuff Localization (en)",
    weight: 0,
    meta: { culture: "en" },
    js: () => import("./files/en.js"),
  },
  {
    type: "localization",
    alias: "do-stuff-localization-dk",
    name: "Do Stuff Localization (dk)",
    weight: 0,
    meta: { culture: "dk" },
    js: () => import("./files/dk.js"),
  },
];

export const manifests = [...localizations];
