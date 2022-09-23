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
    public partial class TweetSearchWindow : Window, TAAndOrRadioButtonDelegate
    {
        private int count = 4;
        public TweetSearchWindow()
        {
            InitializeComponent();
            AndOrRadioButton.Delegate = this;
        }

        public void addButtonPressed()
        {
            RowDefinition rowDefinition = new RowDefinition();
            QueryGrid.RowDefinitions.Add(rowDefinition);
            Button button = new Button();
            button.Name = "btn" + count;
            button.Click += ButtonClicked;
            button.Content = "Button " + count;
            button.Height = 30;
            QueryGrid.Children.Add(button);
            Grid.SetRow(button, QueryGrid.RowDefinitions.Count - 1);
            count++;
        }

        private void ButtonClicked(Object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int index = QueryGrid.Children.IndexOf(button);
            QueryGrid.Children.Remove(button);
            RowDefinition row_definition = QueryGrid.RowDefinitions[index];
            QueryGrid.RowDefinitions.Remove(row_definition);
        }
    }
}
