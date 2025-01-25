namespace BLL.Models.ApiModels
{
    public class StandartResponseDTO<T> where T : class
    {
        public string Kind { get; set; } = string.Empty;
        public string Etag { get; set; } = string.Empty;
        public object PageInfo { get; set; } = new object();
        public ICollection<T> Items { get; set; }
    }
}
