import type { ManifestDashboard } from "@umbraco-cms/backoffice/extension-registry";

/**
 * @description dashboard manifest, for a dashboard to appear in the content section
 */
const dashboards: Array<ManifestDashboard> = [
    {
        type: 'dashboard',
        name: 'dostuff',
        alias: 'dostuff.dashboard',
        elementName: 'dostuff-dashboard',
        js: ()=> import('./dashboard.element.js'),
        weight: -10,
        meta: {
            label: 'DoStuff',
            pathname: 'dostuff'
        },
        conditions: [
            {
                alias: 'Umb.Condition.SectionAlias',
                match: 'Umb.Section.Content'
            }
        ]
    }
]

export const manifests = [...dashboards];
