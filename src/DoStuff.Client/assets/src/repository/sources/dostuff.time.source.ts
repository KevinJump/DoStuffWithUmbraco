import { UmbControllerHost } from "@umbraco-cms/backoffice/controller-api";
import { DataSourceResponse } from "@umbraco-cms/backoffice/repository";
import { tryExecuteAndNotify } from '@umbraco-cms/backoffice/resources';
import { TimeResource } from "../../api";

export interface TimeSource {
	getTime(): Promise<DataSourceResponse<string>>;
}

/**
 * @description datasource to get the time from the sever api.
 */
export class DoStuffTimeSource implements TimeSource {
	#host: UmbControllerHost

	constructor(host: UmbControllerHost) {
		this.#host = host;
	}

	async getTime(): Promise<DataSourceResponse<string>> {
		return await tryExecuteAndNotify(this.#host, TimeResource.getTime());
	}

	async getDate(): Promise<DataSourceResponse<string>> {
		return await tryExecuteAndNotify(this.#host, TimeResource.getDate());
	}
}
