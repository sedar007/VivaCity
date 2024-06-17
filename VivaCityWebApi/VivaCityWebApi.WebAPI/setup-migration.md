# Installation de dotnet ef
> dotnet tool install --global dotnet-ef
> dotnet-ef -v

# Parametrage des secrets
Clic droit sur csproj > Manage User Secrets
```
{
  "SQLConnectionString": "Host=localhost;Port=5432;Database=VivaCityWebApi;Username=VivaCityWebApi;Password=PASSWORD"
}
```

# Creation d'une migration
cd VivaCityWebApi.DataAccess
dotnet-ef migrations add Initial -s ../VivaCityWebApi.WebAPI
