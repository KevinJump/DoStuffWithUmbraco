import { ManifestSection } from '@umbraco-cms/backoffice/extension-registry';

const DOSTUFF_SECTION_ALIAS = 'dostuff.section';

const sectionManifest: ManifestSection = {
	type: 'section',
	alias: DOSTUFF_SECTION_ALIAS,
	name: 'DoStuff section',
	weight: 10,
	meta: {
		label: 'DoStuff',
		pathname: 'dostuff',
	},
	// conditions: [
	// 	{
	// 		alias: 'Umb.Condition.SectionUserPermission',
	// 		match: DOSTUFF_SECTION_ALIAS,
	// 	},
	// ],
};

export const manifests = [sectionManifest];
