# Do Stuff With Umbraco 8

A Collection of patterns and samples of how to do things in
umbraco 8.

this library is just a collection of things that I have needed
to do/explain/remember while developing sites and packages for
Umbraco, its by no means complete, but hopefully it's helpful.

On the whole these are minimal implimentations of things - more
of a jumping off point then a complete reference. 

# Snippets
- [Migrations](/Src/DoStuff.Core/Migrations)
- [Custom Sections](/Src/DoStuff.Core/Sections)
- [Custom Trees](/Src/DoStuff.Core/Trees)
- [Dashboard](/Src/DoStuff.Core/App_Plugins/DoStuff.Dashboard)
- [ContentApp](/Src/DoStuff.Core/ContentApp)
- [HealthChecks](/Src/DoStuff.Core/HealthChecks)
- [Background Tasks](/Src/DoStuff.Core/BackgroundTasks)
- [File Upload](/Src/DoStuff.Core/FileUpload)
- [File Download](/Src/DoStuff.Core/FileDownload)
- [SignalR](/Src/DoStuff.Core/SignalR)

# Patterns
*A bit more involved, combining some concepts*

- [Repo/Service Pattern](/Src/DoStuff.Core/RepoPattern)

## Project Structure
The Project consists of two main elements 

### DoStuff.Core 
The Core library has all the code examples in, for things
like sections, migrations etc. you should be able to see 
how things work and lift them from this section.

*there is a gulp script to copy files from app_plugins to the site, so 
mostly everything is in this project.*

### DoStuff.Site
This is the umbraco site, Samples of how to do things in Views and Partials
will live in this project (when we do some!)



