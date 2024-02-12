using FluentResults;
using MediatR;
using Todo.BLL.DTO;

namespace Todo.BLL.MediatR.Todo.GetAll;

public record GetAllTodosQuery()
    : IRequest<Result<IEnumerable<TodoDefaultDTO>>>;