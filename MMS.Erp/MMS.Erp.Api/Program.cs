using MMS.Erp.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebApplicationBuilder();

var app = builder.Build();

app.AddWebApplication();

app.Run();