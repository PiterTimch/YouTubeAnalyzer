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
            await this._context.SaveChangesAsync();
        }

        public async Task AddVideoAsync(VideoStatisticsEntity item)
        {
            if (await this._context.Channels.FirstOrDefaultAsync(c => c.Url == item.ChannelUrl) != null) 
            {
                item.Channel = await this._context.Channels.FirstOrDefaultAsync(c => c.Url == item.ChannelUrl);
            }
            await this._context.Videos.AddAsync(item);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteChannelAsync(ChannelStatisticsEntity item)
        {
            this._context.Channels.Remove(item);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteVideoAsync(VideoStatisticsEntity item)
        {
            this._context.Videos.Remove(item);
            await this._context.SaveChangesAsync();
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
