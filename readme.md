> Current Umbraco Build : Nightly 9.0.0-beta001.20210307.3

**⚠ This is a work in progress, information nearly right at time of going to press etc.**

# DoStuffWithUmbraco "NetCore" Version

A collection of patterns and samples of how to do things in Umbraco .net core version.

Join us on a journey as we explore the changes in the UniCore version of Umbraco. 
We are working on the latest builds of UniCore, to see how to do things in this brave new world. 

### Build Status
As Umbraco NetCore development evolves things will change, and stuff may move about. at the moment this repo is working from nightly builds, when alphas, betas and Release candidates are available we will update 

# Where is X ?
As we work through examples, we hope to write some 'if you use to do x now do y' type examples:

- [WhereIs X ?](WhereIs/readme.md)

# Snippets
Quick examples of how to do things. We will first replicate the same snippets that live in the [DoStuffInUmbraco](https://github.com/KevinJump/DoStuffWithUmbraco/tree/v8) repo

- [x] [Migrations](./src/DoStuff.Core/Migrations/)
- [x] [Custom Sections](./src/DoStuff.Core/Sections/)
- [x] [Custom Trees](./src/DoStuff.Core/Trees/)
- [x] [ContentApp](./src/DoStuff.Core/ContentApp/)
- [x] [Dashboard](./src/DoStuff.Core/App_Plugins/DoStuff.Dashboard/)
- [x] [HealthChecks](./src/DoStuff.Core/HealthChecks/)
- [ ] Background Task (./src/DoStuff.Core/Background/)
- [ ] File upload
- [ ] File Download
- [ ] SignalR 
- [x] [Overlay Service](./src/DoStuff.Core/App_Plugins/DoStuff.Dashboard/)

# Patterns
A bit more involved combining more concepts

- [ ] Repo/Service pattern


## Project Structure 
The project contains a Umbraco.core site [DoStuff.Core](./src/DoStuff.Site/) and a core library [DoStuff.Core](./src/DoStuff.Core/)

The core library contains the code examples, and samples and things that you might want to do in the back office of umbraco.