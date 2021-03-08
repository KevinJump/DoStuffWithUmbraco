# Logging
For .net core Umbraco is now using the Microsoft logging libraries/patterns (underneath its still Serilog)

## Logging in v8
Previously, you would inject the logger into your class.
```cs
public MySampleService {

    private readonly ILogger _logger; 

    public MySampleService(ILogger logger)
    {
        _logger = logger;
    }

    public bool SomeSampleMethod(int number) 
    {
        _logger.Debug<MySampleService>("Doing something with {number}", number);
    }

}
```

## Logging in NetCore
> See this in [DoStuff.Core/Services/DoStuffService.cs](../src/DoStuff.Core/Services/DoStuffService.cs)

in UniCore you now inject the ILogger typed to your service/class and create the logger to then call it.

```cs
public MySampleService {

    private readonly ILogger<MySampleService> _logger; 

    public MySampleService(ILogger<MySampleService> logger)
    {
        _logger = logger;
    }

    public bool SomeSampleMethod(int number) 
    {
        _logger.LogDebug("Doing something with {number}", number);
    }
}
```
