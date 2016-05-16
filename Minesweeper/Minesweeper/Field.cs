using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Field
    {
        private readonly int _lineCount;
        private readonly int _columnCount;
        private IList<Cell> _cellList;
        public event Action<Cell> CellChanged;

        public Field(int lineCount, int columnCount)
        {
            Debug.Assert(lineCount > 0 && columnCount > 0, "フィールドは1x1マス以上");

            this._lineCount = lineCount;
            this._columnCount = columnCount;

            _cellList = new List<Cell>();
            for (int row = 0; row < lineCount; row++)
            {
                for (int col = 0; col < columnCount; col++)
                {
                    _cellList.Add(new Cell(row, col));
                }
            }
        }

        public int LineCount { get { return _lineCount; } }
        public int ColumnCount { get { return _columnCount; } }

        public Cell GetCell(int row, int column)
        {
            foreach (var cell in _cellList)
            {
                if (cell.Row == row && cell.Column == column)
                    return cell;
            }
            return null;
        }

        public void Open(int row, int column)
        {
            Debug.Assert(row < _lineCount && column < ColumnCount, "存在しないセルは指定できません");

            Cell cell = GetCell(row, column);
            cell.Open();
            onCellChanged(cell);
        }

        private void onCellChanged(Cell cell)
        {
            if (CellChanged != null)
                CellChanged(cell);
        }
    }
}
 