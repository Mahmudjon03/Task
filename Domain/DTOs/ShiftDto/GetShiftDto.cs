using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.ShiftDto;

public class GetShiftDto
{
    public int Id { get; set; }
    
    public DateTime StartShift { get; set; }
    
    public DateTime EndShift { get; set; }
    
    public string TimeWork  { get; set; }
    
    public string Employee { get; set; }
}