using AuthService.API.Services;
using AuthService.Domain.Entities;
using AuthService.Domain.IRepositories;
using AuthService.Domain.Options;
using AuthService.Persistense;

namespace AuthService.API.Extensions;

public static class ServiceCollection
{
    public static WebApplicationBuilder AddBearerAuthentitication(this WebApplicationBuilder builder) {
        
        builder.Services.AddAuthentication(a =>
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(
        x =>
        {
            x.RequireHttpsMetadata = false;
            x.SaveToken = true;
            x.UseSecurityTokenValidators = true;

            x.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                    builder.Configuration["Authentication:TokenPrivateKey"]!)),
                ValidIssuer = builder.Configuration["Authentication:Issuer"],
                ValidAudience = builder.Configuration["Authentication:Audience"],
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = false

            };
        }
        );
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole(RoleConsts.Admin));
            options.AddPolicy("Merchant", policy => policy.RequireRole(RoleConsts.Merchant));
            options.AddPolicy("User", policy => policy.RequireRole(RoleConsts.User));

        });


        return builder;
    }
    
    public static WebApplicationBuilder AddScopedServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAccountService, AccountService>();
        builder.Services.AddScoped<IAccountRepository, AccountRepository>();
        return builder;
    }
    public static WebApplicationBuilder AddOptions(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection("Authentication"));
        return builder;
    }
}
