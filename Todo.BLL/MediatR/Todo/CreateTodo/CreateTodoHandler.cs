using AutoMapper;
using FluentResults;
using MediatR;
using Todo.BLL.DTO;
using Todo.DAL.Entities;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.CreateTodo;

public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Result<TodoDefaultDTO>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;

    public CreateTodoHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
    {
        _mapper = mapper;
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Result<TodoDefaultDTO>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var todo = _mapper.Map<TodoE>(request.todo);
            var createdJob = await _repositoryWrapper.TodoRepository.CreateAsync(todo);
            await _repositoryWrapper.SaveChangesAsync();
            return Result.Ok(_mapper.Map<TodoDefaultDTO>(createdJob));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}