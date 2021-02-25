# [AmperApiClient.NET](https://www.nuget.org/packages/AmperApiClient.NET/) #


Nuget Package for communicating with Amplifier API. 

## Install ##

You can add this package to your project by using:

* Package Manager Console in Visual Studio

    ```Install-Package AmperApiClient.NET```

* .NET CLI

    ```dotnet add package AmperApiClient.NET```

* add it directly to your .csproj file

    ```xml
    <ItemGroup>
        <PackageReference Include="AmperApiClient.NET" Version="1.0.1" />
    </ItemGroup>
    ```

## Getting Started ##

### [Example Project](https://bitbucket.org/amplifierspzoo/amper-translator-example) ###


```cs
using Amplifier;
```
* Create ```AmplifierJWTAuth``` object with your *scope*, *client_secret*, *username* and *password*

```cs
AmplifierJWTAuth amplifierJWTAuth = new AmplifierJWTAuth(SCOPE, CLIENT_SECRET, USERNAME, PASSWORD);
```
* use it's ```getToken()``` method to authenticate and get your JWT Token
    
```cs
b2BWSConfig.JWTToken = await amplifierJWTAuth.getToken();
```
* add B2B WS URL 

```cs
b2BWSConfig.b2BWSUrl = "https://example-amper-b2b-ws.com"
```
* create an import class where you can:
    * fetch data you want to send
    * map it to Amplifier classes (```Product```, ```Settlement```...)
    * use ```B2BWSBackend``` methods to send it
* when creating ```B2BWSBackend``` pass ```B2BWSConfig``` with your *JWTToken* and *B2BWSUrl* you wish to communicate with