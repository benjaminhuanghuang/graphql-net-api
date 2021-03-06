## Reference
- [Api Development In .Net with Graphql](https://www.linkedin.com/learning/api-development-in-dot-net-with-graphql/using-exercise-files)

- GraphQL.Net by Joe McBride (http://github.com/joemcbride)
  Creating GraphQL endpoint supporting queryies, mutation and subscriptions

- [GraphQL.Net example](https://github.com/graphql-dotnet/example-orders)

## Setup
- Install .NET core
```
```
- IDE
  VS code + C# for VS code

- Create project
```
  dotnet new sln
  dotnet new lib -n Orders
  dotnew new web -n Server
  dotnet sln add Orders Server
  dotnet add Server reference Orders       # add reference
  
  dotnet add Orders package GraphQL        # add package
  dotnet add Orders package System.Reactive

  dotnet add Server package Microsoft.AspNetCore.StaticFiles
  dotnet add Server package GraphQL.Server.Transports.AspNetCore      # for websocket
  dotnet add Server package GraphQL.Server.Transports.WebSockets
  ...

  dotnet restore                           # download all libraries
```
- Run server
```
  dotnet run
```

## Configuring the GraphQL Schema
- Create GraphQL types
- Create GraphQL Query object
- Create a Schema object 


## Common GraphQL.NET class
- Schema: Used to define query, mutation and subscriptions
- ObjectGraph<T>: used to expose GraphQL types in schema
- ListGraph<T>: define a GraphQL collection


##