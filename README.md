# ProductsApi

This is a REST API project I built to practice backend development with ASP.NET Core. It's a product management system where you can manage products and categories.

## What I used

- **ASP.NET Core 8** — Web API framework
- **Entity Framework Core 9** — ORM for database access (Code First approach)
- **SQLite** — lightweight database
- **xUnit** — unit testing

## Project structure

The solution is split into 3 projects:

- **ProductsApi** — the Web API layer with controllers and middleware
- **ProductsApi.Service** — the service layer with EF Core models, interfaces, services and DTOs
- **ProductsApi.Tests** — unit tests

I separated the logic into two layers so the service layer has no dependency on the Web API layer. This makes it easier to test and maintain.

## What I implemented

- Full CRUD for Products and Categories
- Filtering products by category, price range (min/max) and availability (IsActive)
- Sorting by price, name or creation date — both ascending and descending
- Pagination with page number and items per page
- Manual mapping from EF models to response DTOs (never exposing EF models directly)
- Dependency Injection using the built-in .NET DI container — all classes depend on interfaces
- Global exception handling middleware that catches unhandled exceptions and returns a JSON error response
- Basic validation using Data Annotations on request DTOs
- Seed data for initial categories and products
- Swagger UI for testing the API

## How to run

1. Clone the repo
2. Open `ProductsApi.sln` in Visual Studio
3. Run migrations in Package Manager Console:
   ```
   Update-Database
   ```
4. Press **F5** — Swagger opens at `https://localhost:7110/swagger`

## API Endpoints

### Categories

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/categories` | Get all categories |
| GET | `/api/categories/{id}` | Get category by ID |
| POST | `/api/categories` | Create a category |
| PUT | `/api/categories/{id}` | Update a category |
| DELETE | `/api/categories/{id}` | Delete a category |

### Products

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/products` | Get all products with filtering, sorting and paging |
| GET | `/api/products/product/{id}` | Get product by ID |
| POST | `/api/products` | Create a product |
| PUT | `/api/products/update/{id}` | Update a product |
| DELETE | `/api/products/{id}` | Delete a product |

### Product query parameters

```
GET /api/products?CategoryId=...&PriceMin=0&PriceMax=1000&IsActive=true&Sort=Price&Direction=Ascending&PageNumber=1&ItemsPerPage=10
```

| Parameter | Values | Description |
|-----------|--------|-------------|
| CategoryId | GUID | Filter by category |
| PriceMin | number | Minimum price |
| PriceMax | number | Maximum price |
| IsActive | true/false | Filter by availability |
| Sort | Price, Name, Date | Sort field |
| Direction | Ascending, Descending | Sort direction |
| PageNumber | number | Page number |
| ItemsPerPage | number | Items per page |

## Tests

I wrote 12 unit tests using xUnit and EF Core InMemory database. Tests cover both happy path (e.g. product exists) and sad path (e.g. product not found) for all CRUD operations on Products and Categories.

To run tests open **Test Explorer** in Visual Studio or run:
```
dotnet test
```
