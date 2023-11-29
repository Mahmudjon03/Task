using Domain.Enums;

namespace Domain.DTOs.EmployeeDto;

public class AddEmployeeDto:BaseEmployeeDto
{
   
    public Jobtitle Jobtitle { get; set; }
}