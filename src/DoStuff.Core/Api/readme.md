# Management Api

Starting with v14, Umbraco comes with configuration for OpenApi (Swagger) definitions for your API end points. Inside Umbraco there are two main API endpoints, the Delivery API for front end (headless) website building and the Management API for the backend.

Umbraco's own backend code uses the Management framework to talk to umbraco.

When building your own custom backoffice code you will need to build your own Management API endpoints if you need to talk to the server.

When in development mode you can view the swagger documentation via [http://yoursite:port/umbraco/swagger](http://yoursite:port/umbraco/swagger)

## OpenApi (Swagger) Configuration.

One thing you will need to do is define your OpenAPI configuration. you can do this via composer.

```cs
builder.Services.AddSwaggerGen(options =>
{
    // swagger config
});
```

or via a class that impliemnts `IConfigurationOptions<SwaggerGenOptions>`.

```cs
internal class DoStuffSwaggerGenOptions : IConfigureOptions<SwaggerGenOptions>
{
    public void Configure(SwaggerGenOptions options)
    {
        // swagger config...
    }
}
```

Which you then add to the composer/builder.

```cs
builder.Services.ConfigureOptions<DoStuffSwaggerGenOptions>();
```

we have chosen the second method to keep the config in its own place.

### Operations Filter,

By default swagger options will use the method names on the Swagger page but when you later generate code from the swagger confgig these names will appear quite long (they have classnames and method names combined).

you can control this behavior and make the names simpler with an OperationsFiler.

We have included an operation filter that will handle overloaded methods, so if you have two `Get` methods with diffrent parameters , you will get a `/Get` and `/Get2` endpoint in your API.

## Controllers

Following the pattern in the Core we have split the controllers out into base classes (to define groups and routes), and methods.

You don't need to split your controllers in this way, but if you are going to build anything of size it might make sense and give your code a bit more readability.

## API Markup.

Throughout the classes you will notice quite a lot of attributes on classes and methods. Some of these define how the API works (such as `[Route]`, `[Method]` or [Authorize]).

others help the OpenAPI documentation, for example any
`[ProducesResponseType]` define what objects are returned and what codes get returned by the API and these make the documentation more readable.
