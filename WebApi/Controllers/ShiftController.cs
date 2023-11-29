using Domain.DTOs.ShiftDto;
using Domain.Wapper;
using Infrastructure.Services.ShiftServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("controller")]
public class ShiftController:ControllerBase
{
    private readonly IShiftService _shiftService;

    public ShiftController(IShiftService shiftService)
    {
        _shiftService = shiftService;
    }

    [HttpGet("GetAllShift")]
    public async Task<Response<List<GetShiftDto>>> GetAllShift() => await _shiftService.GetShitAll();
    
    


    [HttpPost("StartShift")]
    public async Task<Response<bool>> StartShift(ShiftDto model) =>await _shiftService.StartShiftEmployee(model);
    [HttpPut(" EndShift")]
    public async Task<Response<bool>> EndShift(EndShiftDto model) =>await _shiftService.EndShiftEmployee(model);

}