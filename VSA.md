Here's the recommended clear and organized folder/file structure for your ShoppingCart project using **Vertical Slice Architecture**, **CQRS**, **DDD**, and clearly separating your core domain, adapters, and tests:

```
ShoppingCart/
├── src/
│   ├── Core/
│   │   ├── Domain/
│   │   │   └── Cart/
│   │   │       ├── Cart.cs                 # Aggregate root (immutable)
│   │   │       ├── CartItem.cs             # Entity (immutable)
│   │   │       └── ValueObjects/
│   │   │           ├── CartId.cs
│   │   │           ├── ProductId.cs
│   │   │           └── Quantity.cs
│   │   │
│   │   └── Features/
│   │       ├── AddToCart/
│   │       │   ├── AddToCartCommand.cs     # Immutable DTO
│   │       │   ├── AddToCartHandler.cs     # Handler (pure logic)
│   │       │   ├── ICartRepository.cs      # Driven Port interface
│   │       │   └── CartRepository.cs       # Driven Adapter implementation
│   │       │
│   │       └── GetCart/
│   │           ├── GetCartQuery.cs         # Immutable DTO
│   │           ├── GetCartHandler.cs       # Handler (pure logic)
│   │           ├── CartReadModel.cs        # Immutable DTO
│   │           ├── ICartQueryService.cs    # Driven Port interface
│   │           └── CartQueryService.cs     # Driven Adapter implementation
│   │
│   └── Adapters/
│       ├── WebApi/                         # Driving Adapter (FastEndpoints)
│       │   ├── Endpoints/
│       │   │   ├── AddToCartEndpoint.cs
│       │   │   └── GetCartEndpoint.cs
│       │   └── Program.cs
│       │
│       └── ConsoleApp/                     # Driving Adapter (Console app)
│           └── Program.cs
│
└── tests/
    ├── UnitTests/
    │   ├── DomainTests/
    │   │   └── CartTests.cs
    │   └── HandlerTests/
    │       ├── AddToCartHandlerTests.cs
    │       └── GetCartHandlerTests.cs
    │
    ├── IntegrationTests/
    │   ├── CartRepositoryIntegrationTests.cs
    │   └── CartQueryServiceIntegrationTests.cs
    │
    └── SystemTests/
        ├── WebApiTests.cs
        └── ConsoleAppTests.cs
```

---

## ✅ **Key Points Explained:**

- **Core Domain** (`Core/Domain`) contains aggregates, entities, and value objects. It's pure logic, isolated from infrastructure.
- **Features** (`Core/Features`) are vertical slices (use cases), each containing commands/queries, handlers, ports (interfaces), and adapters (implementations).
- **Adapters** (`Adapters`) live outside the core domain and implement **Ports**:
  - **Driving Adapters:** (`WebApi`, `ConsoleApp`) entry points into the domain.
  - **Driven Adapters:** (`CartRepository`, `CartQueryService`) implementations interacting with databases.
- **Tests** clearly separated by their type:
  - **Unit Tests**: Pure domain logic, behavior-focused tests.
  - **Integration Tests**: Verify adapters against real infrastructure.
  - **System Tests**: End-to-end tests through API endpoints and console interactions.

This folder structure supports the key architectural goal of isolating core business logic from external systems, keeping tests maintainable, and facilitating clear scalability.