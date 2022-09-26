using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for TweetSearchWindow.xaml
    /// </summary>
    /// 
    public interface TweetSearchWindowDelegate
    {

    }
    public partial class TweetSearchWindow : Window
    {
        public TweetSearchWindowDelegate? Delegate { get; set; }
        public TweetSearchWindow()
        {
            InitializeComponent();
        }

        public void addButtonPressed()
        {
            //RowDefinition rowDefinition = new RowDefinition();
            //QueryGrid.RowDefinitions.Add(rowDefinition);
            //Button button = new Button();
            //button.Name = "btn" + count;
            //button.Click += ButtonClicked;
            //button.Content = "Button " + count;
            //button.Height = 30;
            //QueryGrid.Children.Add(button);
            //Grid.SetRow(button, QueryGrid.RowDefinitions.Count - 1);
            //count++;
        }

        private void ButtonClicked(Object sender, RoutedEventArgs e)
        {
            //Button button = (Button)sender;
            //int index = QueryGrid.Children.IndexOf(button);
            //QueryGrid.Children.Remove(button);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem Item = (ComboBoxItem)QueryParamsComboBox.SelectedItem;
            ComboBoxItem SelectedItem = (ComboBoxItem)QueryParamsComboBox.SelectedItem;
            ComboBoxItem QueryItem = (ComboBoxItem)QueryParamsComboBox.Items[0];

            switch (Item.Content)
            {
                case "Query":

                    break;
                case "Start Time":
                    QueryParamsComboBox.Items.Remove(SelectedItem);
                    QueryParamsComboBox.SelectedItem = QueryItem;
                    RowDefinition StartTimeRowDefinition = new RowDefinition();
                    StartTimeRowDefinition.Height = GridLength.Auto;
                    QueryGrid.RowDefinitions.Add(StartTimeRowDefinition);
                    CalendarButton StartCalendarButton = new CalendarButton("Start Time");
                    QueryGrid.Children.Add(StartCalendarButton);
                    Grid.SetRow(StartCalendarButton, QueryGrid.RowDefinitions.Count - 1);
                    break;
                case "End Time":
                    QueryParamsComboBox.Items.Remove(SelectedItem);
                    QueryParamsComboBox.SelectedItem = QueryItem;
                    RowDefinition EndTimeRowDefinition = new RowDefinition();
                    EndTimeRowDefinition.Height = GridLength.Auto;
                    QueryGrid.RowDefinitions.Add(EndTimeRowDefinition);
                    CalendarButton EndCalendarButton = new CalendarButton("End Time");
                    QueryGrid.Children.Add(EndCalendarButton);
                    Grid.SetRow(EndCalendarButton, QueryGrid.RowDefinitions.Count - 1);
                    break;
                default: break;
            }
        }

        private void Calendar_DateChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar Calendar = (Calendar)sender;
            DateTime? Date = Calendar.SelectedDate;
            MessageBox.Show(Date.ToString());
        }
    }
}
