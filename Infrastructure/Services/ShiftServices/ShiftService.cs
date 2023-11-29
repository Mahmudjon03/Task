using System.Net;
using AutoMapper;
using Domain.DTOs.ShiftDto;
using Domain.Entities;
using Domain.Wapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.ShiftServices;

public class ShiftService:IShiftService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ShiftService(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<Response<List<GetShiftDto>>> GetShitAll()
    {
        var getShift =await _context.Shifts.Select(sh => new GetShiftDto()
        {
         Id=sh.Id,
         StartShift = sh.StartShift.ToUniversalTime(),
         EndShift = sh.EndShift.ToUniversalTime(),
         TimeWork = sh.TimeWork.ToString(),
         Employee = sh.Employee.FirstName
        }).ToListAsync();
        if (getShift.Count == 0) return new Response<List<GetShiftDto>>( "Not exist Employee",HttpStatusCode.NotFound );

        return new Response<List<GetShiftDto>>(getShift);
    }

    public async Task<Response<bool>> StartShiftEmployee(ShiftDto model)
    {
        
            var employee =await _context.Employees.FindAsync(model.EmployeeId);
            if (employee == null) return  new Response<bool>("Employee not found",HttpStatusCode.NotFound);
            var shift = new Shift()
            {
                EmployeeId = model.EmployeeId,
                StartShift = DateTime.UtcNow
            };
            var time = DateTime.Today.AddHours(8);
            if (shift.StartShift > time) 
                shift.TimeWork = shift.StartShift-time;
        
          await  _context.Shifts.AddAsync(shift);
          await _context.SaveChangesAsync();
         
          return new Response<bool>(true);
    }

    public async Task<Response<bool>> EndShiftEmployee(EndShiftDto model)
    {
        var shift = await _context.Shifts.FindAsync(model.ShiftId);
        
        if(shift == null) return  new Response<bool>("Shift not found",HttpStatusCode.NotFound);

        shift.EndShift = DateTime.UtcNow;   
        var time = DateTime.Today.AddHours(17);
        if (shift.EndShift > time) shift.TimeWork += time-shift.StartShift;
        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}