using System;
using Microsoft.AspNetCore.Hosting;
using FirstApp.Data;
using FirstApp.ViewModels;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();

app.MapGet("/", (AppDataContext context) => {
    var users = context.User.ToList();
    return Results.Ok(users);
});

app.MapPost("/users", (AppDataContext context, CreateUserViewModel model) => {
    var user = model.UserDTO();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);
    context.User.Add(user);
    context.SaveChanges();
    return Results.Created($"/users/{user.Email}", user);
});

app.Run();
