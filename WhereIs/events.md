# Events
> Work in progress - events are still being moved in NetCore

Events in NetCore have changed quite a bit. withing Umbraco8 you would attach a method to the event delegate to get notified when things happen. 

```cs
ContentService.Saved += MyContentSavedEvent;
```

however in NetCore the goal is to remove all event 'singletons' and use NotificationHandlers in their place.

this makes event subscription quite different (but a little easier and cleaner.)

## Notifications in NetCore


### Register Notification Handler for events.
NotificationHandlers are registered within a composer:

```cs
public class DoStuffComposer : IUserComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<ServerVariablesParsing, MyServerVariablesNotifcationHandler>();

    }
}
```

### Implementing INotificationHandler to process event.

Your notification handler can then be separated into its own class and file. (see [DoStuffServerVariablesNotifcationHandler.cs](../src/Events/DoStuffServerVariablesNotifcationHandler.cs]))

```cs
 public class DoStuffServerVariablesNotifcationHandler : INotificationHandler<ServerVariablesParsing>
    {
        private DoStuffOptions _options;
        private LinkGenerator _linkGenerator;

        public DoStuffServerVariablesNotifcationHandler(
            LinkGenerator linkGenerator,
            IOptions<DoStuffOptions> options)
        {
            _linkGenerator = linkGenerator;
            _options = options.Value;
        }

        /// <summary>
        ///  Adds extra info to the server variables javascript object.
        /// </summary>
        /// <remarks>
        ///  values will be accessible in javascript via Umbraco.Sys.ServerVariables.DoStuff object.
        /// </remarks>
        public void Handle(ServerVariablesParsing notification)
        {
            notification.ServerVariables.Add("DoStuff", new Dictionary<string, object>
            {
                { "MagicNumber", _options.MagicNumber },
                { "DoStuffApiBaseUrl", _linkGenerator.GetUmbracoApiServiceBaseUrl<DoStuffApiController>(c => c.GetMagicNumber()) }
            });
        }
    }
```

**This means that for the most common uses you will no longer need a component to register for events as it can be done in the composer, streamlining the code.**

---
### Registering for multiple events in once class.

You can also register for multiple events within the same method: 

This is how ModelsBuilder registers for two events within the core: 

```cs
builder.AddNotificationHandler<UmbracoApplicationStarting, ModelsBuilderNotificationHandler>();
builder.AddNotificationHandler<ServerVariablesParsing, ModelsBuilderNotificationHandler>();
builder.AddNotificationHandler<ModelBindingError, ModelsBuilderNotificationHandler>();

```

and the class implements both handlers. 

```cs
internal class ModelsBuilderNotificationHandler : INotificationHandler<UmbracoApplicationStarting>, INotificationHandler<ServerVariablesParsing>, INotificationHandler<ModelBindingError> {

    // ... code omitted for clarity ... 

    public void Handle(UmbracoApplicationStarting notification) { ... }

    public void Handle(ServerVariablesParsing notification) { ... }

}
```
