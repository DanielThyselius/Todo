using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<Models.TodoItem>> GetAllTodosAsync();
        Models.TodoItem GetTodoByName(string name);
        Task AddTodo(Models.TodoItem todo);
        Task<int> GetRemaining();
    }
}
