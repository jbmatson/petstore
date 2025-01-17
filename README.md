# **Petstore API Project**

This project is an ASP.NET Core Web API and Angular implementation of the `/pet/findByStatus` endpoint from the Swagger Petstore API. It allows users to fetch a list of pets filtered by their status (`available`, `pending`, or `sold`).

## **Features**

- Fetch a list of pets using the `/pet/findByStatus` API.
- Filter pets based on their status (`available`, `pending`, or `sold`).
- Simple and extensible architecture using:
  - ASP.NET Core for the backend.
  - Entity Framework Core for database access.
    Angular 19 front end with capability of filtering pets by their status (available, pending, sold).

---

## **Getting Started**

### **Prerequisites**

1. .Net 8.0
2. [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or another supported database (e.g., SQLite).
3. [Postman](https://www.postman.com/) or a similar tool to test the API (optional).

---

### **Setup**

1. **Clone the Repository**
```bash
   git clone https://github.com/your-username/petstore-api.git
   cd petstore-api
```
2. Update the connection string in appsettings.json:
```{
      "ConnectionStrings": {
        "PetstoreDatabase": "Server=(localdb)\\mssqllocaldb;Database=PetstoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      }
    }
```
3. Apply migrations to create the database:
```
bash

dotnet ef migrations add InitialCreate
dotnet ef database update
```
4. Run the Application
```
bash
dotnet run
```
The API will be available at http://localhost:5000

### To do list ###
This is still a work in progress unfortunately...
* Pet PhotoUrls property is not yet implemented
* Still need to implement Angular front end - Should allow filtering pets by status, and ideally use Angular Material UI to look nice.
  
