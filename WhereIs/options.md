# Configuration 
How you access confguration has changed quite a bit in NetCore from Umbraco v8. Configuration now follows the [Configuration is ASP.NET Core pattern](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0). 

Principally all config is code first by convention, and configuration is stored as json in `appsettings.json` file. 

*the final `appsettings.json `file is actually built from a number of files depending on environment eg. you might have a `appsettings.development.json` file that overrides settings while on your dev setup*

# AppSettings
At the basic level you might be use to getting settings from the AppSettings section of your `web.config` file.

## AppSettings in v8
Getting application settings via Configmanager.

```cs
public string GetSomeSetting() {
    return ConfigurationManager.AppSettings["MySetting"];
}
```

## AppSettings in NetCore
Dependency Injection is needed to get the global config

assuming you have your own object in the `appsettings.json` file: 
```json
{
    "MySuperApp" : {
        "MySetting" : "DoSuperThings"
    }
}
```

```cs
public class MySuperClass {

    private readonly IConfiguration _configuration;

    public MySuperClass(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetSomeSetting() {
        return _configuration["MySuperApp:MySetting"];
    }
}
```

# Settings objects
For more complex settings you may wish to load your own config. 

## Custom Settings in v8
In v8 this is possible but a bit more involved. you would typically have some classes to read config files load items into some class which you would then load up into the core config object during composition.

For details see [how uSync8 loads up its config from file](https://github.com/KevinJump/uSync8/tree/v8/8.7-main/uSync8.BackOffice/Configuration)

## Custom Settings in Netcore
thankfully this is much simpler. you custom config lives in `appsettings.json`

```json
{
    "MyCustomConfig" : {
        "Enabled" : true
    }
}
```

```cs
public class MyCustomConfig {

    public static string ConfigSectionName = "MyCustomConfig";

    public bool Enabled { get;set;} = false;

    public bool MagicNumber {get;set;} = 10;

}
```

## Dependency Injection Method:
> See this in [DoStuff.Core/Controllers/DoStuffApiController.cs](../src/DoStuff.Core/Controllers/DoStuffApiController.cs)

*Note this isn't the only option - see [Microsoft docs](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0#hierarchical-configuration-data) for other ways to load this info.*


### 1. Load config via composer 

```cs
public class MyCustomComposer : IUserComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        // Add Options 
        builder.Services.Configure<MyCustomConfig>(builder.Config.GetSection(MyCustomConfig.ConfigSectionName));
    }
}
```

### 2. Inject options in a class/controller

```cs
public class DoStuffApiController : UmbracoAuthorizedApiController
{
    private readonly MyCustomConfig _options;
    
    public DoStuffApiController(IOptions<MyCustomConfig> options)
    {
        _options = options.Value;
        _doStuffService = doStuffService;
    }
}
```

### 3. Access your options from within methods.

```cs
public GetMagicNumber() {
    if (_options.Enabled) return _options.MagicNumber;
    return -1;
}
```

