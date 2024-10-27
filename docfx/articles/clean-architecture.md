# Clean Architecture

## Key Layers and Responsibilities

1. Presentation Layer (Web API):

Handles HTTP requests and responses.
Maps HTTP requests to application layer commands and queries.
Maps application layer responses to HTTP responses.
Contains minimal logic, focusing on routing, serialization, and deserialization.

2. Application Layer:

Contains the business logic and application workflows.
Defines use cases, commands, queries, and their handlers.
Orchestrates interactions between the domain layer and the infrastructure layer.
Does not depend on the presentation layer.

3. Domain Layer:

Contains the core business logic and domain entities.
Defines aggregates, value objects, domain events, and repositories.
Is independent of other layers.

4. Infrastructure Layer:

Contains implementations for persistence, messaging, and external integrations.
Provides implementations for interfaces defined in the application and domain layers.


## Example Structure

### Solution Structure

```sh
MyProject
│
├── src
│   ├── MyProject.Api
│   ├── MyProject.Application
│   ├── MyProject.Domain
│   └── MyProject.Infrastructure
│
└── tests
    ├── MyProject.Api.Tests
    ├── MyProject.Application.Tests
    ├── MyProject.Domain.Tests
    └── MyProject.Infrastructure.Tests
```