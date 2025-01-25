
namespace DAL.Enteties.API_Entities.Video
{
    public class VideoItemResponseEntity
    {
        public string Id { get; set; } = string.Empty;
        public SnippetVideoEntity Snippet { get; set; }
        public StatisticsVideoEntity Statistics { get; set; }
    }

    public class SnippetVideoEntity 
    {
        public string Title { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;
    }

    public class StatisticsVideoEntity 
    {
        public string ViewCount { get; set; } = string.Empty;
        public string LikeCount { get; set; } = string.Empty;
        public string CommentCount { get; set; } = string.Empty;
    }
}
