var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole((options) =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss ";
});

builder.Services.AddOpenApi();
#if DEBUG
    builder.Services.LogQueryConsumers();
#endif

builder.Services.AddMessagingExtension();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
WeatherForecastEndpoints.MapApis(app);
app.Run();
