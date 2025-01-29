using AnalyzerUI.Additional;
using BLL.Interfaces;
using BLL.Models.DTOs;
using BLL.Services;
using System.Collections.ObjectModel;
using System.Windows;

namespace AnalyzerUI.ViewModels
{
    public class AnalyzerViewModel
    {
        public VideoStatisticsDTO SelectedVideo {  get; set; }
        public ChannelStatisticsDTO SelectedChannel {  get; set; }

        public SearchModel SearchModel { get; set; }
        public ObservableCollection<SearchType> SearchTypes { get; set; }

        public ObservableCollection<VideoStatisticsDTO> Videos { get; set; }
        public ObservableCollection<ChannelStatisticsDTO> Channels { get; set; }

        public MainWindow MainWindow { get; set; }

        #region RealisedCommands
        public BaseCommand SearchModelCommand 
        {
            get 
            {
                return _searchModelCommand ??= new BaseCommand(async _ => 
                {
                    try
                    {
                        if (IsValidSearch())
                        {
                            if (this.SearchModel.SearchType == SearchType.Channel)
                            {
                                this.SelectedChannel = await this._apiClient.GetChannelStatisticsAsync(this.SearchModel.ItemId);
                                this.MainWindow.ShowChannel(this.SelectedChannel);
                            }
                            else
                            {
                                this.SelectedVideo = await this._apiClient.GetVideoStatisticsAsync(this.SearchModel.ItemId);
                                this.MainWindow.ShowVideo(this.SelectedVideo);
                            }
                        }
                        else
                        {
                            throw new Exception("Invalid search properties");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }

        public BaseCommand ReviewChannelCommand
        {
            get
            {
                return _reviewChannelCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        if (this.SelectedChannel != null)
                        {
                            this.MainWindow.ShowChannel(this.SelectedChannel);
                        }
                        else
                        {
                            throw new Exception("Channel is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }
        public BaseCommand ReviewVideoCommand
        {
            get
            {
                return _reviewChannelCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        if (this.SelectedVideo != null)
                        {
                            this.MainWindow.ShowVideo(this.SelectedVideo);
                        }
                        else
                        {
                            throw new Exception("Video is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }

        public BaseCommand AddChannelCommand
        {
            get
            {
                return _addChannelCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {   
                        if (this.SelectedChannel != null)
                        {
                            if ((await this._statisticsService.GetAllChannelsAsync()).FirstOrDefault(c => c.Url == this.SelectedChannel.Url) != null)
                            {
                                throw new Exception("This channel is already saved");
                            }

                            await this._statisticsService.AddChannelAsync(this.SelectedChannel);

                            Designer.ShowInfoMessage("Channel successfully saved. You can view it in \"Saved channels\"");
                        }
                        else
                        {
                            throw new Exception("Channel is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }
        public BaseCommand AddVideoCommand
        {
            get
            {
                return _addVideoCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        if (this.SelectedVideo != null)
                        {
                            if ((await this._statisticsService.GetAllVideosAsync()).FirstOrDefault(v => v.Url == this.SelectedVideo.Url) != null)
                            {
                                throw new Exception("This video is already saved");
                            }

                            await this._statisticsService.AddVideoAsync(this.SelectedVideo);

                            Designer.ShowInfoMessage("Video successfully saved. You can view it in \"Saved videos\"");
                        }
                        else
                        {
                            throw new Exception("Video is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }

        public BaseCommand RemoveChannelCommand 
        {
            get
            {
                return _removeChannelCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        if (this.SelectedChannel != null)
                        {
                            var channelVideos = (await this._statisticsService.GetAllVideosAsync()).Where(v => v.ChannelId == this.SelectedChannel.Id);

                            if (channelVideos.Any())
                            {
                                if (MessageBox.Show("You have saved this channel's videos. If you delete a channel, its videos will also disappear, continue?", "War", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                                {
                                    foreach (var video in channelVideos)
                                    {
                                        await this._statisticsService.DeleteVideoAsync(video);
                                    }
                                }
                                else
                                {
                                    return;
                                }
                            }

                            await this._statisticsService.DeleteChannelAsync(this.SelectedChannel);
                            await ReloadChannelsAsync();
                            Designer.ShowInfoMessage("Channel deleted successfully");
                        }
                        else
                        {
                            throw new Exception("Channel is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }
        public BaseCommand RemoveVideoCommand
        {
            get
            {
                return _removeVideoCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        if (this.SelectedVideo != null)
                        {

                            await this._statisticsService.DeleteVideoAsync(this.SelectedVideo);
                            await ReloadVideosAsync();
                            Designer.ShowInfoMessage("Video deleted successfully");
                        }
                        else
                        {
                            throw new Exception("Video is not selected");
                        }
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }

                });
            }
        }

        public BaseCommand GetSavedChannelsCommand
        {
            get
            {
                return _getSavedChannelsCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        await ReloadChannelsAsync();

                        this.MainWindow.ShowChannelList();
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
                    }
                });
            }
        }
        public BaseCommand GetSavedVideosCommand
        {
            get
            {
                return _getSavedVideosCommand ??= new BaseCommand(async _ =>
                {
                    try
                    {
                        await ReloadVideosAsync();

                        this.MainWindow.ShowVideoList();
                    }
                    catch (Exception ex)
                    {
                        Designer.ShowErrorMessage(ex.Message);
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

            this.Channels = new ObservableCollection<ChannelStatisticsDTO>();
            this.Videos = new ObservableCollection<VideoStatisticsDTO>();

            this._statisticsService = new YouTubeStatisticsService();
            this._apiClient = new YouTubeApiTransferClient();
        }

        #region Validation
        private bool IsValidSearch()
        {
            if (this.SearchModel == null)
                return false;
            if (String.IsNullOrEmpty(this.SearchModel.ItemId) || String.IsNullOrWhiteSpace(this.SearchModel.ItemId))
                return false;

            return true;
        }
        #endregion

        private async Task ReloadChannelsAsync()
        {
            this.Channels.Clear();
            foreach (var channel in await this._statisticsService.GetAllChannelsAsync())
            {
                this.Channels.Add(channel);
            }
        }
        private async Task ReloadVideosAsync()
        {
            this.Videos.Clear();
            foreach (var video in await this._statisticsService.GetAllVideosAsync())
            {
                this.Videos.Add(video);
            }
        }

        private BaseCommand _searchModelCommand;

        private BaseCommand _addChannelCommand;
        private BaseCommand _addVideoCommand;

        private BaseCommand _removeChannelCommand;
        private BaseCommand _removeVideoCommand;

        private BaseCommand _getSavedChannelsCommand;
        private BaseCommand _getSavedVideosCommand;

        private BaseCommand _reviewChannelCommand;
        private BaseCommand _reviewVideoCommand;

        private IYouTubeStatisticsService _statisticsService;
        private IYouTubeApiTransferClient _apiClient;
    }
}
