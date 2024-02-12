using FluentResults;
using MediatR;

namespace Todo.BLL.MediatR.Todo.Delete;

public record DeleteTodoCommand(int id)
    : IRequest<Result<int>>;