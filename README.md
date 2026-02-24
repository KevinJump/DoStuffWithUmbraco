# DoStuffWithUmbraco 💪 Seventeen

This is the Umbraco v17 version of DoStuffWithUmbraco.

> [!NOTE]
> This is a work in progress - see the checklists below to see what we do and don't have

Tips, Patterms, and code that will help you achive things with the Umbraco code base.

## Where is X (Who moved the cheese)

If you have working with previous versions of Umbraco (v13 or less) and are wondering just where things have gone. then as we progress we want to build a 'if it was this then its now this' section.

- [Where is X](./where/readme.md)

## Snippets

Most of the code in this repository has been kept simple and as detached as possible
so you can see it, and work out how it might work for you.

### Server Code (c#)

- [x] [Compositions](./src/DoStuff.Core/Startup/)
- [x] [Notifications](./src/DoStuff.Core/Notifications/)
- [ ] Options (reading/using settings)
- [x] [Migrations (Database)](./src/DoStuff.Core/Data/Persistance/Migrations/)
- [ ] Health Checks
- [ ] Webhooks
- [ ] Background Tasks
- [x] [Repositories (working with the DB)](./src/DoStuff.Core/Data/Persistance/)
- [x] [Api Controllers](./src/DoStuff.Client/Controllers/)

### Front End (Typescript & Lit)

- [x] [Section](./src/DoStuff.Client/DoStuff-Client/src/section/)
- [x] [Dashboard](./src/DoStuff.Client/DoStuff-Client/src/dashboard/)
- [x] [Menus](./src/DoStuff.Client/DoStuff-Client/src/menus/)
- [x] [Workspaces](./src/DoStuff.Client/DoStuff-Client/src/workspace/)
  - [x] [Views](./src/DoStuff.Client/DoStuff-Client/src/workspace/views/)
  - [x] [Actions](./src/DoStuff.Client/DoStuff-Client/src/workspace/actions/)
  - [x] [Contexts](./src/DoStuff.Client/DoStuff-Client/src/workspace/time-workspace.context.ts)
- [x] [Repositories](./src/DoStuff.Client/DoStuff-Client/src/repository/)
- [x] DataSources
- [ ] Trees
- [ ] [Property Editors](./src/DoStuff.Client/DoStuff-Client/src/editors/)
- [ ] Custom Conditions
- [ ] Permissions
- [x] [Localization](./src/DoStuff.Client/DoStuff-Client/src/lang/)

### Concepts

Not always umbraco, but how some of the Lit/Web-Components/Typescript things fit together with umbraco development.

- [ ] [Manifest Filters (loading packages with c#)](./src/DoStuff.Client/Composers/DoStuffPackageManifestReader.cs)

### Patterns

Slighty more involved concepts and code that require a few diffrent things

- [x] [Database Repo/Service Pattern](./src/DoStuff.Core/Data/)
- [x] [Management API/Swagger Pattern](./src/DoStuff.Client/Composers/)

## Project Stucture.

This project is structured as if you are building something large with many
moving parts, splitting the project helps you manage that, and swap bits in
and out as versions of things change.

- **src/DoStuff.Client** - Client Library for the front end typescript/api
- **src/DoStuff.Core** - Core backend stuff like databases, services, etc.
- **src/DoStuff** - A Parent solution, so you include/publish this one.
- **demo/DoStuff.Website** - A website where everything runs / is included.
