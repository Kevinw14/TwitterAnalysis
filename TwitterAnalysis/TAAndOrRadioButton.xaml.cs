using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TwitterAnalysis
{
    public interface TAAndOrRadioButtonDelegate
    {
        void addButtonPressed();
    }
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

        public TAAndOrRadioButtonDelegate? Delegate { get; set; }
        public TAAndOrRadioButton()
        {
            InitializeComponent();
            this.condition = Conditional.AND;
            this.Delegate = null;
        }

        private void ANDButton_Click(object sender, RoutedEventArgs e)
        {
            condition = Conditional.AND;
            ORButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            ANDButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 239, 35, 60));
        }

        private void ORButton_Click(object sender, RoutedEventArgs e)
        {
            condition = Conditional.OR;
            ANDButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 255, 255, 255));
            ORButton.Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 239, 35, 60));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Delegate?.addButtonPressed();
        }
    }
}
