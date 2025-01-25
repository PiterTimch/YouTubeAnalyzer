using BLL.Models.DTOs;

namespace BLL.Interfaces
{
    public interface IYouTubeApiTransferClient
    {
        public Task<ChannelStatisticsDTO> GetChannelStatisticsAsync(string channelId);
        public Task<VideoStatisticsDTO> GetVideoStatisticsAsync(string videoId);
    }
}
