# PostgreSQL local setup

The Docker container and the application both read database settings from `RatingLists_Backend/.env`.

## Start the database

From the repository root, run:

```powershell
docker compose up -d
```

This starts a PostgreSQL container with:

- Host: value from `POSTGRES_HOST` (typically `localhost`)
- Port: value from `POSTGRES_PORT`
- Database: value from `POSTGRES_DB`
- Username: value from `POSTGRES_USER`
- Password: value from `POSTGRES_PASSWORD`

## Stop the database

```powershell
docker compose down
```

To also remove the persisted database volume:

```powershell
docker compose down -v
```

## Environment file

Example values:

```env
POSTGRES_HOST=localhost
POSTGRES_DB=ratinglists_db
POSTGRES_USER=ratinglist_user
POSTGRES_PASSWORD=postgres_ratinglists
POSTGRES_PORT=5432
```

## Connection string

The application builds the PostgreSQL connection string from `RatingLists_Backend/.env` through `EnviromentConfig`.

## Notes

- Data is persisted in the `postgres_data` Docker volume.
- If port `5432` is already in use, change `POSTGRES_PORT` in `RatingLists_Backend/.env`.
- The project does not yet include PostgreSQL data access code. When you are ready, add either EF Core with a compatible PostgreSQL provider version or direct ADO.NET access with `Npgsql`.
