using System.Windows;
using System.Windows.Media.Imaging;

namespace AnalyzerUI.Additional
{
    public static class Designer
    {
        public static string TrimString(string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0)
                return string.Empty;

            if (input.Length <= maxLength)
                return input;

            return input.Substring(0, maxLength) + "...";
        }

        public static string FormatNumbers(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            input = input.Replace(" ", "");
            if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d+$"))
                throw new ArgumentException("Invalid nums");

            char[] reversed = input.Reverse().ToArray();
            string reversedResult = string.Join(" ", Enumerable.Range(0, (reversed.Length + 2) / 3)
                .Select(i => new string(reversed.Skip(i * 3).Take(3).ToArray())));

            return new string(reversedResult.Reverse().ToArray());
        }

        public static BitmapImage LoadImageByURL(string url) 
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(url, UriKind.RelativeOrAbsolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            return bitmap;
        }

        public static void ShowInfoMessage(string msg) 
        {
            MessageBox.Show(msg, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public static void ShowErrorMessage(string msg) 
        {
            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
