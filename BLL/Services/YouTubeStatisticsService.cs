using AutoMapper;
using BLL.Interfaces;
using BLL.Mapping;
using BLL.Models.DTOs;
using DAL.Enteties;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class YouTubeStatisticsService : IYouTubeStatisticsService
    {
        public YouTubeStatisticsService() 
        {
            this._repository = new YouTubeStatisticsRepository();
            
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            this._mapper = config.CreateMapper();
        }

        public async Task AddChannelAsync(ChannelStatisticsDTO item)
        {
            await this._repository.AddChannelAsync(this._mapper.Map<ChannelStatisticsEntity>(item));
        }

        public async Task AddVideoAsync(VideoStatisticsDTO item)
        {
            await this._repository.AddVideoAsync(this._mapper.Map<VideoStatisticsEntity>(item));
        }

        public async Task DeleteChannelAsync(ChannelStatisticsDTO item)
        {
            await this._repository.DeleteChannelAsync(this._mapper.Map<ChannelStatisticsEntity>(item));
        }

        public async Task DeleteVideoAsync(VideoStatisticsDTO item)
        {
            await this._repository.DeleteVideoAsync(this._mapper.Map<VideoStatisticsEntity>(item));
        }

        public async Task<ICollection<ChannelStatisticsDTO>> GetAllChannelsAsync()
        {
            return (await this._repository.GetAllChannelsAsync()).Select(c => this._mapper.Map<ChannelStatisticsDTO>(c)).ToList();
        }

        public async Task<ICollection<VideoStatisticsDTO>> GetAllVideosAsync()
        {
            return (await this._repository.GetAllVideosAsync()).Select(v => this._mapper.Map<VideoStatisticsDTO>(v)).ToList();
        }

        private IYouTubeStatisticsRepository _repository;
        private readonly IMapper _mapper;
    }
}
