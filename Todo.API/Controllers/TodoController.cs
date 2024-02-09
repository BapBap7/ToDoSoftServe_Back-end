using Microsoft.AspNetCore.Mvc;

namespace Todo.WebAPI.Controllers;


[Route("server/[controller]")]
public class TodoController : BaseController
{
    [HttpGet("/GetTodos")]
    public string GetTodos(string text)
    {
        return $"{text} is a Bitch!";
    }
}