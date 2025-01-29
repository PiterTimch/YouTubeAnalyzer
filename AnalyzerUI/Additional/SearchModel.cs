namespace AnalyzerUI.Additional
{
    public class SearchModel
    {
        public string ItemId { get; set; } = string.Empty;
        public SearchType? SearchType { get; set; }
    }

    public enum SearchType
    {
        Channel,
        Video
    }
}
