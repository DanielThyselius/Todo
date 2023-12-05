using Microsoft.EntityFrameworkCore;
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


        app.MapHealthChecks("api/healthcheck");
        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}