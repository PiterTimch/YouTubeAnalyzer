namespace BLL.Models.ApiModels
{
    public class VideoItemResponseDTO
    {
        public string Id { get; set; } = string.Empty;
        public SnippetVideoDTO Snippet { get; set; }
        public StatisticsVideoDTO Statistics { get; set; }
    }

    public class SnippetVideoDTO
    {
        public string Title { get; set; } = string.Empty;
        public string ChannelId { get; set; } = string.Empty;
    }

    public class StatisticsVideoDTO
    {
        public string ViewCount { get; set; } = string.Empty;
        public string LikeCount { get; set; } = string.Empty;
        public string CommentCount { get; set; } = string.Empty;
    }

}
