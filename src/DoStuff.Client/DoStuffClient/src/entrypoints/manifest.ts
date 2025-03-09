export const manifests: Array<UmbExtensionManifest> = [
  {
    name: "Do Stuff Client Entrypoint",
    alias: "DoStuff.Client.Entrypoint",
    type: "backofficeEntryPoint",
    js: () => import("./entrypoint"),
  }
];
