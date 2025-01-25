using BLL.Models.DTOs;

namespace BLL.Interfaces
{
    public interface IYouTubeStatisticsService
    {
        Task<ICollection<ChannelStatisticsDTO>> GetAllChannelsAsync();
        Task AddChannelAsync(ChannelStatisticsDTO item);
        Task DeleteChannelAsync(ChannelStatisticsDTO item);

        Task<ICollection<VideoStatisticsDTO>> GetAllVideosAsync();
        Task AddVideoAsync(VideoStatisticsDTO item);
        Task DeleteVideoAsync(VideoStatisticsDTO item);
    }
}
