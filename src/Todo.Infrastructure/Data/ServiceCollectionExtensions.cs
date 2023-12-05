using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Todo.Infrastructure.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddTodoDbContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<TodoDbContext>(options =>
                options.UseInMemoryDatabase("Todos"));
            //options.UseSqlServer(connectionString));
        }
    }
}
