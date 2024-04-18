# sections.

Sections are defined completly in a manifest file.

```ts
const sectionManifest: ManifestSection = {
	type: 'section',
	alias: DOSTUFF_SECTION_ALIAS,
	name: 'DoStuff section',
	weight: 10,
	meta: {
		label: 'DoStuff',
		pathname: 'dostuff',
	},
};
```

without conditions they will appear for all users.

you can add conditions so they only appear for users
who are in groups that have the permissions to see
the section

```ts
	conditions: [
		{
			alias: 'Umb.Condition.SectionUserPermission',
			match: DOSTUFF_SECTION_ALIAS,
		},
    ],
};
```
