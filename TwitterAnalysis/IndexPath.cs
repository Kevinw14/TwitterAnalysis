using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterAnalysis
{
    public class IndexPath
    {
        private int row;
        public int Row { get { return row; } }

        public IndexPath(int row)
        {
            this.row = row;
        }
    }
}
