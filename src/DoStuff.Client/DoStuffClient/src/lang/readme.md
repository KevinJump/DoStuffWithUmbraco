# Localization (Client)

You can localize your client UI by adding your own localization manifests for diffrent languages.

Localization lets you make your UI multi-lingual but it also allows you to remove any hardcoded strings from around your app and have them in one place so its easier to edit / pass to someone who can spell.

## Register manifest.

the localization manifest entry, tells umbraco the language and where the file containing the strings exists.

```ts
{
  type: "localization",
  alias: "do-stuff-localization-en",
  name: "Do Stuff Localization (en)",
  weight: 0,
  meta: { culture: "en" },
  js: () => import("./files/en.js"),
},
```

> [!NOTE]
> The default language fallback will likely be 'en' so having an 'en' file ensures you will at least have some values for your site.

## The file.

the localized text exists in a file that exports a object with all the values.

```ts
export default {
  dostuff: {
    name: "Do Stuff",
  },
};
```

here the values are under the `dostuff` namespace, so would be referenced `dostuff_name`

## using.

### in a template

the `<umb-localize>` component can be used to fetch a string

```html
<umb-localize key="dostuff_name></umb-localize>
```

### in code in an element

if your element inherits 'UmbLitelement` you can call the localize method.

```ts
$this.localize.term("dostuff_name");
```

### in a manifest (label)

If you want the label of something defined in a manifest to use a localized value
you can use the '#name' notation to get it.

eg. in the meta element of a manifest item ...

```ts
meta: {
  label: "#dostuff_name";
}
```
