import { UmbBaseController } from "@umbraco-cms/backoffice/class-api";
import { UmbControllerHost } from "@umbraco-cms/backoffice/controller-api";
import { UmbStringState } from "@umbraco-cms/backoffice/observable-api";

import { UMB_AUTH_CONTEXT } from '@umbraco-cms/backoffice/auth'
import { UmbContextToken } from "@umbraco-cms/backoffice/context-api";
import { DoStuffRepository } from "../repository/dostuff.repository";
import { OpenAPI } from "../api";

export class DoStuffContext extends UmbBaseController {

    #repository: DoStuffRepository;

    #time = new UmbStringState('')
    public readonly time = this.#time.asObservable();

    constructor(host: UmbControllerHost) {
        super(host);
        this.#repository = new DoStuffRepository(host);

        this.provideContext(DOSTUFF_CONTEXT_TOKEN, this);

        this.consumeContext(UMB_AUTH_CONTEXT, (_auth) => {
            OpenAPI.TOKEN = () => _auth.getLatestToken();
            OpenAPI.WITH_CREDENTIALS = true;
        });
    }

    async getTime()
    {
        const { data } = await this.#repository.getTime();

        if (data) { 
            this.#time.setValue(data);
        }
    }

}

export default DoStuffContext;

export const DOSTUFF_CONTEXT_TOKEN =
    new UmbContextToken<DoStuffContext>(DoStuffContext.name);
