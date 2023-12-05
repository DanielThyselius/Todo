using Todo.Core.Interfaces;
using Todo.Core.Models;
using Todo.Infrastructure.Data;

namespace Todo.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public Task AddTodo(TodoItem todo)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetRemaining()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetTodoByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
