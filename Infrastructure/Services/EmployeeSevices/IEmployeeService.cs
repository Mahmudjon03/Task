using Domain.DTOs.EmployeeDto;
using Domain.Entities;
using Domain.Wapper;

namespace Infrastructure.Servises;

public interface IEmployeeService
{
    Task<Response<List<GetEmployeeDto>>> GetAllEmployee();
   
    Task<Response<GetEmployeeDto>> GetById(int id);
   
    Task<Response<GetEmployeeDto>> AddEmployee(AddEmployeeDto model);
    
    Task<Response<GetEmployeeDto>> UpdateEmployee(AddEmployeeDto model);
    
    Task<Response<bool>> DeleteEmployee(int id);

}