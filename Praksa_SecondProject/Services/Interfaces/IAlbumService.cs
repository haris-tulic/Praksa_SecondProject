using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Response;

namespace Praksa_SecondProject.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<ServiceResponse<List<GetAlbumDto>>> GetAlbums(int bandId);
        Task<ServiceResponse<GetAlbumDto>> GetAlbum(int bandId, int albumId);
        Task<ServiceResponse<GetAlbumDto>>AddAlbum(AddAlbumDto newAlbum);
        Task<ServiceResponse<GetAlbumDto>> UpdateAlbum(UpdateAlbumDto newAlbum);
        Task<ServiceResponse<GetAlbumDto>> DeleteAlbum(int albumId);  
    }        
}
