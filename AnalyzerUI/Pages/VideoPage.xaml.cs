using BLL.Models.DTOs;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            this.videoTitleTB.Text = video.Title;
            this.videoURL.NavigateUri = new Uri(video.Url);
            this.descriptionTB.Text = video.Description;
            this.likesCountTB.Text = video.LikesCount.ToString(); // додати форматування
            this.viewsCountTB.Text = video.ViewsCount.ToString();
            this.commentsCountTB.Text = video.CommentsCount.ToString();

            //винести в дизайнер
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(video.PreviewUrl, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            this.previewIMG.ImageSource = bitmap;
        }
    }
}
