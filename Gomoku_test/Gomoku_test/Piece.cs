using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gomoku_test
{
    abstract class Piece : PictureBox    
    { 
        public static int image_width = 50;

        // constructer 設定物件的位置
        public Piece(int x , int y)
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(50, 50);
            this.Location = new Point(x - image_width/2 , y - image_width/2); // 棋子設置的點，會向上以及向右1/2個圖形寬度
        }

        public abstract Piecetype Getpiecetype();
    }
}
