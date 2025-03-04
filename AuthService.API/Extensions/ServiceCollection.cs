using AuthService.Domain.Entities;

namespace AuthService.API.Extensions;

public static class ServiceCollection
{
    public static WebApplicationBuilder AddBearerAuthentitication(this WebApplicationBuilder builder) {

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole(RoleConsts.Admin));
            options.AddPolicy("Merchant", policy => policy.RequireRole(RoleConsts.Merchant));
            options.AddPolicy("User", policy => policy.RequireRole(RoleConsts.User));

        });

        builder.Services.AddAuthentication(a =>
        {
            a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(x =>
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

        


        return builder;
    }
}
