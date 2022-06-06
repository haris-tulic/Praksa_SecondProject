using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Helpers;
using Praksa_SecondProject.Response;

namespace Praksa_SecondProject.Services.Interfaces
{
    public interface IBandService
    {
        Task<ServiceResponse<List<GetBandDto>>> GetBands();
        Task<ServiceResponse<List<GetBandDto>>> GetBandsByGenre(BandResourceParameters genre);
        PageList<GetBandDto> GetBandsPerPage(BandResourceParameters parameters);
        Task<ServiceResponse<GetBandDto>> GetBandById(int id);
        Task<ServiceResponse<GetBandDto>> AddBand(AddBandDto newBand);
        Task<ServiceResponse<GetBandDto>> UpdateBand(UpdateBandDto newBand);
        Task<ServiceResponse<GetBandDto>> DeleteBand(int id);  
        
        Task<bool> BandExist(int id);
    }
}
