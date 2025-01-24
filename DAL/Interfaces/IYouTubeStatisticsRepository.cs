using DAL.Enteties;

namespace DAL.Interfaces
{
    public interface IYouTubeStatisticsRepository
    {
        ICollection<ChannelStatisticsEntity> GetAllChannels();
        void AddChannel(ChannelStatisticsEntity item);
        void DeleteChannel(ChannelStatisticsEntity item);

        ICollection<VideoStatisticsEntity> GetAllVideos();
        void AddVideo(VideoStatisticsEntity item);
        void DeleteVideo(VideoStatisticsEntity item);
    }
}
