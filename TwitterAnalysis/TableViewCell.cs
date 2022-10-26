using System.Windows.Controls;

namespace TwitterAnalysis
{
    public partial class TableViewCell: UserControl
    {
        private IndexPath index_path;

        public IndexPath IndexPath
        {
            get
            {
                return index_path;
            }
        }

        public TableViewCell(IndexPath IndexPath)
        {
            this.index_path = IndexPath;
        }
    }
}
