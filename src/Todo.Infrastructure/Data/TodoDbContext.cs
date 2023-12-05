using Microsoft.EntityFrameworkCore;
using Todo.Core.Models;

namespace Todo.Infrastructure.Data;

public class TodoDbContext : DbContext
{
    internal DbSet<TodoItem> TodoItems { get; set; }

    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<TodoItem>().Ignore(item => item.Tags);

        modelBuilder.Entity<TodoItem>().HasData(
            new TodoItem("Tvätta") { Id = 1 },
            new TodoItem("Städa") { Id = 2 },
            new TodoItem("Diska") { Id = 3 });
    }
}