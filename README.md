docker run --name db -e POSTGRES_PASSWORD=123 -e POSTGRES_USER=admin -e POSTGRES_DB=rinha -d postgres

Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 2.2.4s