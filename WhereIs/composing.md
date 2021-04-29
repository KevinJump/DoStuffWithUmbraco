# Composing
In Umbraco 8 composing is how you get your services, dashboards, components and other things into Umbraco in a way that can then be used for things like Dependency Injection. 

In NetCore composing is still there, but now there are different options when it comes to running items at startup.

### 1. Composing is now passed an `IUmbracoBuilder` interface provides access to services, configuration and logging at startup time. 

## Composing in v8

 ```cs
 public class DoStuffRepoPatternComposer : IUserComposer
{
    public void Compose(Composition composition)
    {
        // configuration object for the repos
        composition.RegisterUnique<DoStuffRepoOptions>();

        // register our repository
        composition.RegisterUnique<IDoStuffRepository<MyList>, MyListRepo>();

        // register our service 
        composition.RegisterUnique<MyListService>();

        // component for migration (db creation)
        composition.Components()
            .Append<DoStuffRepoPatternComponent>();
    }
}
```

## Composing in NetCore
> See this in [DoStuff.Core/DoStuffComposer.cs](../src/DoStuff.Core/DoStuffComposer.cs)

```cs
public class DoStuffComposer : IUserComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        // Add Options (see options.md)
        builder.Services.Configure<DoStuffOptions>(builder.Config.GetSection(DoStuffOptions.DoStuffSection));

        // Add Event handlers
        builder.AddNotificationHandler<ServerVariablesParsing, DoStuffServerVariablesNotifcationHandler>();

        // Add Repositories
        builder.Services.AddUnique<DoStuffRepo>();

        // Add services
        builder.Services.AddUnique<DoStuffService>();

    }
}
```

### Composing vs App/Config pipeline
It might be tempting in a NetCore world to add your initialization directly to the app build pipeline. and indeed you can do that in the configure section of startup.cs. 

But in Umbraco this should be avoided, because it could interfere with updates and might effect how other items startup. If you are developing packages you should certainly steer clear of altering any of the core solution files as you have not idea what people might have configured there.

## Composition ordering. 
This works the same way as it does in v8. you can use the `ComposeAfter` and `ComposeBefore` attributes to ensure the order in which your compositions are initialized.

e.g:

```cs
[ComposeAfter(typeof(MyImportantComposer))]
[ComposeBefore(typeof(MyComposerThanNeedsThis))]
public class DoStuffComposer : IUserComposer 
```


## Composing and Runtime level in Netcore
you can no longer limit a composer by runtime level in netcore.

e.g in v8 you would do. 
```cs
[RuntimeLevel(MinLevel = RuntimeLevel.Run)]
public class MyComposer : IComposer {
    ...
}
```

But you cannot do this in NetCore. instead you should use the `INotificationHandler` pattern to run things when umbraco starts up. at this point you can check runtime level.

e.g in NetCore.
```cs
public class MyCustomComposer : IUserComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.AddNotificationHandler<UmbracoApplicationStarting, MyCustomAppStartingHandler>();
    }
}

public class CustomSectionAppStartingHandler : INotificationHandler<UmbracoApplicationStarting>
{
    public void Handle(UmbracoApplicationStarting notification)
    {
        if (notification.RuntimeLevel >= RuntimeLevel.Run) 
        {
            /// do stuff here and umbraco is running (not installing or updating)
        }
    }
}

```

