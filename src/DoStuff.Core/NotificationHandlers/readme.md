# Notification handlers.

When things change or are about to change, Umbraco will fire out Notification message to anything that has registered as a notification handler for that event. [Notification Handlers](https://docs.umbraco.com/umbraco-cms/reference/notifications/notification-handler) are the peices of code you can write to receive and mange these events.

## Notitification Handler

A Notification handler will impliment `INotificationHandler` or `INotificationAsyncHandler` (if you have async methods). the main method
here is the `Handle` method which will be called with details of the notification.

for example when content is saved the ContentSavedNotification handle method will look like.

```cs
public Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
{
  fore  (var entity in notification.SavedEntities) {
    // do stuff each item in the notification.
  }
}
```

## Cancelling a notification

Some notifications can be cancled, and stop the operation withing umbraco.

For example you can stop a peice of content from being saved by cancelling the `ContentSavingNotification`

```cs
public void Handle(ContentSavingNotification notification, CancellationToken cancellationToken)
{

  // some logic that makes us want to stop the save event
  notification.CancelOperation(new EventMessage("Blocked", "Save blocked", EventMessageType.Error));
  notification.Cancel = true;
}
```

> [!NOTE]
> While a lot of notifications will pass an array of items, at this time Umbraco very rearly / never passes an array of items to a notification
> Even when notifications are batched up, Umbraco sends one per item.

## Registering

Notification handlers must be registred at startup either in the composer or your extension methods (see [dependency injection](../../DoStuff.Client/DependencyInjection/readme.md).

```cs
// register our notification handlers to process things when something happens.
builder.AddNotificationAsyncHandler<ContentSavingNotification, ContentNotificationAsyncHandler>()
  .AddNotificationAsyncHandler<ContentSavedNotification, ContentNotificationAsyncHandler>();
```

> The `AddNotificationHandler` method returns IUmbracoBuilder, so these notifications can be chained together

## Delayed notifications.

Some operations (such as imports from uSync or Umbraco.Deploy) will delay some notifications until they have been completed.

Notifications that cannot be canceled (such as ContentSaved) may not fire as the content is saved but after a batch of content has been saved, therefore you can't reley on the ordering or timing of this event to do something else with the content. Mostly this isn't an issue but its good to be aware.

## Adding Notifications

[TODO - See Custom Notifications.]
