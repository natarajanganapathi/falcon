// namespace Samples.Api.Endpoints;

// public class EnvironmentEndpoints
// {
//     public void Map(WebApplication app)
//     {
//         app.MapGroup(this)
//             .RequireAuthorization()
//             .MapGet(GetTodoItemsWithPagination)
//             .MapPost(CreateTodoItem)
//             .MapPut(UpdateTodoItem, "{id}")
//             .MapPut(UpdateTodoItemDetail, "UpdateDetail/{id}")
//             .MapDelete(DeleteTodoItem, "{id}");
//     }

//     public Task<PaginatedList<TodoItemBriefDto>> GetTodoItemsWithPagination(ISender sender, [AsParameters] GetTodoItemsWithPaginationQuery query)
//     {
//         return sender.Send(query);
//     }

//     public Task<int> CreateTodoItem(ISender sender, CreateTodoItemCommand command)
//     {
//         return sender.Send(command);
//     }

//     public async Task<IResult> UpdateTodoItem(ISender sender, int id, UpdateTodoItemCommand command)
//     {
//         if (id != command.Id) return Results.BadRequest();
//         await sender.Send(command);
//         return Results.NoContent();
//     }

//     public async Task<IResult> UpdateTodoItemDetail(ISender sender, int id, UpdateTodoItemDetailCommand command)
//     {
//         if (id != command.Id) return Results.BadRequest();
//         await sender.Send(command);
//         return Results.NoContent();
//     }

//     public async Task<IResult> DeleteTodoItem(ISender sender, int id)
//     {
//         await sender.Send(new DeleteTodoItemCommand(id));
//         return Results.NoContent();
//     }
// }

// namespace LightingApi.Endpoints;

// public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }

// public static class SampleEndpoints
// {
//     private static readonly string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
//     public static WeatherForecast[] WeatherForecast()
//     {
//         return Enumerable.Range(1, 5).Select(index =>
//             new WeatherForecast
//             (
//                 DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                 Random.Shared.Next(-20, 55),
//                 summaries[Random.Shared.Next(summaries.Length)]
//             ))
//             .ToArray();
//     }
// }