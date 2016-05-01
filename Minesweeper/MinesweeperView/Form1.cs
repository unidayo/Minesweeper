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
        private Field _field;
        const int ROW_CNT = 5;
        const int COL_CNT = 10;

        public Form1()
        {
            InitializeComponent();
            initializeField();
        }

        private void initializeField()
        {
            _field = new Field(ROW_CNT, COL_CNT);

            const int HEIGHT = 40;
            const int WIDTH = 40;

            const int LOC_X_DEFAULT = 10;
            int locX = LOC_X_DEFAULT;
            int locY = 10;
            int ind = 0;


            int cellCnt = ROW_CNT * COL_CNT;
            for (int i = 0; i < cellCnt; i++)
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
                bt.MouseDown += Cell_MouseDown;
                this.Controls.Add(bt);
                
                // 位置インクリメント
                ind++;
                if (ind % ROW_CNT == 0)
                {
                    locX = LOC_X_DEFAULT;
                    locY += WIDTH;
                }
                else
                {
                    locX += HEIGHT;
                }
            }
        }

        private void Cell_MouseDown(object sender, MouseEventArgs e)
        {
            Button bt = sender as Button;
            int row = getRow(bt.Name);
            int col = getColumn(bt.Name);
            _field.Open(row, col);
            MessageBox.Show(row+" + "+col);
        }

        private int getRow(string name)
        {
            int ind = int.Parse(name.Substring(3));
            decimal ret = ind / ROW_CNT;
            return (int)Math.Truncate(ret);
        }

        private int getColumn(string name)
        {
            int ind = int.Parse(name.Substring(3));
            return ind % ROW_CNT;
        }

        public void Update(Field field)
        {

        }
    }
}
