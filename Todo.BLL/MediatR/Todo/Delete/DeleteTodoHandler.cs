using FluentResults;
using MediatR;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.Delete;

public class DeleteJobHandler : IRequestHandler<DeleteTodoCommand, Result<int>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public DeleteJobHandler(IRepositoryWrapper repository)
    {
        _repositoryWrapper = repository;
    }

    public async Task<Result<int>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todoToDelete =
            await _repositoryWrapper.TodoRepository.GetFirstOrDefaultAsync(x => x.Id == request.id);
        if (todoToDelete is null)
        {
            string exMessage = $"No todo found by entered Id - {todoToDelete.Id}";
            Console.WriteLine(exMessage);
            return Result.Fail(exMessage);
        }

        try
        {
            _repositoryWrapper.TodoRepository.Delete(todoToDelete);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(request.id);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}