using System;
using System.Windows;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft;
using System.Net.Http;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;
using TwitterAnalysis.TwitterAPI;
using System.Windows.Documents;
using System.Collections.Generic;

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
            string query_text = SearchTextBox.Text;
            client = new TwitterClient(Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            List<TweetSearchQuery> search_queries = new List<TweetSearchQuery>();
            List<FilterItem> radford_filters = new List<FilterItem>();
            List<FilterItem> university_filters = new List<FilterItem>();
            radford_filters.Add(new FilterItem(false, Filter.RETWEET));
            university_filters.Add(new FilterItem(true, Filter.HASHTAGS));
            TweetSearchQuery radford_search_query = new TweetSearchQuery(query_text, radford_filters);
            TweetSearchQuery university_search_query = new TweetSearchQuery("University", university_filters);
            search_queries.Add(radford_search_query);
            search_queries.Add(university_search_query);
            TweetSearchRequest search_request = new TweetSearchRequest(Timeline.RECENT, null, null, null, null, null, null, search_queries);
            TweetSearchResponse? TweetResponse = await client.searchTweetsURL(search_request);
        }
    }
}
