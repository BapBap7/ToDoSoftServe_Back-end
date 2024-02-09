using Microsoft.AspNetCore.Mvc;
using Todo.BLL.Interfaces.Todo;

namespace Todo.WebAPI.Controllers;


[Route("server/[controller]")]
public class TodoController : BaseController
{
    private readonly ITodoService _todoService; // Assume ITodoService is the interface for your BLL service

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet("/GetTodos")]
    public async Task<IActionResult> GetAllTodos()
    {
        var todos = await _todoService.GetAllTodosAsync();
        return Ok(todos);
    }
}