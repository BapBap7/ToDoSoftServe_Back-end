using Microsoft.EntityFrameworkCore;

namespace Todo.DAL.Persistence;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext()
    {
    }

    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Entities.TodoE> Todos { get; set; }
}