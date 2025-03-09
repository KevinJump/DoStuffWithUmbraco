# Do Stuff with Umbraco 💪 - Fifteen.

This is the v15 edition of the DoStuffWithumbraco Repository

Tips, Patterns, and code that will help you achive things with the Umbraco codebase.

## Where is X

If you are new to the webcomponents, typescript world of Umbraco v14 and beyond, quite a lot has changed on the client side.

## Snippets

Quick examples of how to do things.

### Server Code (C#)

- [ ] Compositions (Dependency Injection)
- [ ] Notifications / Handlers
- [ ] Options (reading/using appsettings)
- [ ] Migrations
- [ ] Health Checks
- [ ] WebHooks
- [ ] Background Tasks

### Front End (Typescript and Lit)

- [ ] Section
- [ ] Dashboards
- [ ] Actions (Menu Items)
- [ ] Workspaces
- [ ] Trees
- [ ] Property editors
- [ ] SignlaR
- [ ] Modal dialogs
- [ ] Localization
- [ ] Custom Icons
- [ ] Conditions
- [ ] Permissions

### Concepts

Not always umbraco, but how some of the Lit/Web-Components/Typescript things fit together with umbraco development.

- [ ] Manifest Filters (loading package from c#)
- [ ] Components
- [ ] Contexts
- [ ] Repositories
- [ ] Stores

## Patterns

Slighty more involved concepts and code that require a few diffrent things

- [ ] Database Repository / Service Pattern
- [ ] Management API/Swagger Pattern

# Project Structure

This project is structured as if you are building something large with many
moving parts, splitting the project helps you manage that, and swap bits in
and out as versions of things change.

- **DoStuff.Client** - Client Library for the front end typescript/api
- **DoStuff.Core** - Core backend stuff like databases, services, etc.
- **DoStuff** - A Parent solution, so you include/publish this one.
- **DoStuff.Website** - A website where everything runs / is included.
