using DAL.Enteties;

namespace DAL.Interfaces
{
    public interface IYouTubeApiClient
    {
        public Task<ChannelStatisticsEntity> GetChannelStatisticsAsync(string channelId);
        public Task<VideoStatisticsEntity> GetVideoStatisticsAsync(string videoId);
    }
}
