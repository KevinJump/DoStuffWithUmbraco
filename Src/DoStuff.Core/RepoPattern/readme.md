# Simple Repository / Service Pattern

This is a Simple repository / Service pattern for Umbraco.

it provides the basics of how to structure your repository,
and service - how to pass the scope between them and how 
to mange the 'Ambient' scope of queries. 

## Repository
the basic repository is setup in a base class that means 
we can inherit and extend as needed. 

For this example the model stored in the DB is the model 
we want to work with, (no mapping)

See the [Persistance Folder](Persistance)

## Serivice
Similary the service is based on a base service that 
hooks into our repository via an interface

See the [Services Folder](Services)



#todo - a bit more documentation on this!
