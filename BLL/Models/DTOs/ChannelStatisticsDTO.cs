﻿namespace BLL.Models.DTOs
{
    public class ChannelStatisticsDTO
    {
        public int Id { get; set; }
        public string ChannelName { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ViewsCount { get; set; } = string.Empty;
        public int SubsCount { get; set; }
        public int VideosCount { get; set; }
        public string AvatarUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        ICollection<VideoStatisticsDTO> VideoStatistics { get; set; }
    }
}
