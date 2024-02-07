import { UmbBaseController } from "@umbraco-cms/backoffice/class-api";
import { UmbControllerHost } from "@umbraco-cms/backoffice/controller-api";
import { DoStuffTimeSource } from "./sources/dostuff.time.source";


export class DoStuffRepository extends UmbBaseController {
    #timeDataSource: DoStuffTimeSource;

    constructor(host: UmbControllerHost) {
        super(host);
        this.#timeDataSource = new DoStuffTimeSource(host);
    }

    async getTime() {
        return await this.#timeDataSource.getTime();
    }
}