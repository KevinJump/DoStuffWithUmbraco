# Dependency Injection / Composers

[Dependency injection in .net](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection) allows you to quickly and easily add components and use them accross your projects with minial configuration and a level of abstraction that gives you a flexible code base.

For a traditional ASP.Net site you might add your services and components to the program.cs file and then your site would load them up.

but for umbraco it is advisable not to change the program.cs file, and instead use the [Composer feature](https://docs.umbraco.com/umbraco-cms/reference/using-ioc) to load any required services,configuration or components during startup of a project.

> [!NOTE]
> The Umbraco documentation suggests you might want to alter program.cs to add services, but in our experience you want to avoid this.
> Any changes to the program.cs between versions of Umbraco can cause you upgrade issues if you have changed the file, and you can do almost everything you need via the composers.

## Pattern : Seperate Composer from Code.

It is very tempting (and not really wrong) to add all of the code you need to register at startup directly into your composer method,

```cs
public class MyComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddSingleton<MyService>();
    }
}
```

but for larger projects this can quickly get quite messy quite quickly and before you know it you can have 100's of lines of code all registering diffrent things.

The Umbraco source follows a diffrent pattern where Extensions are used to register and configure descreet elements of functionality, that can then be referenced in the composer.

```cs
internal static class MySuperServiceExtension {

   public static IUmbracoBuilder AddMySuperService(this IUmbracoBuilder builder) {

     builder.Services.AddSingleton<MyService>();

   }
}
```

this can then be added to the composer as a single line

````cs
```cs
public class MyComposer : IComposer
{
   public void Compose(IUmbracoBuilder builder)
   {
       builder.AddMySuperService()
   }
}
````

this keeps things seperated and makes it easier to find the logic that sets up a block of functionaltiy.
