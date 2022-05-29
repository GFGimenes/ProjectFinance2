using ProjectFinance2;
using ProjectFinance2.Application.Repositories;
using ProjectFinance2.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);


var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();