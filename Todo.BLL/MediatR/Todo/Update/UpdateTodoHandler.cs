using AutoMapper;
using FluentResults;
using MediatR;
using Todo.BLL.DTO;
using Todo.DAL.Entities;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.Update;


public class UpdateJobHandler : IRequestHandler<UpdateTodoCommand, Result<TodoDefaultDTO>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public UpdateJobHandler(IRepositoryWrapper repository, IMapper mapper)
    {
        _repositoryWrapper = repository;
        _mapper = mapper;
    }

    public async Task<Result<TodoDefaultDTO>> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var existedTodo =
            await _repositoryWrapper.TodoRepository.GetFirstOrDefaultAsync(x => x.Id == request.todo.Id);
        if (existedTodo is null)
        {
            string exMessage = $"No job found by entered Id - {request.todo.Id}";
            Console.WriteLine(exMessage);
            return Result.Fail(exMessage);
        }

        try
        {
            var todoToUpdate = _mapper.Map<TodoE>(request.todo);
            _repositoryWrapper.TodoRepository.Update(todoToUpdate);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(_mapper.Map<TodoDefaultDTO>(todoToUpdate));
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}