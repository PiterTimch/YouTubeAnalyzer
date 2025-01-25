using DAL.Enteties;

namespace DAL.Interfaces
{
    public interface IYouTubeStatisticsRepository
    {
        Task<ICollection<ChannelStatisticsEntity>> GetAllChannelsAsync();
        Task AddChannelAsync(ChannelStatisticsEntity item);
        Task DeleteChannelAsync(ChannelStatisticsEntity item);

        Task<ICollection<VideoStatisticsEntity>> GetAllVideosAsync();
        Task AddVideoAsync(VideoStatisticsEntity item);
        Task DeleteVideoAsync(VideoStatisticsEntity item);
    }
}
