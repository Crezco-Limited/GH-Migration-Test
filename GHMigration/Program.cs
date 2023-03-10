using GHMigration;
using GHMigration.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
var healthCheckOptions = new TestHealthCheckOptions();
builder.Configuration.GetSection("TestHealthCheckOptions").Bind(healthCheckOptions);
builder.Services.AddSingleton(healthCheckOptions);

builder.Services.AddHealthChecks()
    .AddCheck<TestHealthCheck>("Test");

var app = builder.Build();

app.MapHealthChecks("/health");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();