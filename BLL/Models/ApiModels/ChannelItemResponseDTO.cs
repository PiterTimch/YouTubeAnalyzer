namespace BLL.Models.ApiModels
{
    public class ChannelItemResponseDTO
    {
        public string Id { get; set; } = string.Empty;
        public SnippetChannelDTO Snippet { get; set; }
        public StatisticsChannelDTO Statistics { get; set; }
    }

    public class SnippetChannelDTO
    {
        public string Title { get; set; } = string.Empty;
    }

    public class StatisticsChannelDTO
    {
        public string ViewCount { get; set; } = string.Empty;
        public string SubscriberCount { get; set; } = string.Empty;
        public string VideoCount { get; set; } = string.Empty;
    }
}
