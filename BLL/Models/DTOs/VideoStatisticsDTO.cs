namespace BLL.Models.DTOs
{
    public class VideoStatisticsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string ChannelUrl { get; set; } = string.Empty;
        public string ViewsCount { get; set; } = string.Empty;
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public string PreviewUrl { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int ChannelId { get; set; }

    }
}
