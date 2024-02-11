using Microsoft.AspNetCore.Mvc;
using Todo.BLL.MediatR.Todo.GetAll;

namespace Todo.API.Controllers;


[Route("server/[controller]")]
public class TodoController : BaseController
{
    
    [HttpGet("/GetTodos")]
    public async Task<IActionResult> GetAllTodos()
    {
        Console.WriteLine("N");
        return HandleResult(await Mediator.Send(new GetAllTodosQuery()));
    }
}