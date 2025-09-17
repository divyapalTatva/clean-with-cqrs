# CleanCQRSDemo

A comprehensive .NET solution demonstrating **Clean Architecture** principles with **CQRS (Command Query Responsibility Segregation)** pattern implementation. This project showcases proper separation of concerns across multiple layers for enhanced maintainability, testability, and scalability.

## 🏗️ Architecture Overview

This solution follows Clean Architecture principles with clear dependency direction flowing inward toward the Domain layer:

```
┌─────────────────┐    ┌─────────────────┐
│   Web API       │    │  Infrastructure │
│  (Presentation) │    │    (Data)       │
└─────────┬───────┘    └─────────┬───────┘
          │                      │
          ▼                      ▼
┌─────────────────────────────────┐
│         Application             │
│    (Business Logic)             │
└─────────────┬───────────────────┘
              ▼
┌─────────────────────────────────┐
│           Domain                │
│     (Core Business)             │
└─────────────────────────────────┘
```

## 📁 Solution Structure

```
CleanCQRSDemo/
│
├── CleanCQRS.Api/                 # 🌐 API Layer (Presentation)
│   ├── Controllers/               # REST API controllers
│   ├── Middleware/                # Custom middleware
│   ├── Program.cs                 # Application entry point
│   ├── appsettings.json           # Configuration settings
│   └── Dependencies/              # DI container registrations
│
├── CleanCQRS.Application/         # 📋 Application Layer
│   ├── Abstractions/              # Interfaces & contracts
│   │   ├── Repositories/          # Repository interfaces
│   │   ├── Services/              # Service interfaces
│   │   └── Common/                # Shared abstractions
│   ├── Contributors/              # Business logic implementations
│   │   ├── Commands/              # Write operations (CQRS)
│   │   ├── Queries/               # Read operations (CQRS)
│   │   └── Handlers/              # Command/Query handlers
│   ├── DTOs/                      # Data Transfer Objects
│   ├── Mappings/                  # Object mapping profiles
│   └── Dependencies/              # Application DI setup
│
├── CleanCQRS.Domain/              # 🏛️ Domain Layer (Core)
│   ├── Entities/                  # Domain entities
│   ├── ValueObjects/              # Value objects
│   ├── Enums/                     # Domain enumerations
│   ├── Events/                    # Domain events
│   ├── Exceptions/                # Domain-specific exceptions
│   └── Common/                    # Shared domain logic
│
└── CleanCQRS.Infrastructure/      # 🔧 Infrastructure Layer
    ├── Data/                      # Data access implementation
    │   ├── Context/               # Database context
    │   ├── Repositories/          # Repository implementations
    │   └── Migrations/            # Database migrations
    ├── Services/                  # External service implementations
    ├── Configuration/             # Infrastructure configuration
    └── Dependencies/              # Infrastructure DI setup
```

## 🎯 Key Features

- ✅ **Clean Architecture**: Strict separation of concerns with proper dependency inversion
- ✅ **CQRS Pattern**: Separate command and query models for optimal performance
- ✅ **Dependency Injection**: Comprehensive IoC container setup across all layers
- ✅ **Entity Framework Core**: Modern ORM with Code-First approach
- ✅ **AutoMapper**: Automatic object-to-object mapping
- ✅ **MediatR**: In-process messaging for decoupled command/query handling
- ✅ **Swagger/OpenAPI**: Auto-generated API documentation
- ✅ **Configuration Management**: Environment-specific settings support
- ✅ **Error Handling**: Global exception handling with proper HTTP responses

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later
- [SQL Server](https://www.microsoft.com/sql-server) (LocalDB, Express, or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)

### Installation & Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/CleanCQRSDemo.git
   cd CleanCQRSDemo
   ```

2. **Restore NuGet packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   Edit `CleanCQRS.Api/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CleanCQRSDemo;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply database migrations**
   ```bash
   dotnet ef database update --project CleanCQRS.Infrastructure --startup-project CleanCQRS.Api
   ```

5. **Run the application**
   ```bash
   cd CleanCQRS.Api
   dotnet run
   ```

6. **Access the API**
   - **API Endpoint**: `https://localhost:7001` or `http://localhost:5000`
   - **Swagger UI**: `https://localhost:7001/swagger`

## 🏛️ Architecture Principles

### Domain Layer (Core)
- Contains enterprise business rules and entities
- No dependencies on external frameworks
- Pure C# classes with business logic
- Domain events for cross-aggregate communication

### Application Layer (Use Cases)
- Implements application-specific business rules
- Contains command and query handlers (CQRS)
- Defines interfaces for external dependencies
- Orchestrates domain objects to fulfill use cases

### Infrastructure Layer (External Dependencies)
- Implements interfaces defined in Application layer
- Handles data persistence, external APIs, file systems
- Contains EF Core DbContext and repository implementations
- Framework-specific implementations

### API Layer (Presentation)
- Handles HTTP requests and responses
- Contains controllers and middleware
- Minimal business logic (delegated to Application layer)
- API documentation and validation

## 📋 CQRS Implementation

### Commands (Write Operations)
```csharp
public class CreateContributorCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CreateContributorHandler : IRequestHandler<CreateContributorCommand, int>
{
    // Implementation
}
```

### Queries (Read Operations)
```csharp
public class GetContributorQuery : IRequest<ContributorDto>
{
    public int Id { get; set; }
}

public class GetContributorHandler : IRequestHandler<GetContributorQuery, ContributorDto>
{
    // Implementation
}
```

## 📦 Key Dependencies

| Package | Purpose | Layer |
|---------|---------|-------|
| `MediatR` | CQRS implementation | Application |
| `Entity Framework Core` | ORM | Infrastructure |
| `Swashbuckle.AspNetCore` | API documentation | API |
| `Microsoft.Extensions.DependencyInjection` | IoC container | All layers |

## 🔧 Configuration

The application supports multiple environments through `appsettings.{Environment}.json`:

- `appsettings.json` - Base configuration
- `appsettings.Development.json` - Development overrides
- `appsettings.Production.json` - Production overrides

## 📝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 🤝 Acknowledgments

- Clean Architecture by Robert C. Martin
- CQRS pattern by Greg Young
- Domain-Driven Design by Eric Evans

---

**Happy Coding!** 🚀
