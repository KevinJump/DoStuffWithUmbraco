## Compositions

Almost all backend code you write will need to be register with Umbraco at some point. 

Compositions run at application startup and are used to register services, notification handlers, and other components with the Umbraco dependency injection container.

Umbraco Docs: https://docs.umbraco.com/umbraco-cms/implementation/composing

## Managing Compositions. 

On any project of a decent size you will likely have multiple things you want to register. 
If you just have one composer in your project it can quickly become a dumping ground for all your registrations and get very messy.

To keep things organised we use static extension methods to seperate out the different areas of the code.

So for the DoStuff projects you will just see a simple composer :

```cs
public class DoStuffComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		builder.AddDoStuffCore();
	}
}
```

and most of the work then happens in the extension methods. 

```cs
public static class DoStuffCoreComposerExtensions
{
	public static IUmbracoBuilder AddDoStuffCore(this IUmbracoBuilder builder)
	{
		builder.AddNotifications();
		builder.AddServices();
		return builder;
	}
}

```

We then have separate extension methods for each area of the code, such as notifications and services. 

This might look like a lot, but it keeps everything nice and organised and makes it easy to find where things are registered, 
and for this example repository it helps us keep things separated out so we can easily see how to register different things with Umbraco.
