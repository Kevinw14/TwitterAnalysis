using System;
using System.Windows;
using TwitterAPI;
using System.Collections.Generic;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, TweetSearchWindowDelegate
    {
        public MainWindow()
        {
            InitializeComponent();
            TweetSearchWindow Window = new TweetSearchWindow();
            Window.Delegate = this;
            Window.Show();
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
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

        public async void TweetSearchWindowExecuteButtonPressed(TweetSearchRequest TweetSearchRequest)
        {
            for (int i = 0; i < TweetSearchRequest.Queries.Count; i++)
            {
                TweetSearchQuery Query = TweetSearchRequest.Queries[i];
                MessageBox.Show(Query.QueryString());
            }
            //TwitterClient Client = new TwitterClient(Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            //APIResponse<TweetSearchData> SearchData = await Client.SearchTweets(TweetSearchRequest);
            //for (int i = 0; i < SearchData.Data.Data.Count; i++)
            //{
            //    Tweet Tweet = SearchData.Data.Data[i];
            //    MessageBox.Show(Tweet.Text);
            //}
        }
    }
}
