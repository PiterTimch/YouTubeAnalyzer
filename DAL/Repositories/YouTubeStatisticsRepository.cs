using DAL.Contexts;
using DAL.Enteties;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddChannelAsync(ChannelStatisticsEntity item)
        {
            await this._context.Channels.AddAsync(item);
        }

        public async Task AddVideoAsync(VideoStatisticsEntity item)
        {
            await this._context.Videos.AddAsync(item);
        }

        public void DeleteChannel(ChannelStatisticsEntity item)
        {
            this._context.Channels.Remove(item);
        }

        public void DeleteVideo(VideoStatisticsEntity item)
        {
            this._context.Videos.Remove(item);
        }

        public async Task<ICollection<ChannelStatisticsEntity>> GetAllChannelsAsync()
        {
            return await this._context.Channels.ToListAsync();
        }

        public async Task<ICollection<VideoStatisticsEntity>> GetAllVideosAsync()
        {
            return await this._context.Videos.ToListAsync();
        }

        private YouTubeAnalyticsContext _context;
    }
}
