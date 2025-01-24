using DAL.Contexts;
using DAL.Enteties;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class YouTubeStatisticsRepository : IYouTubeStatisticsRepository
    {
        public YouTubeStatisticsRepository() 
        {
            this._context = new YouTubeAnalyticsContext();
        }

        public void AddChannel(ChannelStatisticsEntity item)
        {
            this._context.Channels.Add(item);
        }

        public void AddVideo(VideoStatisticsEntity item)
        {
            this._context.Videos.Add(item);
        }

        public void DeleteChannel(ChannelStatisticsEntity item)
        {
            this._context.Channels.Remove(item);
        }

        public void DeleteVideo(VideoStatisticsEntity item)
        {
            this._context.Videos.Remove(item);
        }

        public ICollection<ChannelStatisticsEntity> GetAllChannels()
        {
            return this._context.Channels.ToList();
        }

        public ICollection<VideoStatisticsEntity> GetAllVideos()
        {
            return this._context.Videos.ToList();
        }

        private YouTubeAnalyticsContext _context;
    }
}
