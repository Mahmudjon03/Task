using System.Net;
using System.Runtime.CompilerServices;
using AutoMapper;
using Domain.DTOs.EmployeeDto;
using Domain.DTOs.ShiftDto;
using Domain.Entities;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Servises;

public class EmployeeService:IEmployeeService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<GetEmployeeDto>>> GetAllEmployee()
    {
        var getEmployee =await _context.Employees.Select(e => new GetEmployeeDto()
        {
        Id = e.Id,
        FirstName = e.FirstName,
        SurName = e.SurName, 
        FatherName = e.FatherName,
        Jobtitle =e.Jobtitle
        }).ToListAsync();
        
        if (getEmployee.Count == 0) return new Response<List<GetEmployeeDto>>( "Not exist Employee",HttpStatusCode.NotFound );
      
        return new Response<List<GetEmployeeDto>>(getEmployee);
    }

    public async Task<Response<GetEmployeeDto>> GetById(int id)
    {
        //var employee = await _context.Employees.FindAsync(id);

        var getEmployee =await _context.Employees.Select(employee =>  new GetEmployeeDto()
        { Id = employee.Id,
            FirstName = employee.FirstName,
          SurName = employee.SurName,
          FatherName = employee.FatherName,
          Jobtitle = employee.Jobtitle,
          Shifts = employee.Shift.Select(e=>new GetShiftDto()
          {
              Id = e.Id,
              StartShift = e.StartShift.ToUniversalTime(),
              EndShift = e.EndShift.ToUniversalTime(),
              TimeWork = e.TimeWork.ToString()
          }).ToList()
        }).FirstOrDefaultAsync(x=>x.Id==id);
       
        if (getEmployee == null) return new Response<GetEmployeeDto>("Employee not found",HttpStatusCode.BadRequest);

        return new Response<GetEmployeeDto>(getEmployee);
    }

    public async Task<Response<GetEmployeeDto>> AddEmployee(AddEmployeeDto model)
    {
       var addEmployee = _mapper.Map<Employee>(model);
     
       await _context.Employees.AddAsync(addEmployee); 
       await _context.SaveChangesAsync();
      
      var getEmployee = _mapper.Map<GetEmployeeDto>(addEmployee);
      
      return new Response<GetEmployeeDto>(getEmployee);
    }

    public async Task<Response<GetEmployeeDto>> UpdateEmployee(AddEmployeeDto model)
    {
        var employee = await _context.Employees.FindAsync(model.Id);
        
        if (employee == null) return new Response<GetEmployeeDto>("Employee not found",HttpStatusCode.BadRequest);

        employee.FirstName = model.FirstName;
        employee.SurName = model.SurName;
        employee.FatherName = model.FatherName;
        employee.Jobtitle = model.Jobtitle.ToString();
        
        await _context.SaveChangesAsync();
        
        var getEmployee = _mapper.Map<GetEmployeeDto>(model);
       
        return new Response<GetEmployeeDto>(getEmployee);
    }

    public async Task<Response<bool>> DeleteEmployee(int id)
    {
        var employee =await _context.Employees.FindAsync(id);
        
        if (employee == null) return new Response<bool>("Employee not found",HttpStatusCode.BadRequest);

        _context.Employees.Remove(employee);
        
        await _context.SaveChangesAsync();

        return new Response<bool>(true);
    }
}