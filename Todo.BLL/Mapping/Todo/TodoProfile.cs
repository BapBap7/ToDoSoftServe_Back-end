using AutoMapper;
using Todo.BLL.DTO;
using Todo.DAL.Entities;

namespace Todo.BLL.Mapping.Todo;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<TodoE, TodoDefaultDTO>().ReverseMap();
    }
}