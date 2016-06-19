using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper;
using System.Collections.Generic;

namespace MinesweeperTest
{
    [TestClass]
    public class FieldFactoryTest
    {
        [TestMethod]
        public void ReadLineList()
        {
            var lineList = new List<string>() { "..*..",
                                                "...*.",
                                                "*....",
                                                "....." };
            Field ret = new FieldFactory().ReadLineList(lineList);
            Assert.AreEqual(4, ret.LineCount, "列数");
            Assert.AreEqual(5, ret.ColumnCount, "行数");
            Assert.AreEqual(0, ret.GetCell(0, 0).SurroundingMineCnt,"1-1");
            Assert.AreEqual(1, ret.GetCell(0, 1).SurroundingMineCnt, "1-2");
            Assert.IsTrue(ret.GetCell(0, 2).HasMine, "1-3");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadLineList_argsMustRectangleMap()
        {
            var lineList = new List<string>() { "....",
                                                "..",
                                                "...."};
            Field ret = new FieldFactory().ReadLineList(lineList);
        }
    }
}
