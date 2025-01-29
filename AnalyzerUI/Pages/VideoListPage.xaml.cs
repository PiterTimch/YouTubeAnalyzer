using AnalyzerUI.ViewModels;
using System.Windows.Controls;

namespace AnalyzerUI.Pages
{
    /// <summary>
    /// Interaction logic for VideoListPage.xaml
    /// </summary>
    public partial class VideoListPage : Page
    {
        public VideoListPage(AnalyzerViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
