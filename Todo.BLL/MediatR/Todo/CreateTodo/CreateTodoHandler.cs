using FluentResults;
using MediatR;
using Todo.BLL.DTO;
using Todo.DAL.Repositories.Interfaces;

namespace Todo.BLL.MediatR.Todo.CreateTodo;

// public class CreateTodoHandler : IRequestHandler<CreateTodoCommand, Result<TodoDTO>>
// {
//     private readonly IRepositoryWrapper _repositoryWrapper;
//
//     public CreateTodoHandler(IRepositoryWrapper repositoryWrapper)
//     {
//         _repositoryWrapper = repositoryWrapper;
//     }
//
//     public async Task<Result<TodoDTO>> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
//     {
//         try
//         {
//             return Result.Ok()
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex);
//             return Result.Fail(ex.Message);
//         }
//     }
// }