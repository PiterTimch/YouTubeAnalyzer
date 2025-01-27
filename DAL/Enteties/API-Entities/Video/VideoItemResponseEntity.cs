
namespace DAL.Enteties.API_Entities.Video
{
    public class VideoItemResponseEntity
    {
        public string Id { get; set; } = string.Empty;
        public SnippetVideoEntity Snippet { get; set; }
        public StatisticsVideoEntity Statistics { get; set; }
    }
}
