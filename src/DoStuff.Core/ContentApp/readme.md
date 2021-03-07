# ContentApp

## Changes from v8 to NetCore
> **Very few**: No changes to core classes.

1. The `UriUtility` class is no longer static so if you use this to calculate where file paths are, you need to inject it. 

## ContentApp setup 
You can setup a content app in two ways either via a package.manifest file or by having a class that implements IContentAppFactory (and is registered via a composer)

you can control most things via the package.manifest file - registering via code 
just gives you slightly more control over when or when not to include your app.

- [CustomContentApp.cs](CustomContentApp.cs)

the content app will show html/js from the app_plugins folder as defined by you

- [App_Plugins ContentApp Folder](../App_Plugins/DoStuff.ContentApp/)


# See Also

- Content App Intro https://umbraco.com/blog/umbraco-8-content-apps/
- Documentation https://our.umbraco.com/documentation/Extending/Content-Apps/


