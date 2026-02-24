## Notifications.

Umbraco fires notification events for a wide veriety of actions, such as when content is saved or published, when a media item is deleted.

These notifications allow developers to hook into the Umbraco lifecycle and execute custom code in response to these events.

Umbraco Docs : https://docs.umbraco.com/umbraco-cms/reference/notifications

## Umbraco notifications
To handle a Notification you first need a NotificationHandler class that implements the INotificationHandler<T> or INotificationAsyncHandler<T>
interface, where T is the type of notification you want to handle.

```cs
public class MyNotificationHandler : INotificationAsyncHandler<ContentSavedNotification>
{
	public Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
	{
		// Your code to handle the notification
	}
}
```

you then need to register you handler in a composer (for doStuff we use static extension methods to seperate things out).

```cs
	builder.AddNotificationAsyncHandler<ContentSavedNotification, MyNotificationHandler>();
```

then when the event fires your code will be called. 

### Custom notifications

You can use the same notification system in your 

own code. To do this you need to create your own notification class that implements the INotification interface.

```cs
public class MyCustomNotification : INotification
{
	public string Message { get; set; }
}
```

and then in the relevant place in the code you can pubish the notification using the IEventAggregator.

```cs	
public class MyService
{
	private readonly IEventAggregator _eventAggregator;
	public MyService(IEventAggregator eventAggregator)
	{
		_eventAggregator = eventAggregator;
	}
	public void DoSomething()
	{
		// Your code to do something
		// Publish the notification
		var notification = new MyCustomNotification { Message = "Something happened!" };
		_eventAggregator.Publish(notification);
	}
}
```
