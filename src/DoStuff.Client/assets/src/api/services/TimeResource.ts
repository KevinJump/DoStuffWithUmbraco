/* generated using openapi-typescript-codegen -- do no edit */
/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */
import type { CancelablePromise } from '../core/CancelablePromise';
import { OpenAPI } from '../core/OpenAPI';
import { request as __request } from '../core/request';

export class TimeResource {

    /**
     * @returns string Success
     * @throws ApiError
     */
    public static getUmbracoDoStuffApiV1Date(): CancelablePromise<string> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/doStuff/api/v1/date',
        });
    }

    /**
     * @returns string Success
     * @throws ApiError
     */
    public static getUmbracoDoStuffApiV1Time(): CancelablePromise<string> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/doStuff/api/v1/time',
        });
    }

}
