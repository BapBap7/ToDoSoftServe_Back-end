using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Todo.DAL.Enums;

namespace Todo.DAL.Entities;

public class TodoE
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [Required]
    [MaxLength(50)]
    public TodoStatusEnum Status { get; set; }
    
    [Required]
    [MaxLength(150)]
    public string Description { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Priority { get; set; }
    
}