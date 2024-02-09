using Todo.BLL.DTO;
using Todo.DAL.Entities;

namespace Todo.BLL.Interfaces.Todo;


public interface ITodoService
{
    Task<IEnumerable<TodoDefaultDTO>> GetAllTodosAsync();
    Task<TodoE?> GetTodoByIdAsync(int id);

    Task<TodoDefaultDTO> CreateTodoAsync(TodoDTO todo);
    Task<TodoDefaultDTO> UpdateTodoAsync(int id, TodoDTO todo);
    Task<bool> DeleteTodoAsync(int id);
}