using System.Windows;

namespace Practice_9_1_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ListBox1.ItemsSource = SplitText(TextBox1.Text);
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Label1.Content = ReversWords(TextBox2.Text);
        }

        static string ReversWords(string inputPhrase)
        {
            string[] words = inputPhrase.Split(' ');
            string resultString = "";

            for (int i = words.Length - 1; i >= 0; i--)
            {
                resultString += words[i] + " ";
            }

            return resultString;
        }

        static string[] SplitText(string text)
        {
            return text.Split(' ');
        }
    }
}
