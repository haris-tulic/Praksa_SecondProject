using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Praksa_SecondProject.Database;
using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Response;
using Praksa_SecondProject.Services.Interfaces;

namespace Praksa_SecondProject.Services.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;
        public AlbumService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetAlbumDto>> AddAlbum(AddAlbumDto newAlbum)
        {
            var response = new ServiceResponse<GetAlbumDto>();
            try
            {
                var entity = _mapper.Map<Album>(newAlbum);
                if (entity==null)
                {
                    response.Message = "Album is null!";
                    response.Success= false;
                    return response;
                }
                _context.Albums.Add(entity);
                await _context.SaveChangesAsync();
                response.Data=_mapper.Map<GetAlbumDto>(entity);
                response.Message = "Album successfully created!";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetAlbumDto>> DeleteAlbum(int albumId)
        {
            var response = new ServiceResponse<GetAlbumDto>();
            try
            {
                var entity = await _context.Albums.FirstOrDefaultAsync(x => x.Id == albumId);
                if (entity==null)
                {
                    response.Success = false;
                    response.Message = "Album doesn't exist!";
                    return response;
                }
                _context.Albums.Remove(entity);
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Data= _mapper.Map<GetAlbumDto>(entity);
                response.Message = "Album succesfully created!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetAlbumDto>> GetAlbum(int bandId, int albumId)
        {
            var response = new ServiceResponse<GetAlbumDto>();
            try
            {
                var entity=await _context.Albums.Include(x => x.Band).FirstOrDefaultAsync(x => x.Id == albumId && x.BandId == bandId);
                if (entity==null)
                {
                    response.Success = false;
                    response.Message = "Album doesn't exist!";
                    return response;
                }
                response.Data = _mapper.Map<GetAlbumDto>(entity);
                response.Success = true;
                response.Message = $"Album: {entity.Title}";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetAlbumDto>>> GetAlbums(int bandId)
        {
            var response=new ServiceResponse<List<GetAlbumDto>>();
            try
            {
                var list = await _context.Albums.Where(x => x.BandId==bandId).ToListAsync();
                if (list==null)
                {
                    response.Success = false;
                    response.Message = "Albums doesn't exist!";
                    return response;
                }
                response.Data = _mapper.Map<List<GetAlbumDto>>(list);
                response.Success = true;
                response.Message = "Albums succesfully found!";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message; 
            }
            return response;
        }

        public async Task<ServiceResponse<GetAlbumDto>> UpdateAlbum(UpdateAlbumDto newAlbum)
        {
            var response = new ServiceResponse<GetAlbumDto>();
            try
            {
                
                var updateE=await _context.Albums.Include(x=>x.Band).FirstOrDefaultAsync(x=>x.Id==newAlbum.Id);
                if (updateE == null)
                {
                    response.Success = false;
                    response.Message = "Album doesn't exist!";
                    return response;
                }
                _mapper.Map(newAlbum, updateE);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetAlbumDto>(updateE);
                response.Success = true;
                response.Message = $"Album: {updateE.Title} succesfully updated!";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
