using AutoMapper;
using BLL.Models.DTOs;
using DAL.Enteties;
using DAL.Enteties.API_Entities.Channel;
using DAL.Enteties.API_Entities.Video;

namespace BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<ChannelStatisticsDTO, ChannelStatisticsEntity>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<ChannelStatisticsEntity, ChannelStatisticsDTO>();

            CreateMap<VideoStatisticsDTO, VideoStatisticsEntity>()
                .ForMember(d => d.Id, o => o.Ignore());
            CreateMap<VideoStatisticsEntity, VideoStatisticsDTO>();
        }
    }
}
