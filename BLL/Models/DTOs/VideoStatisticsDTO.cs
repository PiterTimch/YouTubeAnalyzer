﻿namespace BLL.Models.DTOs
{
    public class VideoStatisticsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ChannelUrl { get; set; } = string.Empty;
        public int ViewsCount { get; set; }
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }

    }
}
