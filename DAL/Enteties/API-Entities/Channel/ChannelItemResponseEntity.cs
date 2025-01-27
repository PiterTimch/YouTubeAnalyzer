namespace DAL.Enteties.API_Entities.Channel
{
    public class ChannelItemResponseEntity
    {
        public string Id { get; set; } = string.Empty;
        public SnippetChannelEntity Snippet { get; set; }
        public StatisticsChannelEntity Statistics { get; set; }
    }
}
