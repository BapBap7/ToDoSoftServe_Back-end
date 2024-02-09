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
    
    public async Task<TodoE?> GetTodoByIdAsync(int id)
    {
        return await _todoRepository.GetFirstOrDefaultAsync(todo => todo.Id == id);
    }
    
    public async Task<IEnumerable<TodoDefaultDTO>> GetAllTodosAsync()
    {
        // Assuming _todoRepository is an instance of your RepositoryBase class configured for TodoE entities
        var todoEntities = await _todoRepository.GetAllAsync(
            selector: entity => entity // This will return IEnumerable<TodoE>
        );

        // Check if todoEntities is null and return an empty IEnumerable<TodoDTO> if true
        if (todoEntities == null) return Enumerable.Empty<TodoDefaultDTO>();

        // Map each TodoE entity to a TodoDTO
        var todoDtos = todoEntities.Select(entity => new TodoDefaultDTO
        {
            Id = entity.Id,
            Title = entity.Title,
            Status = entity.Status,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Priority = entity.Priority
            // Map other properties as needed
        });

        return todoDtos;
    }
    
    public async Task<TodoDefaultDTO> CreateTodoAsync(TodoDTO todoDto)
    {
        var todoEntity = new TodoE
        {
            Title = todoDto.Title,
            Status = todoDto.Status,
            Description = todoDto.Description,
            StartDate = todoDto.StartDate,
            EndDate = todoDto.EndDate,
            Priority = todoDto.Priority
        };
        
        _todoRepository.Create(todoEntity);

        return new TodoDefaultDTO
        {
            Id = todoEntity.Id,
            Title = todoEntity.Title,
            Status = todoEntity.Status,
            Description = todoEntity.Description,
            StartDate = todoEntity.StartDate,
            EndDate = todoEntity.EndDate,
            Priority = todoEntity.Priority
        };
    }
    
    public async Task<bool> DeleteTodoAsync(int id)
    {
        var todoEntity = await _todoRepository.GetFirstOrDefaultAsync(todo => todo.Id == id);
        if (todoEntity == null) return false;

        _todoRepository.Delete(todoEntity);

        return true;
    }

    public async Task<TodoDefaultDTO> UpdateTodoAsync(int id, TodoDTO todoDto)
    {
        var todoEntity = await _todoRepository.GetFirstOrDefaultAsync(todo => todo.Id == id);
        if (todoEntity == null) return null;

        // Update properties
        todoEntity.Title = todoDto.Title;
        todoEntity.Status = todoDto.Status;
        todoEntity.Description = todoDto.Description;
        todoEntity.StartDate = todoDto.StartDate;
        todoEntity.EndDate = todoDto.EndDate;
        todoEntity.Priority = todoDto.Priority;
        // Update other properties as needed

        _todoRepository.Update(todoEntity);

        return new TodoDefaultDTO
        {
            Id = todoEntity.Id,
            Title = todoEntity.Title,
            Status = todoEntity.Status,
            Description = todoEntity.Description,
            StartDate = todoEntity.StartDate,
            EndDate = todoEntity.EndDate,
            Priority = todoEntity.Priority
        };
    }
}