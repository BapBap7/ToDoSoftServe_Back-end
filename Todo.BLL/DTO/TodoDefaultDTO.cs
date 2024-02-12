
using Todo.DAL.Enums;

namespace Todo.BLL.DTO;

public class TodoDefaultDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public TodoStatusEnum Status { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Priority { get; set; }
}