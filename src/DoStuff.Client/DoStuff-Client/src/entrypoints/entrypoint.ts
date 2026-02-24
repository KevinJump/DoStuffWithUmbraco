import { UMB_AUTH_CONTEXT } from "@umbraco-cms/backoffice/auth";
import type {
  UmbEntryPointOnInit,
  UmbEntryPointOnUnload,
} from "@umbraco-cms/backoffice/extension-api";
import { client } from "../api/client.gen";

// load up the manifests here
export const onInit: UmbEntryPointOnInit = (_host, _extensionRegistry) => {
  console.log("Doing Stuff with Umbraco 🏃‍♂️");

  _host.consumeContext(UMB_AUTH_CONTEXT, async (authContext) => {
    // Get the token info from Umbraco
    const config = authContext?.getOpenApiConfiguration();

    client.setConfig({
      auth: config?.token ?? undefined,
      baseUrl: config?.base ?? "",
      credentials: config?.credentials ?? "same-origin",
    });

    // client interceptor will get the latest token for the auth
    // context for a request, so if the token has been refreshed
    // since we first got it, we'll still have a valid token.
    client.interceptors.request.use(async (request, _options) => {
      const token = await authContext?.getLatestToken();
      request.headers.set("Authorization", `Bearer ${token}`);
      return request;
    });
  });
};

export const onUnload: UmbEntryPointOnUnload = (_host, _extensionRegistry) => {
  console.log("Goodbye from my extension 👋");
};
