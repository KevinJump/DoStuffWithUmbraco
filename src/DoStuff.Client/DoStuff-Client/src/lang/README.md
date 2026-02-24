## Localization.

Where you have any text displayed to the user the prefered course 
of action is to localize it.

This means that you can provide translations for the text in different languages, and the user will see the text in their preferred language.

Umbraco Docs: https://docs.umbraco.com/umbraco-cms/customizing/extending-overview/extension-types/localization

## Register

Localizations are registered via a manifest, just like any other extension.

```ts
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
```

The language files contain a JSON object that gives details of 
all the localised text values for a given language

```
export default {
  doStuff: {
    sectionName: "Do Stuff",
    sidebarStaticAppName: "Do Stuff App",
    }
};
```

## Using Localized Text

Inside you client code you have a couple of examples of how to use the localized text, but the main way is to use the `UmbLocalizationController` to get the text you need.


### localize.term

if you're element extends `UmbLitElement` then you have access to the `localize` controller which has a `term` method that you can use to get the localized text for a given key.

```ts
    return html`<uui-box .headline=${this.localize.term("doStuff_sectionName")}></uui-box>`;
```

### umb-localize
if you just want to present the user with the localized value you can 
also use the `<umb-localize>` element and pass the key as the `key` attribute.
```ts
    return html`<umb-localize key="doStuff_sectionName"></umb-localize>`;
```

We will see thoughout the codebase we use both of these depending on the situation.