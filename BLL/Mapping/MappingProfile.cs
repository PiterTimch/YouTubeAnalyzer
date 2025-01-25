using AutoMapper;
using BLL.Models.DTOs;
using DAL.Enteties.API_Entities.Channel;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ChannelStatisticsDTO, ChannelItemResponseEntity>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<ChannelItemResponseEntity, ChannelStatisticsDTO>();

            CreateMap<VideoStatisticsDTO, VideoStatisticsDTO>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<VideoStatisticsDTO, VideoStatisticsDTO>();
        }
    }
}
