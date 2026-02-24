import { DOSTUFF_SECTION_ALIAS } from "../constants";

const sectionManifest: UmbExtensionManifest = {
  type: "section",
  alias: DOSTUFF_SECTION_ALIAS,
  name: "DoStuff Section",
  weight: 10,
  meta: {
    label: "#doStuff_sectionName",
    pathname: "do-stuff",
  },
};

export const manifests = [sectionManifest];
