using System;
using System.Windows;
using TwitterAPI;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;

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

        public async void TweetSearchWindowExecuteButtonPressed(TweetSearchRequest TweetSearchRequest)
        {
            TwitterClient Client = new TwitterClient(Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            MessageBox.Show(Client.TweetSearchURL(TweetSearchRequest));
            try
            {
                APIResponse<TweetSearchData> SearchResponse = await Client.SearchTweets(TweetSearchRequest);
                TweetDataGrid.ItemsSource = SearchResponse.Data.Data;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
