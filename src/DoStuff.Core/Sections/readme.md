# Custom Sections 

The Umbraco Backoffice is split into sections, such as content, media, settings and you can add your own. 

## Changes from v8 to NetCore.
> **Very few** : NetCore code is very similar to v8.

### Changes:
1. Composer now uses `IUmbracoBuilder` object to register section
2. `INotificationHandler<UmbracoApplicationStarting>` is used in place of Compotent to add section to admin group.


# See Also 

Umbraco Documentation 
- https://our.umbraco.com/Documentation/Extending/Section-Trees/sections-v8