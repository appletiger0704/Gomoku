using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Resolvers;

namespace Gomoku_test
{
    public partial class Form1 : Form
    {
        Game_Manager game = new Game_Manager();
        Board board = new Board();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Piece boardpiece = game.Piecebeplace(e.X, e.Y);
            if(boardpiece != null)
            {
                this.Controls.Add(boardpiece);
            }
            
            if(Game_Manager.Winner != Piecetype.NONE)
            {
                if (Game_Manager.Winner == Piecetype.BLACK)
                {
                    MessageBox.Show("贏家為黑色棋子");
                }
                else if(Game_Manager.Winner == Piecetype.WHITE)
                {
                    MessageBox.Show("贏家為白色棋子");
                }
                Application.Restart(); // 若有贏家產生，遊戲重啟       只有windows form裡面可以使用
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (game.Canbeplace(e.X,e.Y) == true)
            {
                this.Cursor = Cursors.Hand;
            }
            else if ((game.Canbeplace(e.X, e.Y) == false))
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
