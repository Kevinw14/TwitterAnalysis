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
    public partial class MainWindow : Window, TweetSearchWindowDelegate, TableViewDatasource
    {
        private TweetSearchData TweetSearchData;
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
                TweetTableView.Datasource = this;
                this.TweetSearchData = SearchResponse.Data;
                MessageBox.Show(SearchResponse.Data.Includes.Users.Count.ToString());
                TweetTableView.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int NumberOfRows()
        {
            return TweetSearchData.Data.Count;
        }

        public TableViewCell TableViewCellAtIndexPath(IndexPath IndexPath)
        {
            Tweet Tweet = TweetSearchData.Data[IndexPath.Row];
            //User User = TweetSearchData.Includes.Users[IndexPath.Row];
            TweetTableViewCell Cell = new TweetTableViewCell(IndexPath);
            Cell.TweetLabel.Text = Tweet.Text;
            //Cell.UsernameLabel.Content = User.Username;
            return Cell;

        }
        private void Search_Menu_Item_Click(object sender, RoutedEventArgs e)
        {
            TweetSearchWindow TweetSearchWindow = new TweetSearchWindow();
            TweetSearchWindow.Delegate = this;
            TweetSearchWindow.Show();
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SentimentAnalysisRadioButton.IsChecked == true)
            {
                MessageBox.Show("Sentiment Analysis Executing");
            }
        }
    }
}
