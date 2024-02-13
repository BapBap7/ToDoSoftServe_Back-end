using AutoMapper;
using FluentResults;
using MediatR;
using Todo.BLL.DTO;
using Todo.DAL.Repositories.Interfaces;


namespace Todo.BLL.MediatR.Todo.GetById;

public class GetTodoByIdHandler : IRequestHandler<GetTodoByIdQuery, Result<TodoDefaultDTO>>
{
    private readonly IMapper _mapper;
    private readonly IRepositoryWrapper _reppository;

    public GetTodoByIdHandler(IMapper mapper, IRepositoryWrapper reppository)
    {
        _mapper = mapper;
        _reppository = reppository;
    }

    public async Task<Result<TodoDefaultDTO>> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
    {
        var job = await _reppository.TodoRepository.GetFirstOrDefaultAsync(j => j.Id == request.todoId);

        if (job is null)
        {
            string exceptionMessege = $"No todo found by entered Id - {request.todoId}";
            Console.WriteLine(exceptionMessege);
            return Result.Fail(exceptionMessege);
        }

        try
        {
            var todoDto = _mapper.Map<TodoDefaultDTO>(job);
            return Result.Ok(todoDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return Result.Fail(ex.Message);
        }
    }
}