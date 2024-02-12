using MediatR;
using FluentResults;
using Todo.BLL.DTO;

namespace Todo.BLL.MediatR.Todo.CreateTodo;

public record CreateTodoCommand(TodoDefaultDTO todo) : IRequest<Result<TodoDefaultDTO>>;