# HealthChecks

HealthChecks let your users run checks against the health of the umbraco install.

A custom health check can run any code you need to perform the check, and they 
can be scheduled and return their results to people via email. 

## Changes from v8 to NetCore
> **very few** : single method change

1. Composer now uses IUmbracoBuilder
2. the return value of `HealthCheck.GetStatus` method has changes

# See Also 

- Documentation https://our.umbraco.com/documentation/Extending/Health-Check/
- Configuration https://our.umbraco.com/documentation/Reference/Config/HealthChecks/