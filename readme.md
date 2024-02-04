> [!NOTE] 
> Current Umbraco Build : preview-004 (Jan 2024)

# Do Stuff in Umbraco v14 

A collection of patterns and samples of how to do things in Umbraco v14 and beyond.

# Migrating
Tips on getting your code from previous versions to v14 .



# Snippets 
Quick examples of how to do things

## Front End

- [ ] Dashboards
- [ ] Sections
- [ ] Sidebars
- [ ] Menu Items
- [ ] Trees
- [ ] Headerbar Apps
- [ ] Workspaces
- [ ] Localisation


## Backoffice

- [ ] Migrations
- [ ] Health Checks
- [ ] Background Tasks


# Patterns
Longer more involved code where there are a number of pieced to fit together.

## Frond End

- [ ] Context,Repository,Store,Resource
- [ ] Property editors

## Backoffice 
- [ ] The repo/server pattern


# Project Structure

The DoStuff project has been built from the early adopters package template. so has the following structure. 

### - DoStuff.Client:
Front End code, all the typescript, lit and vite settings needed to build the front end of the project.

### - DoStuff.Core:
Backend code, controllers, services, etc that run c# code talk to umbraco or databases.

### - DoStuff.Website
Umbraco v14 website, no custom code in this project - it show you how things look

### - DoStuff
The 'package' project has dependencies on `DoStuff.Client` and `DoStuff.Core` this is the project that is used on the website.