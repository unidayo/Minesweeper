using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public enum CELL_MARK
    {
        NONE,
        FLAG,
        QUESTION
    }

    public class Cell
    {
        private readonly int _row;
        private readonly int _column;
        private bool _hasMine;
        private bool _isOpen = false;
        private CELL_MARK _mark = CELL_MARK.NONE;
        private int _surroungingMineCnt;

        public Cell(int row, int column)
        {
            this._row = row;
            this._column = column;
            this._hasMine = false;
        }

        public int Row { get { return _row; } }
        public int Column { get { return _column; } }

        public bool HasMine { get { return _hasMine; } }
        public int SurroundingMineCnt { get { return _surroungingMineCnt; } }

        public bool IsOpen { get { return _isOpen; } }
        public CELL_MARK Mark { get { return _mark; } }

        public void Open()
        {
            _isOpen = true;
        }

        public void ChangeMark()
        {
            if (_mark == CELL_MARK.NONE)          _mark = CELL_MARK.FLAG;
            else if (_mark == CELL_MARK.FLAG)     _mark = CELL_MARK.QUESTION;
            else if (_mark == CELL_MARK.QUESTION) _mark = CELL_MARK.NONE;
        }
        public void SetMine()
        {
            this._hasMine = true;
        }
        public void SetSurroundingMineCnt(int mineCnt)
        {
            _surroungingMineCnt = mineCnt;
        }
    }
}
