using AnalyzerUI.Additional;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Services;
using System.Collections.ObjectModel;

namespace AnalyzerUI.ViewModels
{
    public class AnalyzerViewModel
    {
        public VideoStatisticsDTO SelectedVideo {  get; set; }
        public ChannelStatisticsDTO SelectedChannel {  get; set; }

        public SearchModel SearchModel { get; set; }
        public ObservableCollection<SearchType> SearchTypes { get; set; }

        public MainWindow MainWindow { get; set; }

        #region RealisedCommands
        public BaseCommand SearchModelCommand 
        {
            get 
            {
                return _searchModelCommand ??= new BaseCommand(async _ => 
                {
                    if (IsValidSearch()) 
                    {
                        if (this.SearchModel.SearchType == SearchType.Channel)
                        {
                            this.MainWindow.ShowChannel(await this._apiClient.GetChannelStatisticsAsync(this.SearchModel.ItemId));
                        }
                        else
                        {
                            this.MainWindow.ShowVideo(await this._apiClient.GetVideoStatisticsAsync(this.SearchModel.ItemId));
                        }
                    }
                    else
                    {
                        throw new Exception("Invalid search properties");
                    }

                });
            }
        }


        #endregion

        public AnalyzerViewModel() 
        {
            this.SelectedVideo = new VideoStatisticsDTO();
            this.SelectedChannel = new ChannelStatisticsDTO();

            this.SearchModel = new SearchModel();
            this.SearchTypes = new ObservableCollection<SearchType>((SearchType[])Enum.GetValues(typeof(SearchType)));

            this._statisticsService = new YouTubeStatisticsService();
            this._apiClient = new YouTubeApiTransferClient();
        }

        #region Validation
        private bool IsValidSearch()
        {
            if (this.SearchModel == null)
                return false;
            if (this.SearchModel.SearchType == SearchType.None)
                return false;
            if (String.IsNullOrEmpty(this.SearchModel.ItemId) || String.IsNullOrWhiteSpace(this.SearchModel.ItemId))
                return false;

            return true;
        }
        #endregion

        private BaseCommand _searchModelCommand;

        private IYouTubeStatisticsService _statisticsService;
        private IYouTubeApiTransferClient _apiClient;
    }
}
