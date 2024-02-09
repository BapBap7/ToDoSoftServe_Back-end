using Todo.DAL.Entities;
using Todo.DAL.Persistence;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.DAL.Repositories.Implementations;

internal class TodoRepository : RepositoryBase<TodoE>, ITodoRepository
{
    public TodoRepository(ToDoDbContext context)
        : base(context)
    {
    }
}