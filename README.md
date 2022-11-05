# KoloDev GDS UI

KoloDev GDS UI is a scaffolding and templating assistant for GDS based user interfaces written in .NET 6.

## Project setup

- Create a new MVC web application.
- Install the KoloDev.GDS.UI nuget package.
- Delete the default layout folder.
- Add ```@addTagHelper *, KoloDev.GDS.UI``` to _ViewImports.cshtml
- Place the following in appsettings.development.json:

```json
{
  "App": {
    "ServiceName": "Enter service name",
    "ServicePhase": {
      "ShowPhaseBanner": true,
      "Phase": "alpha"
    }
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
```
- In program.cs remove the default code and enter the following:
```csharp
using KoloDev.GDS.UI.Configurators.Program;

var builder = WebApplication.CreateBuilder(args);

builder.AddKoloDevBaseServices();

var app = builder.Build();

app.ConfigureKoloDevBaseApp();

app.Run();
```


## Project configuration options
### App settings
The following options are presented under the key "App".
- **ServiceName** Use this to set the name of the service showing in the navbar and HTML page title.
- **ServiceDescription** Use the to set the description of the service.
- **ServiceUrl** Use this to set the externally facing URL of the service, this will also be used by authentication if enabled.

#### Service Phase
The following settings are set under **App:ServicePhase**.

- **ShowPhaseBanner** Sets whether or not to show the GDS service phase banner.
- **Phase** Sets the current phase of the service. (Available options are alpha, beta, live or retirement.
- **FeedbackLink** Sets the URL of the link users can use to provide feedback.

#### Azure KeyVault and Azure APIM
The following settings are set under **App:Authentication**.

- **KeyVaultName** Sets the name of the Azure KeyVault to access using managed identity.
- **ApimResource** Sets the name of the APIM resource the service should generate access tokens for using managed identity.

#### Application Insights
**ApplicationInsights:InstrumentationKey** Adding this key will enable the inbuilt app insights logging.

#### User authentication using Azure B2C
The following settings are set under **App:Authentication:AzureAdB2C**.

- **Instance** Sets the B2C instance to use.
- **Domain**  Sets the B2C domain to use.
- **TenantId** Sets the B2C tenant ID to use.
- **ClientId** Sets B2C client ID to use.
- **ClientSecret** Sets the B2C client secret to use (Not recommended for production usage)
- **CallbackPath** Sets the callback back to use post sign in.
- **SignedOutCallbackPath** Sets the callback to use post sign out.
- **SignUpSignInPolicyId** Sets the sign up/sign in policy to use.
- **resetPasswordPolicyId** Sets the reset password policy to use.

#### User authentication using Azure AD
The following settings are set under **App:Authentication:AzureAd**

- **Instance** Sets the AD instance to use.
- **Domain**  Sets the AD domain to use.
- **TenantId** Sets the AD tenant ID to use.
- **ClientId** Sets AD client ID to use.
- **ClientSecret** Sets the AD client secret to use (Not recommended for production usage)
- **CallbackPath** Sets the callback back to use post sign in.
- **SignedOutCallbackPath** Sets the callback to use post sign out.
- **SignUpSignInPolicyId** Sets the sign up/sign in policy to use.
- **resetPasswordPolicyId** Sets the reset password policy to use.

### Services configuration

```csharp
builder.AddKoloDevBaseServices(config =>
{
    config.UseResponseCompression = true; // Enable/disable response compression
    config.UseAntiForgery = true; // Enable/disable anti forgery
    config.UseHsts = true; // Enable/disable HSTS
    config.UseAppInsights = true; // Enable/disable App Insights
    config.RewriteAccountDeniedTo401 = true; // Enable/disable rewriting access denied to a 401 route
    config.SecurityHeaders = true; // Enable/disable security headers
    config.SetEndpointRouting = true; // Enable/disable endpoint routing
    config.UserFriendlyErrorRoutes = true; // Enable/disable user friendly HTTP exception routes (404,500 etc.)
    config.AppInsightsLoggingLevel = LogLevel.Information; // Set logging level
    config.AuthenticationOptions.ApimResource = ""; // Set APIM resource
    config.AuthenticationOptions.KeyVaultName = ""; // Set KeyVault name
    config.AuthenticationOptions.AzureAdB2C // Options named after app settings
    config.AuthenticationOptions.AzureAd // Options named after app settings
});
``` 

## Menu configuration

### Header menu
```csharp
app.CreateHeaderMenu(menu =>
{
    menu.WithItem("");
    menu.WithSignoutLink("");
});
```
The following overloads are available:

- (string:name, string:controller, string:action, "bool:visible only when authenticated")
- (string:name, string:controller, string:action, string[]:require roles, "bool:visible only when authenticated")
- (string:name, string:href, "bool:visible only when authenticated")
- (string:name, string:href, string[]:require roles, "bool:visible only when authenticated")

### Footer menu

```csharp
app.CreateFooterMenu(menu =>
{
    menu.WithItem();
    menu.WithContactUs("View path");
    menu.WithCookies("View path");
    menu.WithPrivacy("View path");
    menu.WithTermsAndConditions("View path");
});
```

With item can take the following overloads:

- (string:name, string:controller, string:action)
- (string:name, string:href)

Footer menu items that contain "View path" above take a path to a .cshtml file containing the content you wish to appear in the view.

## View Tag Helpers
The KoloDev GDS UI package includes tag helpers based on the GDS design system, we provide a ``<gds-`` prefixed tag helper for components and typography found at [https://design-system.service.gov.uk/](https://design-system.service.gov.uk/).

## Controller filters
``[Title("")]`` Filter will set the pages HTML title.

``[BackLink("")]`` Filter can take either a HREF or a controller/action to provide a GDS back link on the page.

``[UseGdsJavascipt]`` Filter will activate the GDS JS components on a specified page.

## Helpers

``(ClaimsPrincipal)user.GetClaim("");`` Will retrieve a claim from user identity by name.

``(IPrincipal)user.IsInAnyRole();`` Can be provided with a string array of roles to check if a user is in any of them.

``KeyVaultHelper.GetVaultClient();`` Will return a new key vault client connected using managed identity.

``GetSecret("Key", "KeyVaultName")`` Will return a secret value from key vault using managed identity.

## Extensions

``.WithApimSubscriptionKey("key")`` will append the APIM subscription key header to a FLURL request.

``.WithApiVersion(1)`` Will append the API version header to a FLURL request.

``.DescriptionAttr()`` Will return the description annotation from an enum.

## Services

**IKeyVault** Can be injected to enable getting a secret by key or creating a new key vault client.

**IAppAuthentication** Can be injected to enable generation of an APIM access token.

## Bundled pages

### Error pages

Error pages can be overridden by creating a [name].cshtml file in the Views/ErrorPages directory of your project.

- BadRequestError.cshtml
- ForbiddenError.cshtml
- GenericError.cshtml
- InternalServerError.cshtml
- MethodNotAllowedError.cshtml
- NotFoundError.cshtml
- NotImplementedError.cshtml
- ServiceUnavailableError.cshtml
- UnauthorisedError.cshtml

### Help and information pages

Help and information pages can be overridden by creating a [name].cshtml file in the Views/HelpAndInformation directory of your project.

These pages support rendering content via the footer menu creator. You can give the view.cshtml location of your HTML/Text content and it will be rendered inside of these views.

- ContactUs.cshtml
- Cookies.cshtml
- Privacy.cshtml
- TermsAndConditions.cshtml

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
[GNU GENERAL PUBLIC LICENSE v3](https://www.gnu.org/licenses/gpl-3.0.en.html)