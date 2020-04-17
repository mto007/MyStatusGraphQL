# MyStatusGraphQL
## About 

* ASP.NET Core 3.0 GraphQL API 
* Project status: prototype
* Uses GraphQL for .NET and GraphiQL UI Nuget packages
* Curently uses Entity Framework in memory database


## Usage

https://yourhost:yourport/graphql/

### Features
Report Mental Status anonymously.
Mental status entity contains the following fields:
* status
* statusDate
* city
* postCode
* addInfo
* latitude
* longitude
* age
* sex
* id

Query all mental statuses or one status by id.


### Content

* MyStatusGraphQL.Graphql -namespace contains all GraphQL related classes
* MyStatusGraphQL.Database -namespace contains Db-context
* MyStatusGraphQL.Controllers -namespace contains the controller
* MyStatusGraphQL.Entities -namespace contains the entity
* DataGenerator.cs contains the stub data creation for the project


### Limitations

Curently uses Entity Framework in memory database



