# Udemy - Get started with .NET Core IdentityServer4

## 4. Secure api-based website with hybrid grant type authentication flow

- Enrich your _dotnet cli_ with _identityserver4.templates_ executing the command 
    ```
    dotnet new -i identityserver4.templates
    ```
- Check if everything works executing the command
    ```
    dotnet --help
    ```
    You should find these new items:
    ```
    IdentityServer4 with AdminUI                              is4admin                 [C#]              Web/Id
    IdentityServer4 with ASP.NET Core Identity                is4aspid                 [C#]              Web/Id
    IdentityServer4 Empty                                     is4empty                 [C#]              Web/Id
    IdentityServer4 with Entity Framework Stores              is4ef                    [C#]              Web/Id
    IdentityServer4 with In-Memory Stores and Test Users      is4inmem                 [C#]              Web/Id
    IdentityServer4 Quickstart UI (UI assets only)            is4ui                    [C#]              Web/Id
    ```
- Move to _BankOfDotNet.IdentitySvr_ folder end execute the command
    ```
    dotnet new is4ui
    ```
    to add web login components to an existing Identiy Server 4 instance.

### Debugging projects
Using VSCode, start in order:

- BankOfDotNet.IdentitySvr project
- BankOfDotNet.Api project
- BankOfDotNet.MvcClient project

### Test calls

I used [Insomnia](https://insomnia.rest/) to attempt some requests to create customer. Import the _Insomnia_BankOfDotNet_requests.json_ configuration file available that you can find into the root folder from _Application > Preference > Data > Import Data > From File_.