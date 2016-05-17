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
