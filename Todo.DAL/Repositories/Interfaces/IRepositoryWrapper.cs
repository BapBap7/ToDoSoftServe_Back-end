namespace Todo.DAL.Repositories.Interfaces;

public interface IRepositoryWrapper
{
    
    ITodoRepository TodoRepository { get; }
    
    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}