using System;
using System.Windows;
using TwitterAPI;
using System.Collections.Generic;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TweetSearchWindow Window = new TweetSearchWindow();
            Window.Show();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //string query_text = SearchTextBox.Text;
            //TwitterClient Client = new TwitterClient(Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            //List<TweetSearchQuery> Queries = new List<TweetSearchQuery>();
            //TweetSearchQuery Query = new TweetSearchQuery(query_text);
            //Queries.Add(Query);
            //TweetSearchRequest SearchRequest = new TweetSearchRequest();
            //SearchRequest.Queries = Queries;
            //SearchRequest.Timeline = Timeline.RECENT;
            //SearchRequest.MaxResults = 5;
            //APIResponse<TweetSearchData> SearchData = await Client.SearchTweets(SearchRequest);
            //for (int i = 0; i < SearchData.Data.Data.Count; i++)
            //{
            //    Tweet Tweet = SearchData.Data.Data[i];
            //    MessageBox.Show(Tweet.Text);
            //}
        }
    }
}
