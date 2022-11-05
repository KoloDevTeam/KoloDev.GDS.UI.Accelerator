using KoloDev.GDS.UI.BaseModels.Configuration;
using KoloDev.GDS.UI.Configurators.Base;
using KoloDev.GDS.UI.Configurators.Builders;
using KoloDev.GDS.UI.Helpers;
using KoloDev.GDS.UI.Service;
using KoloDev.GDS.UI.Service.Interface;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.IdentityModel.Logging;
using System.IO.Compression;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KoloDev.GDS.UI.Configurators.Program
{
    /// <summary>
    /// Base UI configurator
    /// </summary>
    public static class BaseUi
    {
        /// <summary>
        /// Adds reccomended services, baseConfiguration can be used to enable/disable
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="baseConfiguration"></param>
        public static void AddKoloDevBaseServices(this WebApplicationBuilder builder, Action<BaseUiConfiguration> baseConfiguration = null)
        {
            var services = builder.Services;

            var baseConfig = new BaseUiConfiguration();
            baseConfiguration?.Invoke(baseConfig);

            var availableOptions = builder.Configuration
                .GetSection("App")
                .Get<AppSettings>();

            services.AddScoped<RazerViewHelper, RazerViewHelper>();
            services.AddScoped<IAppAuthentication, AppAuthenticationService>();
            services.AddScoped<IKeyVault, KeyVaultService>();

            services.AddHttpContextAccessor();
            builder.Services.Configure<AppSettings>
                (builder.Configuration.GetSection("App"));

            services.Configure<AppSettings>(options => builder.Configuration.GetSection("App").Bind(options));

            if (baseConfig.SecurityHeaders)
            {
                builder.WebHost.ConfigureKestrel(config => config.AddServerHeader = false);
            }

            if (baseConfig.UseResponseCompression)
            {
                SharedConfiguration.UseResponseCompression = true;
                services.AddResponseCompression(options =>
                {
                    options.Providers.Add<BrotliCompressionProvider>();
                    options.Providers.Add<GzipCompressionProvider>();
                    options.EnableForHttps = true;
                    options.MimeTypes =
                        ResponseCompressionDefaults.MimeTypes.Concat(
                            new[]{
                                    "image/svg+xml",
                                    "application/javascript",
                                    "application/json",
                                    "application/xml",
                                    "text/css",
                                    "text/html",
                                    "text/json",
                                    "text/plain",
                                    "text/xml"
                            });
                })
                .Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal)
                .Configure<BrotliCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            }

            if (builder.Configuration.GetSection("APPINSIGHTS_INSTRUMENTATIONKEY").Exists())
            {
                builder.Services.AddLogging(options =>
                {
                    options.AddApplicationInsights(builder.Configuration.GetSection("APPINSIGHTS_INSTRUMENTATIONKEY").Value);
                });
            }

            if (baseConfig.UseAntiForgery)
            {
                services.AddAntiforgery();
            }

            if (baseConfig.UseHsts)
            {
                SharedConfiguration.UseHsts = true;
                services.AddHsts(options =>
                {
                    options.Preload = true;
                    options.IncludeSubDomains = true;
                    options.MaxAge = TimeSpan.FromDays(365);
                });
            }

            if (builder.Configuration.GetSection("App:Authentication:AzureAdB2C").Exists() && !string.IsNullOrEmpty(builder.Configuration.GetSection("App:Authentication:AzureAdB2C:TenantId").Value)
                || !string.IsNullOrEmpty(baseConfig.AuthenticationOptions.AzureAdB2C.TenantId))
            {
                SharedConfiguration.UseAuthentication = true;
                builder.AddAzureAdB2C(baseConfig);
            }
            else if (builder.Configuration.GetSection("App:Authentication:AzureAd").Exists() && !string.IsNullOrEmpty(builder.Configuration.GetSection("App:Authentication:AzureAdB2C:TenantId").Value)
                || !string.IsNullOrEmpty(builder.Configuration.GetSection("App:Authentication:AzureAd:TenantId").Value))
            {
                SharedConfiguration.UseAuthentication = true;
                builder.AddAzureAd(baseConfig);
            }
            else
            {
                services.AddControllersWithViews();
            }

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = string.IsNullOrEmpty(availableOptions.ServiceName) ? "applicationCookie_2" : availableOptions.ServiceName;
            });
        }

        /// <summary>
        /// Adds Azure B2C to the project
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void AddAzureAdB2C(this WebApplicationBuilder builder, BaseUiConfiguration configuration)
        {
            var services = builder.Services;

            var availableOptions = builder.Configuration
                            .GetSection("App")
                            .Get<AppSettings>();

            if (string.IsNullOrEmpty(availableOptions.Authentication.AzureAdB2C.Domain))
            {
                availableOptions.Authentication.AzureAdB2C = configuration.AuthenticationOptions.AzureAdB2C;
            }

            if (configuration.AuthenticationOptions.AzureAdB2C.ClientId != string.Empty)
            {
                configuration.AuthenticationOptions.AzureAdB2C.ClientId =
                    availableOptions.Authentication.AzureAdB2C.ClientId;
            }

            if (configuration.AuthenticationOptions.AzureAdB2C.ClientSecret != string.Empty)
            {
                configuration.AuthenticationOptions.AzureAdB2C.ClientSecret =
                    availableOptions.Authentication.AzureAdB2C.ClientSecret;
            }

            if (!string.IsNullOrEmpty(availableOptions.Authentication.AzureAdB2C.Domain))
            {
                services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "App:Authentication:AzureAdB2C");
                services.Configure<OpenIdConnectOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.UsePkce = false;
                    options.ResponseType = "code";
                    options.Scope.Add(availableOptions.Authentication.AzureAdB2C.ClientId);
                    options.ClientSecret = availableOptions.Authentication.AzureAdB2C.ClientSecret;
                    options.ClientId = availableOptions.Authentication.AzureAdB2C.ClientId;
                });
                
                services.Configure<CookieAuthenticationOptions>(options =>
                {
                    options.Cookie.Name = string.IsNullOrEmpty(availableOptions.ServiceName) ? "applicationCookie_2" : availableOptions.ServiceName;
                });
                services.AddControllersWithViews().AddMicrosoftIdentityUI();
            }
        }

        /// <summary>
        /// Adds Azure AD to the project
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        public static void AddAzureAd(this WebApplicationBuilder builder, BaseUiConfiguration configuration)
        {
            var services = builder.Services;

            var availableOptions = builder.Configuration
                            .GetSection("App")
                            .Get<AppSettings>();

            if (string.IsNullOrEmpty(availableOptions.Authentication.AzureAd.Domain))
            {
                availableOptions.Authentication.AzureAd = configuration.AuthenticationOptions.AzureAd;
            }

            if (!string.IsNullOrEmpty(availableOptions.Authentication.AzureAd.Domain))
            {
                services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration, "App:Authentication:AzureAd");
                services.Configure<MicrosoftIdentityOptions>(OpenIdConnectDefaults.AuthenticationScheme, options =>
                {
                    options.UsePkce = false;
                    options.ResponseType = "code";
                    options.ClientSecret = availableOptions.Authentication.AzureAd.ClientSecret;
                    options.ClientId = availableOptions.Authentication.AzureAd.ClientId;
                });
                services.AddControllersWithViews().AddMicrosoftIdentityUI();
            }
        }

        /// <summary>
        /// Configure application
        /// </summary>
        /// <param name="app"></param>
        /// <param name="baseConfiguration"></param>
        public static void ConfigureKoloDevBaseApp(this WebApplication app, Action<BaseUiAppConfiguration> baseConfiguration = null)
        {
            var baseConfig = new BaseUiAppConfiguration();
            baseConfiguration?.Invoke(baseConfig);

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            else
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseExceptionHandler(options =>
                {
                    options.Run(
                        async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            context.Response.ContentType = "text/html";
                            var ex = context.Features.Get<IExceptionHandlerFeature>();
                            if (ex != null)
                            {
                                var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                                await context.Response.WriteAsync(err, CancellationToken.None).ConfigureAwait(false);
                            }
                        });
                });
            }

            if (baseConfig.SecurityHeaders)
            {
                var policyCollection = new HeaderPolicyCollection()
                    .AddFrameOptionsDeny()
                    .AddXssProtectionBlock()
                    .AddContentTypeOptionsNoSniff()
                    .AddStrictTransportSecurityMaxAgeIncludeSubDomains(
                        maxAgeInSeconds: 60 * 60 * 24 * 365 // max age = one year in seconds
                    )
                    .AddReferrerPolicyStrictOriginWhenCrossOrigin()
                    .RemoveServerHeader()
                    .AddCrossOriginOpenerPolicy(builder =>
                    {
                        builder.SameOrigin();
                    })
                    .AddCrossOriginEmbedderPolicy(builder =>
                    {
                        builder.RequireCorp();
                    })
                    .AddCrossOriginResourcePolicy(builder =>
                    {
                        builder.SameOrigin();
                    })
                    .AddContentSecurityPolicy(cspBuilder =>
                    {
                        cspBuilder.AddUpgradeInsecureRequests();
                        cspBuilder.AddBlockAllMixedContent();
                        cspBuilder.AddFontSrc().Self();
                        cspBuilder.AddObjectSrc().None();
                        //cspBuilder.AddFormAction().Self().WithNonce();
                        cspBuilder.AddImgSrc().Self().OverHttps();
                        cspBuilder.AddScriptSrc().Self().WithNonce();
                        cspBuilder.AddStyleSrc().Self().WithNonce();
                        cspBuilder.AddMediaSrc().Self().OverHttps();
                        cspBuilder.AddFrameAncestors().None();
                        cspBuilder.AddBaseUri().Self();
                        cspBuilder.AddFrameSrc().Self();
                        cspBuilder.AddManifestSrc().Self();
                        cspBuilder.AddMediaSrc().Self();
                        cspBuilder.AddConnectSrc().Self();
                        cspBuilder.AddDefaultSrc().None();
                    });

                app.UseSecurityHeaders(policyCollection);
            }

            if (baseConfig.RewriteAccountDeniedTo401)
            {
                app.Use(async (context, next) =>
                {
                    var url = context.Request.Path.Value;
                    if (url != null && url.Contains("/Account/AccessDenied"))
                    {
                        context.Request.Path = "/Error/401";
                    }
                    await next();
                });
            }

            if (baseConfig.UserFriendlyErrorRoutes)
            {
                // This is to set the endpoint of errors, 401,404 etc.
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }

            if (SharedConfiguration.UseResponseCompression)
            {
                app.UseResponseCompression();
            }
            if (SharedConfiguration.UseHsts)
            {
                app.UseHsts();
            }

            if (SharedConfiguration.UseAuthentication)
            {
                app.UseAuthentication();
            }
            app.UseAuthentication();

            app.UseAuthorization();

            if (baseConfig.SetEndpointRouting)
            {
                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            }
        }

        /// <summary>
        /// Create a header menu
        /// </summary>
        /// <param name="app"></param>
        /// <param name="menu"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CreateHeaderMenu(this WebApplication app, Action<HeaderMenuBuilder> menu)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            var headerMenu = new HeaderMenuBuilder();
            menu.Invoke(headerMenu);

            BaseMenuConfiguration.Header.HeaderMenu = headerMenu.PageMenu;
        }

        /// <summary>
        /// Create a footer menu
        /// </summary>
        /// <param name="app"></param>
        /// <param name="menu"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CreateFooterMenu(this WebApplication app, Action<FooterMenuBuilder> menu)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            var footerMenu = new FooterMenuBuilder();
            menu.Invoke(footerMenu);

            BaseMenuConfiguration.Footer.FooterMenu = footerMenu.PageMenu;
        }

        /// <summary>
        /// Add assets to the project
        /// </summary>
        /// <param name="app"></param>
        /// <param name="assets"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AddAssetsToApp(this WebApplication app, Action<AssetInclusionBuilder> assets)
        {
            if (app is null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            var assetBuilder = new AssetInclusionBuilder();
            assets.Invoke(assetBuilder);

            AssetConfiguration.UserJsAssets = assetBuilder.JavaScripts;
            AssetConfiguration.UserCssAssets = assetBuilder.StyleSheets;
        }
    }
}