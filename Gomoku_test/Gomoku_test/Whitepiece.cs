using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku_test
{
    internal class Whitepiece : Piece
    {
        public Whitepiece(int x, int y) : base(x,y)
        {
            this.Image = Properties.Resources.white;
        }

        public override Piecetype Getpiecetype()
        {
            return Piecetype.WHITE;
        }
    }
}
