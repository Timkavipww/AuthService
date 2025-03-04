using AuthService.API.Extensions;
using AuthService.API.Services;
using AuthService.Domain.IRepositories;
using AuthService.Persistense;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder
    .AddBearerAuthentitication();
     //.AddScopedServices()
     //.AddOptions();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth Service", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();


app.UseRouting();
//AUTH
app.UseAuthorization();
app.UseAuthentication();
//ROUTING
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger/index.html")).RequireAuthorization();
app.Run();