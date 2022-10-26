using System.Windows.Controls;
using System.Collections.Generic;
using System.Windows;

namespace TwitterAnalysis
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    /// 

    public interface TableViewDatasource
    {
        public int NumberOfRows();
        public TableViewCell TableViewCellAtIndexPath(IndexPath IndexPath);
    }
    public partial class TableView : UserControl
    {
        public TableViewDatasource? Datasource { get;  set; }

        public TableView()
        {
            InitializeComponent();
            setup();
        }

        public void Refresh()
        {
            setup();
        }

        private void setup()
        {
            int? number_of_rows = Datasource?.NumberOfRows();

            for(int i = 0; i < number_of_rows; i++)
            {
                IndexPath IndexPath = new IndexPath(i);
                TableViewCell? Cell = Datasource?.TableViewCellAtIndexPath(IndexPath);
                RowDefinition CellRowDefinition = new RowDefinition();
                CellRowDefinition.Height = GridLength.Auto;
                this.TweetGrid.RowDefinitions.Add(CellRowDefinition);
                this.TweetGrid.Children.Add(Cell);
                Grid.SetRow(Cell, i);
            }
        }
    }
}
