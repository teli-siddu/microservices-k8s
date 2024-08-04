# Architecture Overview

## Solution Structure

The solution is organized into multiple projects representing different layers of Clean Architecture:

1. **Core Layer (`ProductService.Core`)**
   - **Purpose**: Contains domain entities, aggregates, domain events, and business rules.
   - **Dependencies**: None.

2. **Application Layer (`ProductService.Application`)**
   - **Purpose**: Contains application services, use cases, DTOs, and business logic orchestration.
   - **Dependencies**: References `ProductService.Core`.

3. **Infrastructure Layer (`ProductService.Infrastructure`)**
   - **Purpose**: Provides concrete implementations for data access, external services, and infrastructure concerns.
   - **Dependencies**: References `ProductService.Core`, optionally `ProductService.Application`.

4. **Presentation Layer (`ProductService.Api`)**
   - **Purpose**: Contains controllers, API endpoints, and user interface logic.
   - **Dependencies**: References `ProductService.Application`.

## Dependency Flow

- **Core Layer**: No external dependencies.
- **Application Layer**: Depends on Core Layer.
- **Infrastructure Layer**: Depends on Core Layer, optionally on Application Layer.
- **Presentation Layer**: Depends on Application Layer.

## Key Components

### Core Layer
- **Entities**: Defines domain entities and business logic.
- **Interfaces**: Declares repository interfaces and other domain services.

### Application Layer
- **Commands and Queries**: Contains handlers and data transfer objects (DTOs).
- **Services**: Implements business logic orchestration.

### Infrastructure Layer
- **Repositories**: Implements data access and repository interfaces.
- **Persistence**: Manages database context and external integrations.

### Presentation Layer
- **Controllers**: Exposes API endpoints and interacts with Application Layer.
