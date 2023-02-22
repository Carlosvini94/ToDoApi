using Microsoft.EntityFrameworkCore;
using ToDoaPI.Models;
using ToDoApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ToDoApiDb"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("api/todo", async (AppDbContext context) =>
{
    var toDoitems = await context.ToDoItems.ToListAsync();
    return Results.Ok(toDoitems);
});

app.MapPost("api/todo", async (AppDbContext context, ToDoItem toDoItem) =>
{
    if (toDoItem == null) return Results.BadRequest();

    await context.ToDoItems.AddAsync(toDoItem);
    await context.SaveChangesAsync();

    return Results.Created($"api/todo/{toDoItem.Id}", toDoItem);
});

app.Run();