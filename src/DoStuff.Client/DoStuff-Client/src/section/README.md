# Section

A section is defined as a manifest, there is no additional code to
make the section real.

```ts
{
  type: "section",
  alias: "DoStuff.Section",
  name: "DoStuff Section",
  meta: {
    label: "#DoStuff_SectionName",
    pathname: "do-stuff",
  },
};
```

## Section uses

Once it's defined you can add dashboards, menus, and workspaces to your section.
All these items will reference the section alias, so you might want to make it
a constant in your project.

> [!NOTE]
> A Section won't just appear, you need to give users permissions to see it,
> usually this is done via the users section of the backoffice (although it is
> possible to do this in code).
