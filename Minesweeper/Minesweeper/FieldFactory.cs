using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class FieldFactory
    {
        const char MINE = '*';

        public Field ReadLineList(IList<string> lineList)
        {
            if (fieldIsRectangle(lineList) == false)
                throw new ArgumentException("引数マップが四角形でありません。");

            Field ret = createEmptyField(lineList);

            setMine(lineList, ret);
            return ret;
        }

        private bool fieldIsRectangle(IList<string> lineList)
        {
            int firstLineColumnCount = lineList[0].Length;
            foreach (var line in lineList)
            {
                if (line.Length != firstLineColumnCount)
                    return false;
            }
            return true;
        }

        private static Field createEmptyField(IList<string> lineList)
        {
            int rowCnt = lineList.Count;
            int colCnt = lineList[0].Length;
            return new Field(rowCnt, colCnt);
        }

        private static void setMine(IList<string> lineList, Field ret)
        {
            for (int row = 0; row < lineList.Count; row++)
            {
                for (int col = 0; col < lineList[row].Length; col++)
                {
                    if (isMine(lineList[row][col]))
                        ret.GetCell(row, col).SetMine();
                }
            }
        }

        private static bool isMine(char ch)
        {
            return ch == '*';
        }
    }
}
