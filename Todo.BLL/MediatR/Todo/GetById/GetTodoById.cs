using FluentResults;
using MediatR;
using Todo.BLL.DTO;

namespace Todo.BLL.MediatR.Todo.GetById;

public record GetTodoByIdQuery(int todoId)
    : IRequest<Result<TodoDefaultDTO>>;