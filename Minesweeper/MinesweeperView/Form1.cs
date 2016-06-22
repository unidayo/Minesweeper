using Minesweeper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinesweeperView
{
    public partial class Form1 : Form
    {
        const int ROW_CNT = 16;
        const int COL_CNT = 30;
        const int MINE_CNT = 99;
        private Field _field;

        public Form1()
        {
            InitializeComponent();
            createFieldComponent();

            //// todo:const field -> randam map
            //var fieldMap = new List<string> { "......*...",
            //                                  "..*.....*.",
            //                                  ".....*....",
            //                                  ".....*..*.",
            //                                  ".*........"};
            //_field = new FieldFactory().ReadLineList(fieldMap);
            _field = new FieldFactory().RandomMine(ROW_CNT, COL_CNT, MINE_CNT);
            _field.CellChanged += Update;
            _field.MineOpened += GameOver;
        }

        private void createFieldComponent()
        {
            const int HEIGHT = 40;
            const int WIDTH = 40;

            const int LOC_X_DEFAULT = 10;
            const int LOC_Y_DEFAULT = 60;
            int locX = LOC_X_DEFAULT;
            int locY = LOC_Y_DEFAULT;
            int ind = 0;
            for (int i = 0; i < ROW_CNT * COL_CNT; i++)
            {
                // ボタン生成
                var bt = new Button();
                bt.Location = new Point(locX, locY);
                bt.Name = "Btn" + ind;
                bt.Size = new Size(HEIGHT, WIDTH);
                bt.TabIndex = ind;
                bt.Text = string.Empty;
                bt.UseVisualStyleBackColor = true;
                bt.Margin = new Padding(0);
                bt.FlatStyle = FlatStyle.Standard;
                bt.MouseDown += Cell_MouseDown;
                this.Controls.Add(bt);

                // 位置インクリメント
                ind++;
                if (ind % COL_CNT == 0)
                {
                    locX = LOC_X_DEFAULT;
                    locY += HEIGHT;
                }
                else
                {
                    locX += WIDTH;
                }
            }
        }

        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            int row = getRow(bt.Name);
            int col = getCol(bt.Name);

            if (e.Button == MouseButtons.Left)
                _field.OpenCell(row, col);
            else if (e.Button == MouseButtons.Right)
                _field.MarkCell(row, col);
        }
        private int getRow(string name)
        {
            int ind = int.Parse(name.Substring(3));
            decimal ret = ind / COL_CNT;
            return (int)Math.Truncate(ret);
        }
        private int getCol(string name)
        {
            int ind = int.Parse(name.Substring(3));
            return ind % COL_CNT;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //var fieldMap = new List<string> { "......*...",
            //                                  "..*.....*.",
            //                                  ".....*....",
            //                                  ".....*..*.",
            //                                  ".*........"};
            //_field = new FieldFactory().ReadLineList(fieldMap);
            _field = new FieldFactory().RandomMine(ROW_CNT, COL_CNT, MINE_CNT);
            _field.CellChanged += Update;
            _field.MineOpened += GameOver;

            for (int i = 0; i < ROW_CNT; i++)
            {
                for (int j = 0; j < COL_CNT; j++)
                {
                    Update(_field.GetCell(i, j));
                }
            }
            BtnReset.Text = "リセット";
        }
        public void Update(Cell cell)
        {
            Button btn = getCellControl(cell.Row, cell.Column);
            btn.FlatStyle = cell.IsOpen ? FlatStyle.Flat : FlatStyle.Standard;
            if (cell.IsOpen && cell.HasMine)
                btn.Text = "※";
            else if (cell.IsOpen)
                btn.Text = cell.SurroundingMineCnt == 0 ? string.Empty : cell.SurroundingMineCnt.ToString();
            else if (cell.Mark == CELL_MARK.FLAG)
                btn.Text = "✓";
            else if (cell.Mark == CELL_MARK.QUESTION)
                btn.Text = "？";
            else
                btn.Text = string.Empty;
        }
        public void GameOver()
        {
            BtnReset.Text = "ゲームオーバー！";
        }
        private Button getCellControl(int row, int column)
        {
            int nameInt = row * COL_CNT + column;
            string name = "Btn" + nameInt.ToString();
            foreach (Control cnt in Controls)
            {
                if (cnt.Name == name)
                    return cnt as Button;
            }
            return null;
        }
    }
}
