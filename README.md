# Udemy - Get started with .NET Core IdentityServer4

## 5. Persist IdentityServer4 authentication data using SqlServer

- Install EntityFramework CLI tools (more info [here](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/dotnet))
    ```
    dotnet tool install --global dotnet-ef
    ```
    If you are using VSCode remember to reference the [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/3.1.3) package to your IdentityServer4 project.
- Move to BankOfDotNet.IdentitySvr folder and launch the following commands
    ```
    dotnet ef migrations add InitialIS4PersistedGrantDBMigration -c PersistedGrantDbContext -o Data/Migrations/IdentityServer/PersistedGrantDb
    dotnet ef migrations add InitialIS4ConfigurationDBMigration -c ConfigurationDbContext -o Data/Migrations/IdentityServer/ConfigurationDb
    ```
- Launch BankOfDotNet.IdentitySvr project to add migrations to your database. Please, remember to configure your Sql Server instance connection string (and don't mind if I'm connecting using _sa_ account... I know that it's wrong, but I'm using a dockerized instance for this demo only. If you need more info, refer to this [guide](https://hub.docker.com/_/microsoft-mssql-server)).

### Debugging projects
Using VSCode, start in order:

- BankOfDotNet.IdentitySvr project
- BankOfDotNet.Api project
- BankOfDotNet.ConsoleClient project

### Test calls

I used [Insomnia](https://insomnia.rest/) to attempt some requests to create customer. Import the _Insomnia_BankOfDotNet_requests.json_ configuration file available that you can find into the root folder from _Application > Preference > Data > Import Data > From File_.