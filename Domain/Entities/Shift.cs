using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class Shift
{   [Key]
    public int Id { get; set; }
    
    public DateTime StartShift { get; set; }
    
    public DateTime EndShift { get; set; }
    
    public TimeSpan TimeWork  { get; set; }

    public int EmployeeId { get; set; } 

    public Employee Employee { get; set; } = null!;

}
