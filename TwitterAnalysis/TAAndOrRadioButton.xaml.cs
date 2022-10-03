using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TwitterAPI;

namespace TwitterAnalysis
{
    public enum Conditional
    {
        AND,
        OR
    }
    public partial class TAAndOrRadioButton : UserControl
    {
        private TweetConditional conditional;

        public TweetConditional Conditional
        {
            get { return conditional; }
        }
        public TAAndOrRadioButton()
        {
            InitializeComponent();
            this.conditional = TweetConditional.AND;
        }

        private void ANDButton_Click(object sender, RoutedEventArgs e)
        {
            conditional = TweetConditional.AND;
            ORButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            ANDButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 239, 35, 60));
        }

        private void ORButton_Click(object sender, RoutedEventArgs e)
        {
            conditional = TweetConditional.OR;
            ANDButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            ORButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 239, 35, 60));
        }
    }
}
