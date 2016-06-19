using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;

namespace MinesweeperTest
{
    [TestClass]
    public class FieldTest
    {
        private Field field;
        [TestInitialize]
        public void TestInitialize()
        {
            field = new Field(2, 3);
        }

        [TestMethod]
        public void Ctor()
        {
            Assert.AreEqual(2, field.LineCount);
            Assert.AreEqual(3, field.ColumnCount);
        }

        [TestMethod]
        public void GetCell()
        {
            Cell cl = field.GetCell(1, 1);
            Assert.AreEqual(1, cl.Row);
            Assert.AreEqual(1, cl.Column);
            Assert.IsFalse(cl.IsOpen);
            Assert.AreEqual(0, cl.SurroundingMineCnt);
            Assert.AreEqual(CELL_MARK.NONE, cl.Mark);
        }

        [TestMethod]
        public void OpenCell()
        {
            field.OpenCell(1, 1);
            Assert.IsTrue(field.GetCell(1, 1).IsOpen);
        }

        [TestMethod]
        public void MarkCell()
        {
            field.MarkCell(1, 2);
            Assert.AreEqual(CELL_MARK.FLAG, field.GetCell(1, 2).Mark);
            field.MarkCell(1, 2);
            Assert.AreEqual(CELL_MARK.QUESTION, field.GetCell(1, 2).Mark);
            field.MarkCell(1, 2);
            Assert.AreEqual(CELL_MARK.NONE, field.GetCell(1, 2).Mark);
        }

        [TestMethod]
        public void SetMine()
        {
            field.SetMine(1, 2);
            Assert.IsTrue(field.GetCell(1, 2).HasMine);
            Assert.AreEqual(1, field.GetCell(1, 1).SurroundingMineCnt);

            Assert.AreEqual(0, field.GetCell(0, 0).SurroundingMineCnt);
        }
    }
}
