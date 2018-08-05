using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

public static class ConfigureAuthenticationExtension
{
    public static void ConfigureAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        //-----Use cookies with Identity -----
        //services.AddIdentity<ApplicationUser, IdentityRole>()
        //.AddEntityFrameworkStores<ApplicationDbContext>()
        //.AddDefaultTokenProviders();

        // if you want to tweak the Identity cookie settings (optional)
        //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");


        // -----Use cookies without Identity ------

        //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        //.AddCookie(options =>
        //{
        //    options.LoginPath = "/Account/LogIn";
        //    options.LogoutPath = "/Account/LogOff";
        //});


        // -----JWT Bearer Authentication -----
        
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "Jwt";
            options.DefaultChallengeScheme = "Jwt";
        }).AddJwtBearer("Jwt", options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = "http://localhost:5000",
                ValidAudience = "http://localhost:5000",

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256")),
                ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
            };
        });

        /// ----- External logins - Facebook , Google  --------

        services.AddAuthentication().AddFacebook(options =>
        {
            options.AppId = configuration["Authentication:Facebook:AppId"];
            options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
        });

        services.AddAuthentication().AddGoogle(options =>
        {
            options.ClientId = configuration["Authentication:Google:ClientId"];
            options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
        });

        ///---- OpenID Connect (OIDC) authentication ------

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddOpenIdConnect(options =>
        {
            options.Authority = configuration["auth:oidc:authority"];
            options.ClientId = configuration["auth:oidc:clientid"];
        });

        /// ----- Microsoft Account authentication -------

        services.AddAuthentication()
        .AddMicrosoftAccount(options =>
        {
            options.ClientId = configuration["auth:microsoft:clientid"];
            options.ClientSecret = configuration["auth:microsoft:clientsecret"];
        });

        ///----- Twitter authentication----------

        services.AddAuthentication()
        .AddTwitter(options =>
        {
            options.ConsumerKey = configuration["auth:twitter:consumerkey"];
            options.ConsumerSecret = configuration["auth:twitter:consumersecret"];
        });
    }
}