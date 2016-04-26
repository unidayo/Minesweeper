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
    }
}
