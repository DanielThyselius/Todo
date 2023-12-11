using Todo.Core.Interfaces;
using Todo.Infrastructure.Data;
using Todo.Infrastructure.Services;

namespace Todo.Api;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to our container
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddHealthChecks();

        // empty string is fine if using in-memory, todo: update this
        builder.Services.AddTodoDbContext("");

        builder.Services.AddScoped<ITodoService, TodoService>();
        // Configure our HTTP request pipeline

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<TodoDbContext>();
            context.Database.EnsureCreated();
        }

        app.MapHealthChecks("api/healthcheck");

        app.MapGet("/", async () 
            => "Welcome to the ToDo application for doing amazing things!");
        
        app.MapGet("api/todos", async (ITodoService service) =>
        {
            var todos = await service.GetAllTodosAsync();
            return todos;
        })
        .WithName("GetTodos");

        app.Run();
    }
}