using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TwitterAPI;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for TweetSearchWindow.xaml
    /// </summary>
    /// 
    public interface TweetSearchWindowDelegate
    {
        public void TweetSearchWindowExecuteButtonPressed(TweetSearchRequest TweetSearchRequest);
    }
    public partial class TweetSearchWindow : Window, CalendarButtonDelegate, QueryViewDelegate
    {
        public TweetSearchWindowDelegate? Delegate { get; set; }
        DateTime? start_time;
        DateTime? end_time;
        private Grid query_grid;
        public TweetSearchWindow()
        {
            InitializeComponent();
            RowDefinition QueryGridRowDefinition = new RowDefinition();
            QueryGridRowDefinition.Height = GridLength.Auto;
            ParamGrid.RowDefinitions.Add(QueryGridRowDefinition);
            query_grid = new Grid();
            query_grid.Margin = new Thickness(10, 0, 0, 0);
            ParamGrid.Children.Add(query_grid);
            Grid.SetRow(query_grid, 1);


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem Item = (ComboBoxItem)ParamsComboBox.SelectedItem;
            ComboBoxItem SelectedItem = (ComboBoxItem)ParamsComboBox.SelectedItem;
            ComboBoxItem QueryItem = (ComboBoxItem)ParamsComboBox.Items[0];

            switch (Item.Content)
            {
                case "Query":
                    QueryView QueryView = new QueryView();
                    QueryView.Delegate = this;

                    if (query_grid.Children.Count == 0)
                    {
                        QueryView.AndOrRadioButton.IsEnabled = false;
                    }

                    RowDefinition QueryViewRowDefinition = new RowDefinition();
                    QueryViewRowDefinition.Height = GridLength.Auto;
                    query_grid.RowDefinitions.Add(QueryViewRowDefinition);
                    query_grid.Children.Add(QueryView);
                    Grid.SetRow(QueryView, query_grid.RowDefinitions.Count - 1);
                    break;
                case "Start Time":
                    ParamsComboBox.Items.Remove(SelectedItem);
                    ParamsComboBox.SelectedItem = QueryItem;
                    RowDefinition StartTimeRowDefinition = new RowDefinition();
                    StartTimeRowDefinition.Height = GridLength.Auto;
                    ParamGrid.RowDefinitions.Add(StartTimeRowDefinition);
                    CalendarButton StartCalendarButton = new CalendarButton("Start Time");
                    StartCalendarButton.Delegate = this;
                    ParamGrid.Children.Add(StartCalendarButton);
                    Grid.SetRow(StartCalendarButton, 2);
                    break;
                case "End Time":
                    ParamsComboBox.Items.Remove(SelectedItem);
                    ParamsComboBox.SelectedItem = QueryItem;
                    RowDefinition EndTimeRowDefinition = new RowDefinition();
                    EndTimeRowDefinition.Height = GridLength.Auto;
                    ParamGrid.RowDefinitions.Add(EndTimeRowDefinition);
                    CalendarButton EndCalendarButton = new CalendarButton("End Time");
                    EndCalendarButton.Delegate = this;
                    ParamGrid.Children.Add(EndCalendarButton);
                    Grid.SetRow(EndCalendarButton, 3);
                    break;
                case "Max Results":
                    ParamsComboBox.Items.Remove(SelectedItem);
                    ParamsComboBox.SelectedItem = QueryItem;
                    RowDefinition MaxResultsRowDefinition = new RowDefinition();
                    MaxResultsRowDefinition.Height = GridLength.Auto;
                    ParamGrid.RowDefinitions.Add(MaxResultsRowDefinition);
                    break;
                default: break;
            }
        }

        public void CalendarButtonDeletePressed(CalendarButton CalendarButton)
        {
            ParamGrid.Children.Remove(CalendarButton);
            ComboBoxItem Item = new ComboBoxItem();
            Item.Content = CalendarButton.DescriptionLabel.Content;
            ParamsComboBox.Items.Add(Item);
        }

        public void CalendarButtonDateChanged(CalendarButton CalendarButton)
        {
            if (CalendarButton.DescriptionLabel.Content.Equals("Start Time"))
            {
                this.start_time = CalendarButton.Calendar.SelectedDate;
            } else if (CalendarButton.DescriptionLabel.Content.Equals("End Time"))
            {
                this.end_time = CalendarButton.Calendar.SelectedDate;
            }
        }
        public void QueryViewDeleteButtonPressed(QueryView QueryView)
        {
            query_grid.Children.Remove(QueryView);

            if (query_grid.Children.Count != 0)
            {
                QueryView first_query_view = (QueryView)query_grid.Children[0];
                first_query_view.AndOrRadioButton.IsEnabled = false;
                first_query_view.AndOrRadioButton.Conditional = TweetConditional.AND;
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            List<TweetSearchQuery> search_queries = new List<TweetSearchQuery>();
            for (int i = 0; i < query_grid.Children.Count; i++)
            {
                QueryView query_view = (QueryView)query_grid.Children[i];
                string query = query_view.QueryTextBox.Text;
                TweetSearchQuery search_query = new TweetSearchQuery(query, query_view.ExactPhraseCheckBox.IsChecked, query_view.AndOrRadioButton.Conditional, new List<TweetFilter>());
                search_queries.Add(search_query);
            }

            TweetSearchRequest SearchRequest = new TweetSearchRequest();
            SearchRequest.Queries = search_queries;
            SearchRequest.StartTime = start_time;
            SearchRequest.EndTime = end_time;
            SearchRequest.Expansions.Add(Expansion.AUTHOR_ID);
            SearchRequest.UserFields.Add(UserField.USERNAME);
            SearchRequest.UserFields.Add(UserField.VERIFIED);
            Delegate?.TweetSearchWindowExecuteButtonPressed(SearchRequest);
            this.Close();
        }

        public void QueryViewDidStartTyping(string text)
        {
            for(int i = 0; i < query_grid.Children.Count; i++)
            {
                QueryView query_view = (QueryView)query_grid.Children[i];
                if (!query_view.QueryTextBox.Text.Equals(""))
                {
                    ExecuteButton.IsEnabled = true;
                    break;
                } else
                {
                    ExecuteButton.IsEnabled = false;
                }
            }
        }
    }
}
