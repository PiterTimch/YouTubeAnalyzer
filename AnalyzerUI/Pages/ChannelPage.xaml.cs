using BLL.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalyzerUI.Pages
{
    /// <summary>
    /// Interaction logic for ChannelPage.xaml
    /// </summary>
    public partial class ChannelPage : Page
    {
        public ChannelPage(ChannelStatisticsDTO channel)
        {
            InitializeComponent();
            InitializeData(channel);
        }

        private void InitializeData(ChannelStatisticsDTO channel)
        {
            this.channelNameTB.Text = channel.ChannelName;
            this.channelURL.NavigateUri = new Uri(channel.Url);
            this.descriptionTB.Text = channel.Description;
            this.subsCountTB.Text = channel.SubsCount.ToString(); // зробити форматування типу 21 324
            this.viewsCountTB.Text = channel.ViewsCount.ToString();
            this.videosCountTB.Text = channel.VideosCount.ToString();

            //винести в дизайнер
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(channel.AvatarUrl, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            this.avatarIMG.ImageSource = bitmap;
        }
    }
}
