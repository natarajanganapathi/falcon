var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Logging.AddSimpleConsole((options) =>
{
    options.SingleLine = true;
    options.TimestampFormat = "hh:mm:ss ";
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
   {
       options.SwaggerEndpoint("/openapi/v1.json", "v1");
   });
}
app.UseHttpsRedirection();
app.MapGet("/", () => "Running...!");
app.MapHealthChecks("/health");
await app.RunAsync();
