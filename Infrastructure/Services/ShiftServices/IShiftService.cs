using Domain.DTOs.ShiftDto;
using Domain.Wapper;

namespace Infrastructure.Services.ShiftServices;

public interface IShiftService
{ 
        Task<Response<List<GetShiftDto>>> GetShitAll();
    
        Task<Response<bool>> StartShiftEmployee(ShiftDto model);
    
        Task<Response<bool>> EndShiftEmployee(EndShiftDto model);
       
}