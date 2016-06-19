﻿using System;
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
        public event Action MineOpened;

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
        private IList<Cell> getAdjacentCells(int row, int colum)
        {
            var ret = new List<Cell>();
            foreach (var cell in _cellList)
            {
                if (cell.Row == row && cell.Column == colum)
                    continue;
                bool isLineAdjacent = cell.Row >= row - 1 && cell.Row <= row + 1;
                bool isColumnAdjacent = cell.Column >= colum - 1 && cell.Column <= colum + 1;
                if (isLineAdjacent && isColumnAdjacent)
                    ret.Add(cell);
            }
            return ret;
        }

        public void SetMine(int row, int column)
        {
            Cell cell = GetCell(row, column);
            cell.SetMine();

            foreach (var adjCell in getAdjacentCells(row, column))
            {
                int currentSurMineCnt = adjCell.SurroundingMineCnt;
                adjCell.SetSurroundingMineCnt(currentSurMineCnt + 1);
            }
        }
        public void MarkCell(int row, int column)
        {
            Cell cell = GetCell(row, column);
            cell.ChangeMark();
            onCellChanged(cell);
        }

        public void OpenCell(int row, int column)
        {
            Cell cell = GetCell(row, column);
            cell.Open();
            onCellChanged(cell);
            if(cell.HasMine)
                onMineOpened();
        }

        private void onCellChanged(Cell cell)
        {
            if (CellChanged != null)
                CellChanged(cell);
        }
        private void onMineOpened()
        {
            if (MineOpened != null)
                MineOpened();
        }
    }
}
 