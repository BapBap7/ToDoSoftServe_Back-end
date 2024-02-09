using System.Linq.Expressions;
using Todo.BLL.DTO;
using Todo.BLL.Interfaces.Todo;
using Todo.DAL.Entities;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.Services.Todo;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;

    public TodoService(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<TodoDTO>> GetAllTodosAsync()
    {

    }
    
    public async Task<TodoE?> GetTodoByIdAsync(int id)
    {
        return await _todoRepository.GetFirstOrDefaultAsync(todo => todo.Id == id);
    }
    
    public async Task<TodoDTO> CreateTodoAsync(TodoDTO todoDto)
    {

    }
    
    public async Task<bool> DeleteTodoAsync(int id)
    {

    }

    public async Task<TodoDTO> UpdateTodoAsync(int id, TodoDTO todo)
    {

    }
}