import { UmbElementMixin } from "@umbraco-cms/backoffice/element-api";
import { LitElement, html, css, customElement, property } from "@umbraco-cms/backoffice/external/lit";


/**
 * @export
 * @method DoStuffDashboard
 * @description Dashboard element
 */
@customElement('dostuff-dashboard')
export class DoStuffDashboard extends UmbElementMixin(LitElement) {

    constructor() {
        super();
    }

    @property()
    title = 'DoStuff dashboard'

    render() {
        return html`
            <uui-box headline="${this.title}">
                dashboard content goes here
            </uui-box>
        `
    }

    static styles = css`
        :host {
            display: block;
            padding: 20px;
        }
    `
}


export default DoStuffDashboard;

declare global {
    interface HtmlElementTagNameMap {
        'dostuff-dashboard': DoStuffDashboard
    }
}
