#  Order API Assignment

- Project title: `Order API Assignment`
- Brief description: ASP.NET Core Web API using layered architecture and EF Core Code First.
- Architecture:
  - `Order.ApplicationCore`: entities, models, repository/service interfaces
  - `Order.Infrastructure`: EF DbContext, repositories, services, migrations
  - `Order.API`: controllers, Swagger, dependency injection
- ER diagram summary:
  - `Order` has many `Order_Details`
  - `Order_Details.Order_Id` is the foreign key to `Order.Id`
- Required endpoints:
  - `GET /api/order`
  - `POST /api/order`
  - `GET /api/order/customer/{customerId}`
  - `PUT /api/order/{id}`
  - `DELETE /api/order/{id}`
- Database setup:
  - Mention SQL Server connection string in `Order.API/appsettings.json`
  - Command: `dotnet ef database update --project Order.Infrastructure/Order.Infrastructure.csproj --startup-project Order.API/Order.API.csproj`
- Run instructions:
  - `dotnet build OrderAssignment.slnx`
  - `dotnet run --project Order.API/Order.API.csproj --urls http://localhost:5100`
  - Swagger URL: `http://localhost:5100/swagger/Index.html`
- Submission note:
  - Include placeholder text: `https://github.com/farman-ai/Assignment_RestAPI`

## Test Plan
- Run `dotnet build OrderAssignment.slnx` to ensure the assignment still builds.
- Open Swagger and confirm the required endpoints are visible.


