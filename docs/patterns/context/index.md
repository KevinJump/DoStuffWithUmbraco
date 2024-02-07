# Pattern: Context,Repository,Store,Resource

## What it is ?
Communicating between the front end javascript code, and the backend c# code, requires a number of diffrent peices to exist. 

The Context is the 'service' that your front end elements us to start communication the repository handles data in and out of your store, which in turn manages some of the state and data of your front end application.

The Resource is often the bridge between the front end and the server (its where the http requests happen.)

## How it works 

When you want to get some information from the server, you call a context. The context will (via the repo and store) get the data and likely set an observable value on the context itself. 

Anything in your application might be observing the value, and when it is set, that will trigger code on your element(s) to update their own values and the UI. meaning changes are reflected back to the user. 

### Resources
Resources prefreably are auto generated (by the openapi-typescript-codegen tool). These classes are responsible for getting data to and from the server.

By autogenerating from the OpenApi Specification of your c# controllers you can be sure the front end models and calls will match what your backend can produce.

See [Autogenerating from your API](../../tools/openapi-gen.md)

## Things you need
The context,repo,store,resource pattern, has quite a few bits to
it, but once they are fitted together it is does all work. and isn't
to hard to update.

- [Context](../../../src/DoStuff.Client/assets/src/context/)
- [Repository](../../../src/DoStuff.Client/assets/src/repository/)
- [Store](../../../src/DoStuff.Client/assets/src/repository/sources/)
- [Resources](../../../src/DoStuff.Client/assets/src/api/)

## Things to Note

Authentication is a thing.
