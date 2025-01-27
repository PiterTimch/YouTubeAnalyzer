namespace DAL.Enteties.API_Entities.Video
{
    public class SnippetVideoEntity 
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;
        public VideoThumbnails Thumbnails { get; set; }
    }

    public class StatisticsVideoEntity 
    {
        public string ViewCount { get; set; } = string.Empty;
        public string LikeCount { get; set; } = string.Empty;
        public string CommentCount { get; set; } = string.Empty;
    }

    public class VideoThumbnails
    {
        public MaxresThumbnail Maxres { get; set; }
    }

    public class MaxresThumbnail
    {
        public string Url { get; set; } = string.Empty;
    }
}
