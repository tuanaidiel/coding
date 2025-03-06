using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// In-memory list to store items
var items = new List<Item>
{
    new Item { Id = 1, Name = "Ayam" },
    new Item { Id = 2, Name = "Goreng" }
};

app.MapGet("/items", () => Results.Ok(items));

app.MapGet("/items/{id}", (int id) =>
{
    var item = items.FirstOrDefault(i => i.Id == id);
    return item is not null ? Results.Ok(item) : Results.NotFound();
});

app.MapPost("/items", ([FromBody] Item newItem) =>
{
    newItem.Id = items.Count + 1;
    items.Add(newItem);
    return Results.Created($"/items/{newItem.Id}", newItem);
});

app.Run();

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
}
