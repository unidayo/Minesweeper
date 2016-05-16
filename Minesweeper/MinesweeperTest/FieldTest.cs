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
            Assert.AreEqual(1, cl.Row);
            Assert.AreEqual(1, cl.Column);
            Assert.IsFalse(cl.IsOpen);
            Assert.AreEqual(0, cl.SurroundingMineCnt);
            Assert.AreEqual(CELL_MARK.NONE, cl.Mark);

            cl = field.GetCell(2, 3);
            Assert.AreEqual(2, cl.Row);
            Assert.AreEqual(3, cl.Column);
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
