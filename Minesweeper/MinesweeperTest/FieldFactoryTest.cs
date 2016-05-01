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
        public void CreateFromLiteral()
        {
            // 暫定的にリテラルでフィールド作成するファクトリ、
            var factory = new FieldFactory();
            Field field = factory.Create();
            Assert.AreEqual(15, field.LineCount);
            Assert.AreEqual(10, field.ColumnCount);
            // TODO: getCellでテスト
        }
    }
}
