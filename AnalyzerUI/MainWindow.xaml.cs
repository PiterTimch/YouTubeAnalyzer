using AnalyzerUI.Pages;
using AnalyzerUI.ViewModels;
using BLL.Models.DTOs;
using System.Windows;

namespace AnalyzerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(AnalyzerViewModel viewModel)
        {
            InitializeComponent();
            viewModel.MainWindow = this;
            this.DataContext = viewModel;
        }

        public void ShowChannel(ChannelStatisticsDTO channel) 
        {
            this.mainFrame.Navigate(new ChannelPage(channel));
        }

        public void ShowVideo(VideoStatisticsDTO video)
        {
            this.mainFrame.Navigate(new VideoPage(video));
        }

        public void ShowChannelList() 
        {
            this.mainFrame.Navigate(new ChannelListPage(this.DataContext as AnalyzerViewModel));
        }
    }
}