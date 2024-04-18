import { UmbElementMixin } from '@umbraco-cms/backoffice/element-api';
import { LitElement, customElement, html } from '@umbraco-cms/backoffice/external/lit';
import {
	UMB_WORKSPACE_CONTEXT,
	UmbVariantableWorkspaceContextInterface,
} from '@umbraco-cms/backoffice/workspace';

@customElement('dostuff-document-todolist-view')
export class DoStuffToDoListWorkspaceElement extends UmbElementMixin(LitElement) {
	#variantContext?: UmbVariantableWorkspaceContextInterface;

	constructor() {
		super();

		this.consumeContext(UMB_WORKSPACE_CONTEXT, (_context) => {
			this.#variantContext = _context as UmbVariantableWorkspaceContextInterface;
		});
	}

	render() {
		return html`
			<umb-body-layout>
				<uui-box headline="ToDo lists">
					<h3>ToDo list content goes here...</h3>
				</uui-box>
			</umb-body-layout>
		`;
	}
}

export default DoStuffToDoListWorkspaceElement;
