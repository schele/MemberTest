using MembersTestUmbraco16.Business.Options;
using Umbraco.Cms.Api.Management.Security;

namespace MembersTestUmbraco16.Business.Extensions
{
    public static class BackofficeAuthenticationExtensions
    {
        public static IUmbracoBuilder ConfigureAuthenticationUsers(this IUmbracoBuilder builder)
        {
            builder.Services.ConfigureOptions<EntraIDB2CBackOfficeExternalLoginProviderOptions>();

            builder.AddBackOfficeExternalLogins(logins =>
            {
                //logins.AddBackOfficeLogin(
                //    backOfficeAuthenticationBuilder =>
                //    {
                //        backOfficeAuthenticationBuilder.AddOpenIdConnect(
                //            BackOfficeAuthenticationBuilder.SchemeForBackOffice(EntraIDB2CBackOfficeExternalLoginProviderOptions.SchemeName),
                //            options =>
                //            {
                //                var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();

                //                options.ClientId = configuration["AzureAd:ClientId"];
                //                options.Authority = $"{configuration["AzureAd:Instance"]}/{configuration["AzureAd:TenantId"]}/v2.0";
                //                options.CallbackPath = configuration["AzureAd:RedirectUri"] ?? "/signin-oidc";
                //                options.ClientSecret = configuration["AzureAd:ClientSecret"];

                //                options.ResponseType = OpenIdConnectResponseType.CodeIdToken;
                //                options.UseTokenLifetime = false;
                //                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationType;
                //                options.SignOutScheme = CookieAuthenticationDefaults.AuthenticationType;
                //                options.SaveTokens = true;

                //                options.TokenValidationParameters = new TokenValidationParameters
                //                {
                //                    ValidateIssuer = true,
                //                    ValidIssuer = options.Authority,
                //                    ValidateAudience = true,
                //                    ValidAudience = options.ClientId,
                //                    ValidateLifetime = true,
                //                    NameClaimType = "name"
                //                };

                //                options.Events = new OpenIdConnectEvents
                //                {
                //                    OnRemoteFailure = context =>
                //                    {
                //                        context.HandleResponse();
                //                        context.Response.Redirect("/umbraco/");
                //                        return Task.CompletedTask;
                //                    }
                //                };
                //            });
                //    });
            });

            return builder;
        }
    }
}
