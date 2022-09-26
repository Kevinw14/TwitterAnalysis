using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for CalendarButton.xaml
    /// </summary>
    public partial class CalendarButton : UserControl
    {
        private bool is_open;
        public CalendarButton(string Label)
        {
            InitializeComponent();
            is_open = false;
            CalendarDateRange StartBlackOutDateRange = new CalendarDateRange();
            CalendarDateRange EndBlackOutDateRange = new CalendarDateRange();
            StartBlackOutDateRange.End = new DateTime(2006, 3, 20);
            EndBlackOutDateRange.Start = DateTime.Today.AddDays(1);
            Calendar.BlackoutDates.Add(StartBlackOutDateRange);
            Calendar.BlackoutDates.Add(EndBlackOutDateRange);
            SelectDateLabel.Content = Label;
        }

        private void PopupCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

            CalendarPopUp.IsOpen = false;
            DateTime? SelectedDate = Calendar.SelectedDate;
            SelectDateButton.Content = SelectedDate?.ToString("MMM-dd-yyyy");
            is_open = false;
        }

        private void SelectDateButton_Click(object sender, RoutedEventArgs e)
        {
            is_open = !is_open;
            CalendarPopUp.IsOpen = is_open;
        }
    }
}
