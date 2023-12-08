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

        public async Task<bool> AddTodo(TodoItem todo)
        {
            if (await TodoExists(todo.Name))
                return false;

            await _context.TodoItems.AddAsync(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public Task<int> GetRemaining()
        {
            throw new NotImplementedException();
        }

        public TodoItem GetTodoByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> TodoExists(string name)
        {
            name = name.Clean();
            return await _context.TodoItems
                .AnyAsync(x => x.Name.Clean() == name);
        }
    }
    internal static class StringExtensions
    {
        internal static string Clean(this string name) 
            => name.ToLower().Trim('!', '?', '.', ' ');
    }
}
