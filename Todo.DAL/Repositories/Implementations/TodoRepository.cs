using Todo.DAL.Entities;
using Todo.DAL.Persistence;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.DAL.Repositories.Implementations;

public class TodoRepository
{
    internal class UserRepository : RepositoryBase<TodoE>, ITodoRepository
    {
        public UserRepository(ToDoDbContext context)
            : base(context)
        {
        }
    }
}