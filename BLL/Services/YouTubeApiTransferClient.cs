using AutoMapper;
using BLL.Interfaces;
using BLL.Mapping;
using BLL.Models.DTOs;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class YouTubeApiTransferClient : IYouTubeApiTransferClient
    {
        public YouTubeApiTransferClient() 
        {
            this._apiClient = new YouTubeApiClient();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            this._mapper = config.CreateMapper();
        }

        public async Task<ChannelStatisticsDTO> GetChannelStatisticsAsync(string channelId)
        {
            return this._mapper.Map<ChannelStatisticsDTO>(await this._apiClient.GetChannelStatisticsAsync(channelId));
        }

        public async Task<VideoStatisticsDTO> GetVideoStatisticsAsync(string videoId)
        {
            return this._mapper.Map<VideoStatisticsDTO>(await this._apiClient.GetVideoStatisticsAsync(videoId));
        }

        private IYouTubeApiClient _apiClient;
        private IMapper _mapper;
    }
}
