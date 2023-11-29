using Domain.DTOs.ShiftDto;
using Domain.Entities;

namespace Domain.DTOs.EmployeeDto;

public class GetEmployeeDto:BaseEmployeeDto
{
    public string Jobtitle { get; set; }

    public List<GetShiftDto> Shifts { get; set; } 

}