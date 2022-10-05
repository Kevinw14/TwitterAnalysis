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

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for QueryView.xaml
    /// </summary>
    /// 
    public interface QueryViewDelegate
    {
        public void QueryViewDeleteButtonPressed(QueryView QueryView);
        public void QueryViewDidStartTyping(string text);
    }
    public partial class QueryView : UserControl
    {

        public QueryViewDelegate? Delegate { get; set; }
        public QueryView()
        {
            InitializeComponent();
            QueryTextBox.TextChanged += QueryTextBoxTextChanged;
        }

        private void QueryTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            Delegate?.QueryViewDidStartTyping(QueryTextBox.Text);
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delegate?.QueryViewDeleteButtonPressed(this);
        }
    }
}
