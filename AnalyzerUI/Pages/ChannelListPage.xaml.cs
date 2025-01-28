using AnalyzerUI.ViewModels;
using System.Windows.Controls;

namespace AnalyzerUI.Pages
{
    /// <summary>
    /// Interaction logic for ChannelListPage.xaml
    /// </summary>
    public partial class ChannelListPage : Page
    {
        public ChannelListPage(AnalyzerViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
