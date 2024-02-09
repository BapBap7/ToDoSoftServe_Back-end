using Todo.BLL.DTO;
using Todo.DAL.Entities;

namespace Todo.BLL.Interfaces.Todo;


public interface ITodoService
{
    Task<IEnumerable<TodoDTO>> GetAllTodosAsync();
    Task<TodoE?> GetTodoByIdAsync(int id);

    Task<TodoDTO> CreateTodoAsync(TodoDTO todo);
    Task<TodoDTO> UpdateTodoAsync(int id, TodoDTO todo);
    Task<bool> DeleteTodoAsync(int id);
}