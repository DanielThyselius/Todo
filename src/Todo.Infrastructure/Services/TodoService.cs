using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            var todos = await _context.TodoItems.ToListAsync();
            todos[0].Tags = new string[] { "boring", "important", "slow", "new" };
            return todos;
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
