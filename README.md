SmartCharging is a RESTful ASP.NET Core API for capacity control.

## Domain 

* Charge station – has unique identifier, name, multiple connectors (at least one, but not more than 5).  
* Connector – has numerical identifier unique per charge station with, Max current in Amps – value greater than zero.   
* Group – has unique identifier, name, capacity in Amps – value greater than zero. 
Group can contains multiple charge stations.

## Features

* Add a new group 
* Add a new group with charge stations and connectors.

## Prerequirements

* Visual Studio 2019 
* .NET Core 3.0.1 SDK 

## Frameworks used:
* .NET Core 3.0
* ASP .NET Core 3.0
* Entity Framework Core 3.0
* MediatR

### Architecture Overview

The architecture patterns used for this application are based on DDD (Domain-Driven Design) approach 
following the principles of Clean Architecture.


### Domain

It is responsible for representing concepts of the business and business rules.
This contains all entities, interfaces, types and logic specific to the domain layer:

* domain entities with data and behaviour
* value objects
* repository contracts.


### Application

It is dependent on the domain layer, but has no dependencies on any other layer or project. 
This layer defines interfaces that are implemented by outside layers. This layer contains all application logic:

* commands and command handlers.


### Infrastructure

This layer contains classes which are based on interfaces defined within the application layer:

* Data persistence infrastructure: repository implementation
* ORM: Entity Framework Core.

### Web API

This layer is a REST API with ASP.NET Core 3. 
This layer depends on both the Application and Infrastructure layers. However, the dependency on Infrastructure is only to support dependency injection. 
Therefore only *Startup.cs* references Infrastructure.

### Database Configuration
The solution is configured to use a MSSQL DB.

### Next Steps
* Improve the domain models by adding the missing requirements
* Add unit tests and integrations tests
* Setup Travis to run the tests
* Dockerize the application.
