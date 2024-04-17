# Repository / Service pattern

This folder contains a basic repository and service pattern for storing and retrieving data from custom tables in the umbraco database.

## Models 
For this example we have Data Transfer Objects (DTO) and Plain old CRL Objects (POCO). 

 Seperating the DTO models from the modles used in the service code removes a dependency on the database structure from our code. 

 View the [models](Models)

 ## Migrations
 The Migrations run when Umbraco starts up, and can be used to 'new up' and update your database.

 this example is using the core umbraco migrations, which give you greater control but require a bit more code than the [Package migrations](https://docs.umbraco.com/umbraco-cms/extending/packages/packages-on-umbraco-cloud).

 View [Migrations](Migrations)

## Mapping
 
  in this example the DTO and POCO models are very similar, with only two enum values being represented by integers in the DB. 

  using the Umbraco Mapper we can define how to map from one to another.

  **Other mappers are avalible and if you don't want to tie your code that close to Umbraco you can use them*

  View the [Mapping definitions](Mapping)
 
## Repository

The basic repository is setup as a base class and contains the core Create, Read, Update and Delete (CRUD) methods you need to get and store data in the database. 

by inhertiing from the base class we save a lot of reprition in our code. 

view the [repositories](Persistence)

## Services 

The Services layer like the repository uses a base class so we don't have to repeat a lot of code. 

view [services](Services]

