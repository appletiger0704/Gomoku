using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku_test
{
    internal class Blackpiece : Piece
    {
        public Blackpiece(int x , int y) : base(x , y)
        {
            this.Image = Properties.Resources.black;
        }
        public override Piecetype Getpiecetype()
        {
            return Piecetype.BLACK;
        }
    }
}
