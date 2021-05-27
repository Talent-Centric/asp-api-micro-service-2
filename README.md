## SERVICE1

### ABOUT

This is a customer API in charge of performing CRUD operations with the DB. It is used as SERVICE 2 out of 2 of our Microservice architecture.

### RUN THE SERVICE
Create database with the following name:(microservicesdb)
1. dotnet restore
2. dotnet ef migrations add InitialCreate
3. dotnet ef database update
4. dotnet run
### API DOC
The following are the API endpoints
* https://localhost:5002/products/find/product/all
* https://localhost:5002/products/find/product/{id}
* https://localhost:5002/products/create/product
* https://localhost:5002/products/update/product
* https://localhost:5002/products/delete/product

