using Todo.DAL.Persistence;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.DAL.Repositories.Implementations;

public class RepositoryWrapper : IrepositoryWrapper
{
    private readonly ToDoDbContext _toDoDbContext;
    private ITodoRepository _todoRepository;

    public RepositoryWrapper(ToDoDbContext toDoDbContext)
    {
        _toDoDbContext = toDoDbContext;
    }

    public ITodoRepository TodoRepository
    {
        get
        {
            if (_todoRepository is null)
            {
                _todoRepository = new TodoRepository(_toDoDbContext);
            }

            return _todoRepository;
        }
    }

    public int SaveChanges()
    {
        return _toDoDbContext.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _toDoDbContext.SaveChangesAsync();
    }
}