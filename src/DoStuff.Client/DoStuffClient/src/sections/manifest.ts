/**
 * Define a custom section in the umbraco backoffice.
 *
 * Sections are defined via the manifest, there is no 'code' to make the section.
 *
 * you will need to know the section alias (so maybe put it somewhere shared?)
 * if you want workspaces, menus, etc to appear in your custom section.
 *
 * **NOTE**
 * You won't be able to see the custom section until, you have added it to
 * the Administrator user group, as sections are by default not assigned to
 * any group [TODO: Migration code to add custom section...]
 *
 */
const doDtuffSection: UmbExtensionManifest = {
  type: "section",
  alias: "do-stuff-section",
  name: "Do Stuff Section",
  meta: {
    label: "#dostuff_name",
    pathname: "do-stuff",
  },
};

export const manifests = [doDtuffSection];
