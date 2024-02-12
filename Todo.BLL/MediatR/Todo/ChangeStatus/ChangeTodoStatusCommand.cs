using FluentResults;
using MediatR;
using Todo.BLL.DTO;

namespace Todo.BLL.MediatR.Todo.ChangeStatus;

public record ChangeTodoStatusCommand(TodoChangeStatusDTO todoChangeStatusDto)
    : IRequest<Result<int>>;
