# [AmperApiClient.NET](https://www.nuget.org/packages/AmperApiClient.NET/)

Nuget Package for communicating with Amplifier API.

## Requirements

.NET 5.0
.NET Core 3.1
.NET Framework 4.5.2

## Install

You can add this package to your project by using:

- Package Manager Console in Visual Studio

  `Install-Package AmperApiClient.NET`

- .NET CLI

  `dotnet add package AmperApiClient.NET`

- add it directly to your .csproj file

  ```xml
  <ItemGroup>
      <PackageReference Include="AmperApiClient.NET" Version="1.1.174" />
  </ItemGroup>
  ```

## Getting Started

### [Example Project](https://bitbucket.org/amplifierspzoo/amper-translator-example)

```cs
using Amplifier;
```

- Create `AmplifierJWTAuth` object with your _username_ and _password_ and _url_ (url of your endpoint)

```cs
AmplifierJWTAuth amplifierJWTAuth = new AmplifierJWTAuth(USERNAME, PASSWORD, URL);
```

- Use it's `getToken()` method to authenticate and get your JWT Token

```cs
b2BWSConfig.JWTToken = await amplifierJWTAuth.getToken();
```

- Add AMPER WS URL

```cs
b2BWSConfig.b2BWSUrl = "https://example-amper-b2b-ws.com"
```

- Create an import class where you can:
  - fetch data you want to send
  - map it to Amplifier classes (`Product`, `Settlement`...)
  - use `Backend` methods to send it
- When creating `Backend` pass `WSConfig` with your _JWTToken_ and _B2BWSUrl_ you wish to communicate with 
