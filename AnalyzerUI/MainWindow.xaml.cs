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

            this.mainFrame.Navigate(new HomePage());
        }

        public void ShowChannel(ChannelStatisticsDTO channel) 
        {
            this.mainFrame.Navigate(new ChannelPage(channel, this.DataContext as AnalyzerViewModel));
        }

        public void ShowVideo(VideoStatisticsDTO video)
        {
            this.mainFrame.Navigate(new VideoPage(video, this.DataContext as AnalyzerViewModel));
        }

        public void ShowChannelList() 
        {
            this.mainFrame.Navigate(new ChannelListPage(this.DataContext as AnalyzerViewModel));
        }

        public void ShowVideoList()
        {
            this.mainFrame.Navigate(new VideoListPage(this.DataContext as AnalyzerViewModel));
        }

        private void typesCB_Loaded(object sender, RoutedEventArgs e)
        {

            this.typesCB.SelectedItem = this.typesCB.Items[0];
        }

        private void menuBT_Click(object sender, RoutedEventArgs e)
        {
            if (this._menuState == MenuState.Oppened)
            {
                bodyGrid.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Star);
                this._menuState = MenuState.Closed;
            }
            else
            {
                bodyGrid.ColumnDefinitions[0].Width = new GridLength(0.35, GridUnitType.Star);
                this._menuState = MenuState.Oppened;
            }
        }

        private void homeBT_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(new HomePage());
        }

        private void infoBT_Click(object sender, RoutedEventArgs e)
        {
            this.mainFrame.Navigate(new InfoPage());
        }

        private MenuState _menuState;
    }

    public enum MenuState 
    {
        Oppened,
        Closed
    }
}