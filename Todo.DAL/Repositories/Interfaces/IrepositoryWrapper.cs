namespace Todo.DAL.Repositories.Interfaces;

public interface IrepositoryWrapper
{
    
    ITodoRepository TodoRepository { get; }
    
    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}