using AnalyzerUI.Additional;
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
        public VideoPage(VideoStatisticsDTO video)
        {
            InitializeComponent();
            InitializeData(video);
        }

        private void InitializeData(VideoStatisticsDTO video)
        {
            this.videoTitleTB.Text =  Designer.TrimString(video.Title, 20);
            this.videoURL.NavigateUri = new Uri(video.Url);
            this.descriptionTB.Text = Designer.TrimString(video.Description, 500);
            this.likesCountTB.Text = Designer.FormatNumbers(video.LikesCount.ToString());
            this.viewsCountTB.Text = Designer.FormatNumbers(video.ViewsCount);
            this.commentsCountTB.Text = Designer.FormatNumbers(video.CommentsCount.ToString());

            //винести в дизайнер
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(video.PreviewUrl, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            this.previewIMG.ImageSource = bitmap;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
