using BLL.Models.DTOs;
using BLL.Services;

namespace TestConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            YouTubeApiTransferClient apiClient = new YouTubeApiTransferClient();
            YouTubeStatisticsService statisticsService = new YouTubeStatisticsService();

            VideoStatisticsDTO video = await apiClient.GetVideoStatisticsAsync("-mxhWiG9L-I");
            await statisticsService.AddVideoAsync(video);
        }
    }
}
