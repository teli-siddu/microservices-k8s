ShoppingSolution/
│
├── src/
│   ├── ApiGateway/
│   │   ├── ApiGateway.csproj
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── ...
│   │
│   ├── Services/
│   │   ├── ProductService/
│   │   │   ├── ProductService.csproj
│   │   │   ├── Controllers/
│   │   │   │   └── ProductController.cs
│   │   │   ├── Models/
│   │   │   │   └── Product.cs
│   │   │   ├── Commands/
│   │   │   │   └── CreateProductCommand.cs
│   │   │   ├── CommandHandlers/
│   │   │   │   └── CreateProductCommandHandler.cs
│   │   │   ├── Queries/
│   │   │   │   └── GetProductQuery.cs
│   │   │   ├── QueryHandlers/
│   │   │   │   └── GetProductQueryHandler.cs
│   │   │   ├── Repositories/
│   │   │   │   └── IProductRepository.cs
│   │   │   ├── Infrastructure/
│   │   │   │   ├── Database/
│   │   │   │   │   └── ProductDbContext.cs
│   │   │   │   ├── ServiceBus/
│   │   │   │   │   └── ServiceBusClient.cs
│   │   │   └── ...
│   │   │
│   │   ├── OrderService/
│   │   │   ├── OrderService.csproj
│   │   │   ├── Controllers/
│   │   │   │   └── OrderController.cs
│   │   │   ├── Models/
│   │   │   │   └── Order.cs
│   │   │   ├── Commands/
│   │   │   │   └── CreateOrderCommand.cs
│   │   │   ├── CommandHandlers/
│   │   │   │   └── CreateOrderCommandHandler.cs
│   │   │   ├── Queries/
│   │   │   │   └── GetOrderQuery.cs
│   │   │   ├── QueryHandlers/
│   │   │   │   └── GetOrderQueryHandler.cs
│   │   │   ├── Repositories/
│   │   │   │   └── IOrderRepository.cs
│   │   │   ├── Infrastructure/
│   │   │   │   ├── Database/
│   │   │   │   │   └── OrderDbContext.cs
│   │   │   │   ├── ServiceBus/
│   │   │   │   │   └── ServiceBusClient.cs
│   │   │   └── ...
│   │   │
│   │   ├── CustomerService/
│   │   │   ├── CustomerService.csproj
│   │   │   ├── Controllers/
│   │   │   │   └── CustomerController.cs
│   │   │   ├── Models/
│   │   │   │   └── Customer.cs
│   │   │   ├── Commands/
│   │   │   │   └── CreateCustomerCommand.cs
│   │   │   ├── CommandHandlers/
│   │   │   │   └── CreateCustomerCommandHandler.cs
│   │   │   ├── Queries/
│   │   │   │   └── GetCustomerQuery.cs
│   │   │   ├── QueryHandlers/
│   │   │   │   └── GetCustomerQueryHandler.cs
│   │   │   ├── Repositories/
│   │   │   │   └── ICustomerRepository.cs
│   │   │   ├── Infrastructure/
│   │   │   │   ├── Database/
│   │   │   │   │   └── CustomerDbContext.cs
│   │   │   │   ├── ServiceBus/
│   │   │   │   │   └── ServiceBusClient.cs
│   │   │   └── ...
│   │   │
│   │   └── InventoryService/
│   │       ├── InventoryService.csproj
│   │       ├── Controllers/
│   │       │   └── InventoryController.cs
│   │       ├── Models/
│   │       │   └── Inventory.cs
│   │       ├── Commands/
│   │       │   └── CreateInventoryCommand.cs
│   │       ├── CommandHandlers/
│   │       │   └── CreateInventoryCommandHandler.cs
│   │       ├── Queries/
│   │       │   └── GetInventoryQuery.cs
│   │       ├── QueryHandlers/
│   │       │   └── GetInventoryQueryHandler.cs
│   │       ├── Repositories/
│   │       │   └── IInventoryRepository.cs
│   │       ├── Infrastructure/
│   │       │   ├── Database/
│   │       │   │   └── InventoryDbContext.cs
│   │       │   ├── ServiceBus/
│   │       │   │   └── ServiceBusClient.cs
│   │       └── ...
│   │
│   └── ...
│
├── infrastructure/
│   ├── K8s/
│   │   ├── product-service-deployment.yaml
│   │   ├── order-service-deployment.yaml
│   │   ├── customer-service-deployment.yaml
│   │   ├── inventory-service-deployment.yaml
│   │   └── ...
│   │
│   ├── Docker/
│   │   ├── ProductService/
│   │   │   └── Dockerfile
│   │   ├── OrderService/
│   │   │   └── Dockerfile
│   │   ├── CustomerService/
│   │   │   └── Dockerfile
│   │   ├── InventoryService/
│   │   │   └── Dockerfile
│   │   └── ...
│   │
│   └── ...
│
├── scripts/
│   ├── deploy.sh
│   ├── build.sh
│   └── ...
│
├── .gitignore
├── README.md
└── ShoppingSolution.sln
