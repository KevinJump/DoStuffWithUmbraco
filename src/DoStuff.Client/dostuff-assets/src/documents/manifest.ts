import { ManifestWorkspaceView } from '@umbraco-cms/backoffice/extension-registry';

const workspaceView: ManifestWorkspaceView = {
	type: 'workspaceView',
	alias: 'dostuff.document.todolist.view',
	name: 'ToDoList workspace view',
	js: () => import('./workspaces/ToDoList-Workspace.Element'),
	weight: 10,
	meta: {
		icon: 'icon-list',
		pathname: 'todo',
		label: 'todo',
	},
	conditions: [
		{
			alias: 'Umb.Condition.WorkspaceAlias',
			match: 'Umb.Workspace.Document',
		},
	],
};

export const manifests = [workspaceView];
