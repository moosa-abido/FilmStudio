# Web API

## Install dependencies
Install the .NET Core 6 first,
Then install the following dependencies in the project(if not installed in the project):

1. Microsoft.AspNetCore.Authentication.JwtBearer
2. Microsoft.AspNetCore.Mvc.NewtonsoftJson
3. Microsoft.EntityFrameworkCore.InMemory
4. Microsoft.IdentityModel.Tokens
5. System.IdentityModel.Tokens.Jwt
6. Swashbuckle.AspNetCore

## Run the web API
Navigate to the ``FilmAPI`` folder under the ``Web API`` folder, and execute the following command to run the API:

```bash
dotnet run
```

# Client interface
## Install quasar using npm
```bash
npm i -g @quasar/cli
```

## Install the dependencies
Navigate to the Client interface folder and executes the following command
```bash
yarn
# or
npm install
```

## Start the app in development mode (hot-code reloading, error reporting, etc.)
```bash
quasar dev
```



## Build the app for production
```bash
quasar build
```
The final build files are in the dist directory