using AutoMapper;
using FluentResults;
using MediatR;
using Todo.BLL.DTO;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.GetAll;

internal class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, Result<IEnumerable<TodoDefaultDTO>>>
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IMapper _mapper;
    
    public GetAllTodosHandler(IRepositoryWrapper repository, IMapper mapper)
    {
        _repositoryWrapper = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<TodoDefaultDTO>>> Handle(GetAllTodosQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine("N2");
            var todos = await _repositoryWrapper.TodoRepository.GetAllAsync(
                selector: todo => todo, // This is a simple identity selector, essentially selecting the todo as is
                predicate: null, // No filtering, so passing null
                include: null // No related entities to include, so passing null
            );
            var todoDto = _mapper.Map<IEnumerable<TodoDefaultDTO>>(todos);
            return Result.Ok(todoDto);
        }
        catch(Exception ex)
        {
            Console.WriteLine();
            return Result.Fail(ex.Message);
        }
    }
}