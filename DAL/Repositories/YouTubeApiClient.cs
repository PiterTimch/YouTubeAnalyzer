using DAL.Constants;
using DAL.Enteties;
using DAL.Enteties.API_Entities;
using DAL.Enteties.API_Entities.Channel;
using DAL.Enteties.API_Entities.Video;
using DAL.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;
using System.Threading.Channels;

namespace DAL.Repositories
{
    public class YouTubeApiClient : IYouTubeApiClient
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
                AvatarUrl = item.Snippet.Thumbnails.High.Url,
                Description = item.Snippet.Description
            };

            return channelEntity;
        }

        public async Task<VideoStatisticsEntity> GetVideoStatisticsAsync(string videoId) 
        {
            string requestUrl = $"{DataAccessConstants.ApiUrl}videos?part=snippet,statistics&id={videoId}&key={DataAccessConstants.ApiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }

            string jsonResponse = await response.Content.ReadAsStringAsync();

            var videoResponse = JsonConvert.DeserializeObject<StandartResponse<VideoItemResponseEntity>>(jsonResponse);
            VideoItemResponseEntity? item = videoResponse?.Items.FirstOrDefault(v => v.Id == videoId);

            if (item == null)
            {
                throw new Exception("Invalid data");
            }

            var videoEntity = new VideoStatisticsEntity
            {
                Title = item.Snippet.Title,
                Url = $"https://www.youtube.com/watch?v={item.Id}",
                CommentsCount = Int32.Parse(item.Statistics.CommentCount),
                LikesCount = Int32.Parse(item.Statistics.LikeCount),
                ViewsCount = Int32.Parse(item.Statistics.ViewCount),
                ChannelUrl = $"https://www.youtube.com/channel/{item.Snippet.ChannelId}",
                Description = item.Snippet.Description,
                PreviewUrl = item.Snippet.Thumbnails.Maxres.Url
            };

            return videoEntity;
        }

        private readonly HttpClient _httpClient;
    }
}
