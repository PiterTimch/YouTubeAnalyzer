namespace DAL.Enteties.API_Entities
{
    public class ThumbnailsResponse
    {
        public Thumbnail High { get; set; }
    }

    public class Thumbnail
    {
        public string Url { get; set; } = string.Empty;
    }
}
