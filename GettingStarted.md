## Getting Started
The project should be self contained - if you follow the first
time steps below you will get a project and site. :

### First Time.
- Clean the Web.Config 
  - Blank the `Umbraco.Core.ConfigurationStatus` setting in AppSettings
  - Remove the UmbracoDSN Connection string

- Install Umbraco 
  - Run the Umbraco Install, pick a username, and db type
  - you don't have to (shouldn't) install a starter kit
  
- Run uSync Import
  - from the uSync menu in settings run an import this will bring everything into the project

