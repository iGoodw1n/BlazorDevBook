using Data.Models;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebAssembly.Server.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategory(this WebApplication app)
    {
        app.MapGet("/api/Categories", async (IBlogApi api) =>
        {
            return Results.Ok(api.GetCategoriesAsync());
        });

        app.MapGet("/api/Categories/{*id}", async (IBlogApi api, string id) =>
        {
            return Results.Ok(api.GetCategoryAsync(id));
        });

        app.MapDelete("/api/categories{*id}", async (IBlogApi api, string id) =>
        {
            await api.DeleteCategoryAsync(id);
            return Results.Ok();
        });

        app.MapPut("/api/Categories", async (IBlogApi api, [FromBody] Category item) =>
        {
            return Results.Ok(await api.SaveCategoryAsync(item));
        });
    }
}
