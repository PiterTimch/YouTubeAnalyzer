namespace DAL.Enteties.API_Entities.Video
{
    public class SnippetVideoEntity 
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;
        public ThumbnailsResponse Thumbnails { get; set; }
    }

    public class StatisticsVideoEntity 
    {
        public string ViewCount { get; set; } = string.Empty;
        public string LikeCount { get; set; } = string.Empty;
        public string CommentCount { get; set; } = string.Empty;
    }
}
