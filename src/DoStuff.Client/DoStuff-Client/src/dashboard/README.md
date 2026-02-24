## Dashboards

A Dashboard is a tab that displays on the 'home' page of a section in the umbraco backoffice (such as Conten, Media, etc).

The welcome tab on content is a dashboard, as is the "Redirect Url Management" tab. 

Umbraco Docs: https://docs.umbraco.com/umbraco-cms/customizing/extending-overview/extension-types/dashboard


## Register via a manifest. 

Dashboards are registered via a manifest,

```ts
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
```

## Dashboard Element

The dashboard element works like any other custom element, and can display anything you want. 

```ts
@customElement("do-stuff-dashboard-element")
export class DoStuffDashboardElement extends UmbLitElement {
  override render() {
  return html`
      <umb-body-layout>
        <div>My Dashboard Content</div>
      </umb-body-layout>
    `;
  }
}
```