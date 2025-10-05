# CalorieTracker

This project aims to handle user nutritional tracking. This is an ASP.NET Core web app using Razor Pages, Bootstrap, jQuery, and validation libraries, managed with LibMan. This project also uses SQL Server LocalDB with Entity Framework Core migrations to host its database.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them. For example:

- .NET 9.0 (https://dotnet.microsoft.com/en-us/download/dotnet/9.0) 
- .NET SDK v3.1 (https://dotnet.microsoft.com/en-us/download/dotnet/3.1)
- SQL Server Express LocalDB v16.0 (https://aka.ms/sqllocaldb)
- libman v3.0.71 (Use dotnet tool install -g Microsoft.Web.LibraryManager.Cli)
- Recommended : C# for Visual studio code, .NET Install tool, C# Dev Kit

### Installing

A step-by-step series of examples that tell you how to get a development environment running.

1. Clone the repository:
```git clone https://github.com/joelbevenour07/CalorieTracker```

2. Navigate to the project directory:
    ```
    cd CalorieTracker
    ```
3. Restore NuGet Packages
    ```
    dotnet restore

    ```

4. Install the required packages with libman:
    ```
    libman init
    libman restore

    ```

5. Start the LocalDB instance
    ```
    sqllocaldb start mssqllocaldb   

    To stop:
    sqllocaldb stop mssqllocaldb

    For more info:

    sqllocaldb i mssqllocaldb

6. Restore database migrations and Run with dotnet
   ```
   dotnet ef database update
   dotnet run
   Open localhost:5001/ or localhost:5000/
   ```


## Built With

- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/overview?view=aspnetcore-9.0) - The web framework used
- [SQL Server Express LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver17) - Database


## Authors

- **Joel Bevenour** - *Backend/Frontend Development*
- **John Campbell** - *Frontend Development*
- **Krisvin Mathew** - *Frontend Development*


