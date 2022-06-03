using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Praksa_SecondProject.Database;
using Praksa_SecondProject.DTO;
using Praksa_SecondProject.Helpers;
using Praksa_SecondProject.Response;
using Praksa_SecondProject.Services.Interfaces;

namespace Praksa_SecondProject.Services.Services
{
    public class BandService : IBandService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BandService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<GetBandDto>> AddBand(AddBandDto newBand)
        {
            var response=new ServiceResponse<GetBandDto>();
            try
            {
                var entity = _mapper.Map<Band>(newBand);
                if (entity==null)
                {
                    response.Message = "Band is empty!";
                    response.Success = false;
                    return response;
                }
                _context.Bands.Add(entity);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetBandDto>(entity);
                response.Success = true;
                response.Message = "Band successfully added!";
               

            }
            catch (Exception ex)
            { 
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<bool> BandExist(int id)
        {
            var band = await _context.Bands.FirstOrDefaultAsync(x => x.Id == id);
            if (band==null)
            {
                return false;
            }
            return true;
        }

        public async Task<ServiceResponse<GetBandDto>> DeleteBand(int id)
        {
            var response = new ServiceResponse<GetBandDto>();
            try
            {
                var entity = await _context.Bands.FirstOrDefaultAsync(x => x.Id == id);
                if (entity==null)
                {
                    response.Success = false;
                    response.Message = "Band doesn't exist!";
                    return response;
                }
                _context.Bands.Remove(entity);
                await _context.SaveChangesAsync();
                response.Data=_mapper.Map<GetBandDto>(entity);
                response.Message = "Band successfully deleted!";
                response.Success = true;
                
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message=ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetBandDto>> GetBandById(int id)
        {
            var response=new ServiceResponse<GetBandDto>();
            try
            {
                var entity = await _context.Bands.FirstOrDefaultAsync(x => x.Id == id);
                if (entity==null)
                {
                    response.Success = false;
                    response.Message = "Band doesn't exist!";
                    return response;
                }
                response.Data = _mapper.Map<GetBandDto>(entity);
                response.Success = true;
                response.Message = "Band successfully returned!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetBandDto>>> GetBands()
        {
            var response=new ServiceResponse<List<GetBandDto>>();
            try
            {
                var listEntity=await _context.Bands.ToListAsync();
                if (listEntity==null)
                {
                    response.Message = "Bands doesn't exists!";
                    response.Success = false;
                    return response;
                }
                var listM=_mapper.Map<List<GetBandDto>>(listEntity);
                response.Data = listM;
                response.Success = true;
                response.Message = "Bands successfully returned!";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetBandDto>>> GetBandsByGenre(BandResourceParameters genre)
        {
            // filtering
            var response = new ServiceResponse<List<GetBandDto>>();
            if (string.IsNullOrWhiteSpace(genre.Genre) && string.IsNullOrWhiteSpace(genre.SearchQuery))
                return await GetBands();

            var collection = _context.Bands.AsQueryable();
            if (!string.IsNullOrWhiteSpace(genre.SearchQuery))
            {
                genre.SearchQuery =genre.SearchQuery.Trim() ;
                collection = collection.Where(x => x.MainGenre.Contains(genre.SearchQuery));
            }
            if (!string.IsNullOrWhiteSpace(genre.Genre))
            {
                genre.Genre = genre.Genre.Trim();

                var bands= await _context.Bands.Where(x => x.MainGenre == genre.Genre).ToListAsync();
                response.Data = _mapper.Map<List<GetBandDto>>(bands);
                response.Success = true;
                return response;

            }
            var list = await collection.ToListAsync();
            response.Data = _mapper.Map<List<GetBandDto>>(list);
            response.Success = true;
            return response;
            //searching

        }

        public async Task<ServiceResponse<GetBandDto>> UpdateBand(UpdateBandDto updateBand)
        {
            var response= new ServiceResponse<GetBandDto>();
            try
            {
                var entity = _mapper.Map<Band>(updateBand);
                var exist = await _context.Bands.FirstOrDefaultAsync(x => x.Id == updateBand.Id);
                if (entity==null || exist==null)
                {
                    response.Success = false;
                    response.Message = "Something went wrong!";
                    return response;
                }
                _mapper.Map(updateBand, exist);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetBandDto>(exist);
                response.Message = $"Band {exist.Name} successfully updated!";
                response.Success = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }
    }
}
