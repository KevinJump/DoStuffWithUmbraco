# Background tasks. 
In Umbraco 8 there where background task processes that allowed you to run code in the 'background' of the site - really these where within requests of the site. 

In asp.net core there is more comprehensive background task management. 
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-5.0&tabs=visual-studio

within Umbraco there are a number helper classes/services to help with the execution of tasks in the background. 

## [x] Single background task
Code : [/BackgroundQueuingTask.cs](./BackgroundQueuingTask.cs)
Queue some code to run in the background - _internally this is how the Examine indexes are rebuilt on a background thread._

to access the background queue, inject `IBackgroundTaskQueue` into your service/class

then you can add items to the queue. 
```
_backgroundTaskQueue.QueueBackgroundWorkItem(
    cancellationToken => DoBackgroundThing(message, cancellationToken));
```

The method that you push into the queue needs to return a task. 

```
private Task DoBackgroundThing(string message, CancellationToken cancellationToken)
```

## [ ] Recurring tasks.
In theory you should be able to impliment code that inherits from `RecurringHostedServiceBase` but this is not currently possible in the latest nightly build (9.0.0-beta001.20210307.3)



