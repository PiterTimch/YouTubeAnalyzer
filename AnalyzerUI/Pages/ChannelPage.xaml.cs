using AnalyzerUI.Additional;
using AnalyzerUI.ViewModels;
using BLL.Models.DTOs;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AnalyzerUI.Pages
{
    /// <summary>
    /// Interaction logic for ChannelPage.xaml
    /// </summary>
    public partial class ChannelPage : Page
    {
        public ChannelPage(ChannelStatisticsDTO channel, AnalyzerViewModel viewModel)
        {
            InitializeComponent();
            InitializeData(channel);
            this.DataContext = viewModel;
        }

        private void InitializeData(ChannelStatisticsDTO channel)
        {
            this.channelNameTB.Text = Designer.TrimString(channel.ChannelName, 20);
            this.channelURL.NavigateUri = new Uri(channel.Url);
            this.descriptionTB.Text = Designer.TrimString(channel.Description, 500);
            this.subsCountTB.Text = Designer.FormatNumbers(channel.SubsCount.ToString());
            this.viewsCountTB.Text = Designer.FormatNumbers(channel.ViewsCount);
            this.videosCountTB.Text = Designer.FormatNumbers(channel.VideosCount.ToString());

            this.avatarIMG.ImageSource = Designer.LoadImageByURL(channel.AvatarUrl);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
