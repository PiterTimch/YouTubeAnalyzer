namespace AnalyzerUI.Additional
{
    public class SearchModel
    {
        public string ItemId { get; set; } = string.Empty;
        SearchType? SearchType { get; set; }
    }

    public enum SearchType
    {
        None,
        Channel,
        Video
    }
}
