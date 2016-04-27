using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass]
    public class FieldTest
    {
        [TestMethod]
        public void Ctor()
        {
            var field = new Field(3, 4);
            Assert.AreEqual(3, field.LineCount);
            Assert.AreEqual(4, field.ColumnCount);
        }

        [TestMethod]
        public void GetCell()
        {
            var field = new Field(3, 4);
            Cell cl = field.GetCell(1, 1);
            Assert.IsFalse(cl.IsOpen);
            Assert.AreEqual(0, cl.SurroundingMineCnt);
            Assert.AreEqual(CELL_MARK.NONE, cl.Mark);
        }

        [TestMethod]
        public void Open()
        {
            var field = new Field(2, 3);
            field.Open(1, 1);

            // TODO:オープンのテスト
        }
    }
}
