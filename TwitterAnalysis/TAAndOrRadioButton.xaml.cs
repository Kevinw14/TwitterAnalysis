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
    public enum Conditional
    {
        AND,
        OR
    }
    public partial class TAAndOrRadioButton : UserControl
    {
        private Conditional condition;

        public Conditional Conditional
        {
            get { return condition; }
        }
        public TAAndOrRadioButton()
        {
            InitializeComponent();
            this.condition = Conditional.AND;
        }

        private void ANDButton_Click(object sender, RoutedEventArgs e)
        {
            condition = Conditional.AND;
            ORButton.Background = new SolidColorBrush(Color.FromArgb(100, 181, 181, 181));
        }

        private void ORButton_Click(object sender, RoutedEventArgs e)
        {
            condition = Conditional.OR;
            ANDButton.Background = new SolidColorBrush(Color.FromArgb(100, 181, 181, 181));
        }
    }
}
