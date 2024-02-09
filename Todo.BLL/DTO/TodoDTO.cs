﻿namespace Todo.BLL.DTO;

public class TodoDTO
{
    public string Title { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Priority { get; set; }
}