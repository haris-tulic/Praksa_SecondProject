using AutoMapper;
using Praksa_SecondProject.Database;
using Praksa_SecondProject.DTO;

namespace Praksa_SecondProject.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GetBandDto, Band>().ReverseMap();
            CreateMap<AddBandDto, Band>().ReverseMap();
            CreateMap<UpdateBandDto, Band>().ReverseMap();

            CreateMap<GetAlbumDto, Album>().ReverseMap();
            CreateMap<AddAlbumDto, Album>().ReverseMap();
            CreateMap<UpdateAlbumDto, Album>().ReverseMap();

        }
    }
}
