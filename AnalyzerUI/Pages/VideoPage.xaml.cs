using AnalyzerUI.Additional;
using AnalyzerUI.ViewModels;
using BLL.Models.DTOs;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace AnalyzerUI.Pages
{
    /// <summary>
    /// Interaction logic for VideoPage.xaml
    /// </summary>
    public partial class VideoPage : Page
    {
        public VideoPage(VideoStatisticsDTO video, AnalyzerViewModel viewModel)
        {
            InitializeComponent();
            InitializeData(video);
            this.DataContext = viewModel;
        }

        private void InitializeData(VideoStatisticsDTO video)
        {
            this.videoTitleTB.Text =  Designer.TrimString(video.Title, 20);
            this.videoURL.NavigateUri = new Uri(video.Url);
            this.descriptionTB.Text = Designer.TrimString(video.Description, 500);
            this.likesCountTB.Text = Designer.FormatNumbers(video.LikesCount.ToString());
            this.viewsCountTB.Text = Designer.FormatNumbers(video.ViewsCount);
            this.commentsCountTB.Text = Designer.FormatNumbers(video.CommentsCount.ToString());

            this.previewIMG.ImageSource = Designer.LoadImageByURL(video.PreviewUrl);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
