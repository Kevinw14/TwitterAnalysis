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
        }

        public async void TweetSearchWindowExecuteButtonPressed(TweetSearchRequest TweetSearchRequest)
        {
            TwitterClient Client = new TwitterClient(Environment.GetEnvironmentVariable("BEARER_TOKEN"));
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

        private void Search_Menu_Item_Click(object sender, RoutedEventArgs e)
        {
            TweetSearchWindow TweetSearchWindow = new TweetSearchWindow();
            TweetSearchWindow.Delegate = this;
            TweetSearchWindow.Show();
        }

        private void Token_Menu_Item_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
