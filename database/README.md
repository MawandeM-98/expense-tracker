# PostgreSQL

Phase 1 only needs a database that the API can connect to.

## Create the database

1. Install PostgreSQL and pgAdmin.
2. Open pgAdmin (or `psql`).
3. Create a database named `expense_tracker`.
4. Confirm you can log in as the user in your connection string (often `postgres`).

Example SQL:

```sql
CREATE DATABASE expense_tracker;
```

Tables are not created in Phase 1. Entity Framework migrations start in Phase 2.

## Connection string

Set this in `backend/ExpenseTracker.API/appsettings.Development.json` **or** with user secrets:

```text
Host=localhost;Port=5432;Database=expense_tracker;Username=postgres;Password=YOUR_PASSWORD
```

Never commit a real password.
