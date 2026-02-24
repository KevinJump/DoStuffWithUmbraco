import { DOSTUFF_SECTION_ALIAS, DOSTUFF_TIME_ITEM_ALIAS } from "../constants";

// A sidebar is is like the 'section' of the side bar you want things to be in.
// examples in the Umbraco settings section are 'Structure', 'Templating', and 'Adanced'
const sidebarManifest: UmbExtensionManifest = {
  type: "sectionSidebarApp",
  kind: "menu",
  alias: "DoStuff.SectionSidebarApp",
  name: "DoStuff Section Sidebar App",
  meta: {
    label: "#doStuff_sidebarStaticAppName",
    menu: "DoStuff.Static.Menu",
  },
  conditions: [
    {
      alias: "Umb.Condition.SectionAlias",
      match: DOSTUFF_SECTION_ALIAS,
    },
  ],
};

// sidebars can have elements in them ! - but mostly you will asign a menu to a sidebarApp
// and then you either have a tree, or items directly in the menu.
const menuManifest: UmbExtensionManifest = {
  type: "menu",
  alias: "DoStuff.Static.Menu",
  name: "DoStuff Static Menu",
};

// A menu item in the sidebar app, the user will see this and expect something to open up
// in the make workspace area when they do.
const timeItemManifest: UmbExtensionManifest = {
  type: "menuItem",
  alias: "DoStuff.TimeItem",
  name: "DoStuff Time Item",
  weight: 10,
  meta: {
    label: "#doStuff_timeItemName",
    icon: "icon-time",
    entityType: DOSTUFF_TIME_ITEM_ALIAS,
    menus: ["DoStuff.Static.Menu"],
  },
};

export const manifests = [sidebarManifest, menuManifest, timeItemManifest];
