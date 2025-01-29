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
    /// Interaction logic for InfoPage.xaml
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void infoText_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBlock).Text =
            "This application helps you create your own circle of interests and analyze interest in a specific topic. " +
            "You can search, analyze, and save content you like, and maybe even become a creator in the future!\n\n" +
            "Created by Petro and Natalia\n" +
            "©YourSoftware 2025. All rights reserved.";

        }
    }
}
