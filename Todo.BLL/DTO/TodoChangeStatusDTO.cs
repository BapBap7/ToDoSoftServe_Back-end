using Todo.DAL.Enums;

namespace Todo.BLL.DTO;

public class TodoChangeStatusDTO
{
    public int Id { get; set; }
    public TodoStatusEnum Status { get; set; }
}