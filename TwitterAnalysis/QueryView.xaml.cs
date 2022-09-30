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
    }
    public partial class QueryView : UserControl
    {

        public QueryViewDelegate? Delegate { get; set; }
        public QueryView()
        {
            InitializeComponent();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Delegate?.QueryViewDeleteButtonPressed(this);
        }
    }
}
