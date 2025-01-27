using AnalyzerUI.Additional;
using BLL.Interfaces;
using BLL.Models.DTOs;

namespace AnalyzerUI.ViewModels
{
    public class AnalyzerViewModel
    {
        public VideoStatisticsDTO SelectedVideo {  get; set; }
        public ChannelStatisticsDTO SelectedChannel {  get; set; }

        public SearchModel SearchModel { get; set; }

        public MainWindow MainWindow { get; set; }


        private BaseCommand _searchModelCommand

        private IYouTubeStatisticsService _statisticsService;
    }
}
