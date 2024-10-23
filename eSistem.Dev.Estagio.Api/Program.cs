using eSistem.Dev.Estagio.Api.Configurations;
using eSistem.Dev.Estagio.Api.Endpoints;
using eSistem.Dev.Estagio.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder
    .Configurations()
    .AddCors()
    .AddEntityFramework()
    .Security()
    .AddDependencyInjection();
    

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndpointsGroups();
app.UseCors(ApiConfiguration.CorsPolicyName);
app.UseAuthentication();
app.UseAuthorization();

app.Run();
