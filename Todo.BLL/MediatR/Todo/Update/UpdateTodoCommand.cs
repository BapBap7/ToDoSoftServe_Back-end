using FluentResults;
using MediatR;
using Todo.BLL.DTO;

namespace Todo.BLL.MediatR.Todo.Update;

public record UpdateTodoCommand(TodoDefaultDTO todo)
    : IRequest<Result<TodoDefaultDTO>>;