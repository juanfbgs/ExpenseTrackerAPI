# Expense Tracker API

.NET 10 Minimal API with JWT authentication

## Tech Stack

- Framework: .NET 10

- Database: PostgreSQL

- ORM: Entity Framework Core

- Auth: Microsoft.AspNetCore.Authentication.JwtBearer

- Documentation: Scalar.AspNetCore & Microsoft.AspNetCore.OpenApi

## Usage

### Clone Project

```bash
git clone https://github.com/juanfbgs/ExpenseTrackerAPI.git
cd src
```

### Copy local config file and generate key

```bash
cp appsettings.Local.json.example appsettings.Local.json
```

### Restore dependencies

```bash
dotnet restore
```

### Docker Compose Setup

```yml
services:
  db:
    image: postgres:alpine
    environment:
      POSTGRES_USER: pguser
      POSTGRES_PASSWORD: mySecurePassword123
      POSTGRES_DB: expensetrackerdb
    ports:
      - "5432:5432"
    volumes:
      # Format: [volume_name]:[path_inside_container]
      - pgdataexpense:/var/lib/postgresql/data

# You must declare the named volume at the bottom of the file
volumes:
  pgdataexpense:
```

```bash
docker compose up -d
```

### Apply Migrations to the Database

[Install dotnet ef](https://www.nuget.org/packages/dotnet-ef)

```bash
dotnet ef database update
```

### Run the API

```bash
# Option 1: Running from the source directory (/src folder)
dotnet run

# Option 2: Running from the root directory
dotnet run --project src/ExpenseTrackerAPI.csproj
```


