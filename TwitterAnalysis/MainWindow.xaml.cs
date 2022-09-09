using System;
using System.Windows;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TwitterClient client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string query = SearchTextBox.Text;
            client = new TwitterClient();
            TweetSearchResponse? TweetResponse = await client.searchTweetsURL(TwitterClient.Timeline.RECENT, query);
            TweetsTable.ItemsSource = TweetResponse?.Data;
            TweetsTable.Columns[0].Visibility = Visibility.Hidden;
        }
    }
}
