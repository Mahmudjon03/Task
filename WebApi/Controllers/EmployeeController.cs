using Domain.DTOs.EmployeeDto;
using Domain.Wapper;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route(("controller"))]

public class EmployeeController:ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("GetAllEmployee")]
    public async Task<Response<List<GetEmployeeDto>>> GetAllEmployee() => await _employeeService.GetAllEmployee();

    [HttpPost("AddEmployee")]
    public async Task<Response<GetEmployeeDto>> AddEmployee([FromForm]AddEmployeeDto model ) => await _employeeService.AddEmployee(model);

    [HttpGet("GetByIdEmployee")]
    public async Task<Response<GetEmployeeDto>> GetByIdEmployee(int id) => await _employeeService.GetById(id);
 
    [HttpDelete("DeleteEmployee")]
    public async Task<Response<bool>> DeleteEmployee(int id) => await _employeeService.DeleteEmployee(id);
  
    [HttpPut("UpdateEmployee")]
    public async Task<Response<GetEmployeeDto>> UpdateEmployee(AddEmployeeDto model) => await _employeeService.UpdateEmployee(model);
   
}