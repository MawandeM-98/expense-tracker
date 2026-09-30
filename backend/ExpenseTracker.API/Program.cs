using ExpenseTracker.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddExpenseTrackerServices(builder.Configuration);

var app = builder.Build();

app.UseExpenseTrackerPipeline();

app.Run();
