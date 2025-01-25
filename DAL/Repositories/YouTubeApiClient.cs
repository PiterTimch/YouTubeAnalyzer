using DAL.Constants;
using DAL.Enteties;
using DAL.Enteties.API_Entities;
using DAL.Enteties.API_Entities.Channel;
using Newtonsoft.Json;
using System.Text.Json;

namespace DAL.Repositories
{
    public class YouTubeApiClient
    {
        public YouTubeApiClient() 
        {
            this._httpClient = new HttpClient();
        }

        public async Task<ChannelStatisticsEntity> GetChannelStatisticsAsync(string channelId)
        {
            string requestUrl = $"{DataAccessConstants.ApiUrl}channels?part=snippet,statistics&id={channelId}&key={DataAccessConstants.ApiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            var channelResponse = JsonConvert.DeserializeObject<StandartResponse<ChannelItemResponseEntity>>(jsonResponse);
            ChannelItemResponseEntity? item = channelResponse?.Items.FirstOrDefault(c => c.Id == channelId);

            if (item == null)
            {
                throw new Exception("Invalid data");
            }

            var channelEntity = new ChannelStatisticsEntity
            {
                ChannelName = item.Snippet.Title,
                Url = $"https://www.youtube.com/channel/{item.Id}",
                SubsCount = Int32.Parse(item.Statistics.SubscriberCount),
                VideosCount = Int32.Parse(item.Statistics.VideoCount),
                ViewsCount = Int32.Parse(item.Statistics.ViewCount),
            };

            return channelEntity;
        }


        private readonly HttpClient _httpClient;
    }
}
