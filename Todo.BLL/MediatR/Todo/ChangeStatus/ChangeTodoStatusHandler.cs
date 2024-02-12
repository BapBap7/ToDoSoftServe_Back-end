using AutoMapper;
using FluentResults;
using MediatR;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.ChangeStatus;

public class ChangeTodoStatusHandler :
    IRequestHandler<ChangeTodoStatusCommand, Result<int>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public ChangeTodoStatusHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<int>> Handle(ChangeTodoStatusCommand request, CancellationToken cancellationToken)
    {
        var todo = await _repositoryWrapper.TodoRepository.GetFirstOrDefaultAsync(j => j.Id == request.todoChangeStatusDto.Id);
        if (todo is null)
        {
            string exMessage = $"No job found by entered Id - {request.todoChangeStatusDto.Id}";
            Console.WriteLine(exMessage);
            return Result.Fail(exMessage);
        }

        try
        {
            if (todo.Status == request.todoChangeStatusDto.Status)
            {
                return Result.Ok(todo.Id);
            }

            todo.Status = request.todoChangeStatusDto.Status;
            _repositoryWrapper.TodoRepository.Update(todo);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(todo.Id);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}