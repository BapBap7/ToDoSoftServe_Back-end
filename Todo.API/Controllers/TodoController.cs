using Microsoft.AspNetCore.Mvc;
using Todo.BLL.DTO;
using Todo.BLL.MediatR.Todo.ChangeStatus;
using Todo.BLL.MediatR.Todo.CreateTodo;
using Todo.BLL.MediatR.Todo.Delete;
using Todo.BLL.MediatR.Todo.GetAll;
using Todo.BLL.MediatR.Todo.GetById;
using Todo.BLL.MediatR.Todo.Update;

namespace Todo.API.Controllers;

public class TodoController : BaseController
{
    
    [HttpGet("/GetTodos")]
    public async Task<IActionResult> GetAllTodos()
    {
        return HandleResult(await Mediator.Send(new GetAllTodosQuery()));
    }

    [HttpPost("/CreateTodo")]
    public async Task<IActionResult> CreateTodo([FromBody] TodoDefaultDTO todoDTO)
    {
        return HandleResult(await Mediator.Send(new CreateTodoCommand(todoDTO)));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        return HandleResult(await Mediator.Send(new GetTodoByIdQuery(id)));
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        return HandleResult(await Mediator.Send(new DeleteTodoCommand(id)));
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]TodoDefaultDTO todoDTO)
    {
        return HandleResult(await Mediator.Send(new UpdateTodoCommand(todoDTO)));
    }
    
    [HttpPut]
    public async Task<IActionResult> ChangeJobStatus([FromBody] TodoChangeStatusDTO todoChangeStatusDto)
    {
        return HandleResult(await Mediator.Send(new ChangeTodoStatusCommand(todoChangeStatusDto)));
    }
}