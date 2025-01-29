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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void instructionTB_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text =
                "This is an application for searching YouTube channels and videos along with their statistics.\n\n" +
                "How to search:\n" +
                "1. Select the type of item you are looking for: video/channel.\n" +
                "2. Paste the ID of the item into the search bar.\n" +
                "3. Click the search button.\n\n" +
                "Where to find the ID?\n\n" +
                "For videos:\n" +
                "1. Open the video page.\n" +
                "2. Copy all the characters in the URL after \"watch?v=\".\n\n" +
                "For channels:\n" +
                "1. Open the channel page.\n" +
                "2. Right-click on an empty space.\n" +
                "3. Select \"View page source\".\n" +
                "4. In the opened window, search for the line \"channel_id=CHANNEL_KEY\" using the Ctrl+F search function.";

        }
    }
}
