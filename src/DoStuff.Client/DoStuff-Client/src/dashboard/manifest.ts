import { DOSTUFF_SECTION_ALIAS } from "../constants";

const dashboardManifest: UmbExtensionManifest = {
  type: "dashboard",
  alias: "DoStuff.Dashboard",
  name: "DoStuff Dashboard",
  js: () => import("./dashboard.element.js"),
  meta: {
    label: "#DoStuff_DashboardName",
    pathname: "do-stuff-dashboard",
  },
  conditions: [
    {
      alias: "Umb.Condition.SectionAlias",
      match: DOSTUFF_SECTION_ALIAS,
    },
  ],
};

export const manifests = [dashboardManifest];
