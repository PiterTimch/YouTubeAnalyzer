using DAL.Repositories;

namespace TestConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            YouTubeApiClient apiClient = new YouTubeApiClient();

            await apiClient.GetVideoStatisticsAsync("-mxhWiG9L-I");
        }
    }
}
