using System;
using System.Windows;
using TwitterAPI;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

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
                string size_of_tweets = SearchResponse.Data.Data.Count.ToString();
                string size_of_users = SearchResponse.Data.Includes.Users.Count.ToString();
                TweetTableView.Datasource = this;
                this.TweetSearchData = SearchResponse.Data;
                TweetTableView.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public int NumberOfRows()
        {
            return TweetSearchData.Meta.Result_Count;
        }

        public TableViewCell TableViewCellAtIndexPath(IndexPath IndexPath)
        {
            Tweet Tweet = TweetSearchData.Data[IndexPath.Row];
            User? User = TweetSearchData.Includes.Users.Find(element => element.Id == Tweet.Author_Id);
            TweetTableViewCell Cell = new TweetTableViewCell(IndexPath);
            Cell.TweetLabel.Text = Tweet.Text;
            Cell.UsernameLabel.Content = User?.Username;
            Cell.ProfileImage.Source = new BitmapImage(new Uri(User!.profile_image_url));
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
