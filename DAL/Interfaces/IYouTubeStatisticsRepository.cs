using DAL.Enteties;

namespace DAL.Interfaces
{
    public interface IYouTubeStatisticsRepository
    {
        Task<ICollection<ChannelStatisticsEntity>> GetAllChannelsAsync();
        Task AddChannelAsync(ChannelStatisticsEntity item);
        void DeleteChannel(ChannelStatisticsEntity item);

        Task<ICollection<VideoStatisticsEntity>> GetAllVideosAsync();
        Task AddVideoAsync(VideoStatisticsEntity item);
        void DeleteVideo(VideoStatisticsEntity item);
    }
}
