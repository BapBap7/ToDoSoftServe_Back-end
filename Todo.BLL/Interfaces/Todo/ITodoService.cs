using Todo.BLL.DTO;
using Todo.DAL.Entities;

namespace Todo.BLL.Interfaces.Todo;


public interface ITodoService
{
    Task<TodoE?> GetTodoByIdAsync(int id);

    Task<TodoDefaultDTO> CreateTodoAsync(TodoDefaultDTO todo);
    Task<TodoDefaultDTO> UpdateTodoAsync(int id, TodoDefaultDTO todo);
    Task<bool> DeleteTodoAsync(int id);
}