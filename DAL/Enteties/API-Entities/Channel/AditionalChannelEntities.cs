namespace DAL.Enteties.API_Entities.Channel
{
    public class SnippetChannelEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ThumbnailsResponse Thumbnails { get; set; }
    }

    public class StatisticsChannelEntity
    {
        public string ViewCount { get; set; } = string.Empty;
        public string SubscriberCount { get; set; } = string.Empty;
        public string VideoCount { get; set; } = string.Empty;
    }

}
