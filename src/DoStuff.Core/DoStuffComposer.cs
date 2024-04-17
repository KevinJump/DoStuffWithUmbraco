using DoStuff.Core.Data.Migrations;

using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace DoStuff.Core;

/// <summary>
///  Composer to add code to umbraco.
/// </summary>
/// <remarks>
///  if you use a composer then Umbraco will automatically pick 
///  it up and run the code in it as part of the startup process
///  
///  if you want your code to always be there this is a way to go.
/// </remarks>
public class DoStuffComposer : IComposer
{
	public void Compose(IUmbracoBuilder builder)
	{
		// composers are there for you to register things. 
		// don't run actually code here (if you can help it)
		//
		// code you need to run at startup  (e.g migrations, etc)
		// should run in a notification.
		// 
		// UmbracoApplicationStarting and UmbracoApplicationStarted
		// are the recommended locations to run code on startup. 

		// call the extension point (below) 
		builder.AddDoStuffApp();
	}
}

/// <summary>
///  if you want it so the code has to be manually added to umbraco
///  then using a builder extension means people can choose to add
///  it in their pipeline. 
///  
///  the recommended way is to use the composer so you know everything
///  is registered but if there are order / other issues directly 
///  referencing the extension point can help
///  
///  (note you can order composers with ComposeBefore and ComposeAfter
///  attributes)
/// </summary>

public static class DoStuffBuilderExtensions
{
	public static IUmbracoBuilder AddDoStuffApp(this IUmbracoBuilder builder)
	{
		// add the migrations (this will create db tables, etc).
		builder.AddDoStuffMigrations();

		return builder;
	}
}
