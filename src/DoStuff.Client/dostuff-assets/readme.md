# Client Code.

This is the front end client code for backoffice elements.

The code is written in Typescript and uses Vite to build and move the content into the ../wwwroot folder.

This project is a Razor class library, and so the wwwroot code is served to the main website project as if it is in it's wwwroot folder.

## `npm run watch` for changes

While developing you should have `npm run watch` running.

then when you edit a file.

1. vite will compress and compile the typescript into javascript code
2. vite will cope the javascript (and the `umbraco-package.json` file from 'public') into the [../wwwroot](../wwwroot) folder.
3. Dotnet will detect the changes in the RCL folder.
4. The website will reflect the changes<sup>\*</sup>

<sup>*</sup> *if you have Visual Studio configured correctly the website will reload automatically and you will see your changes\*

## Auto Generate API.

While your website is running

```bash
npm run generate
```

Will download the swagger config from the site and generate an API client library in the [./api](./api) folder.

you should not alter the code in this library. but you can access it via Service classes e.g

```ts
ToDoListsService.GetCount();
```

### Connect OAuth token.

inorder to access resources that require authentication you will need to send an oAuth token.

The Umbraco client oAuth token is avalible and can be attached to your client libraries oAuth setup in the entry point for your code [index.ts](./src/index.ts)

```ts
// when we have auth, consume it in our Api Client
_host.consumeContext(UMB_AUTH_CONTEXT, (_auth) => {
	const umbOpenApi = _auth.getOpenApiConfiguration();
	OpenAPI.TOKEN = umbOpenApi.token;
	OpenAPI.BASE = umbOpenApi.base;
	OpenAPI.WITH_CREDENTIALS = umbOpenApi.withCredentials;
});
```
