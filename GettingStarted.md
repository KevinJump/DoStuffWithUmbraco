## Getting Started
Getting started with the NetCore build requires you are using the latest nightly builds.

You will need to add the nightly nuget feed to your list of sources 

```
dotnet nuget add source "https://www.myget.org/F/umbraconightly/api/v3/index.json" -n "Umbraco Nightly"
```

### First Time.
Clean the appSettings.json by Removing 'ConnectionString' section from the file

### Build 
```
Dotnet build
```
  
### Run
```
Dotnet Run
```
  
## Install
- you will need a blank SQL Database (not SQLCE)
- install following the prompts enter db details when required.
