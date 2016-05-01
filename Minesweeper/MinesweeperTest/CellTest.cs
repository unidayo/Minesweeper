using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void Ctor()
        {
            var cell = new Cell(0, 0);
            Assert.IsFalse(cell.IsOpen);
            Assert.AreEqual(0, cell.SurroundingMineCnt);
            Assert.IsFalse(cell.HasMine);
        }

        [TestMethod]
        public void Open()
        {
            var cell = new Cell(0, 0);
            Assert.IsFalse(cell.IsOpen);
            cell.Open();
            Assert.IsTrue(cell.IsOpen);
        }

        [TestMethod]
        public void ChangeMark()
        {
            var cell = new Cell(0, 0);
            Assert.AreEqual(CELL_MARK.NONE, cell.Mark,"前");
            cell.ChangeMark();
            Assert.AreEqual(CELL_MARK.FLAG, cell.Mark,"1回変更");
            cell.ChangeMark();
            Assert.AreEqual(CELL_MARK.QUESTION, cell.Mark, "2回変更");
            cell.ChangeMark();
            Assert.AreEqual(CELL_MARK.NONE , cell.Mark, "3回変更");
        }

        [TestMethod]
        public void SetSurrongingMineCnt()
        {
            var cell = new Cell(0, 0);
            Assert.AreEqual(0, cell.SurroundingMineCnt);
            cell.SetSurroundingMineCnt(2);
            Assert.AreEqual(2, cell.SurroundingMineCnt);
        }

        [TestMethod]
        public void SetMine()
        {
            var cell = new Cell(0, 0);
            cell.SetMine();
            Assert.IsTrue(cell.HasMine);
        }
    }
}
