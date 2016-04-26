using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Field
    {
        private readonly int _lineCount;
        private readonly int _columnCount;
        public Field(int lineCount, int columnCount)
        {
            this._lineCount = lineCount;
            this._columnCount = columnCount;
        }

        public int LineCount { get { return _lineCount; } }
        public int ColumnCount { get { return _columnCount; } }
    }
}
 