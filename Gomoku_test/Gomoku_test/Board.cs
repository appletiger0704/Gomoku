using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku_test
{
    internal class Board
    {
        // 判斷交叉點

        // 交叉點之間的距離為Distance，棋盤邊框區域長度為Offset，交叉點有一個正方形判斷區域半徑為Place_piece_radius

        // 當鼠標移進判斷區域R，鼠標要變成手的樣子，告訴玩家這裡可以放置棋子

        private static readonly Point NO_node = new Point(-1,-1);

        private static readonly int Boardlimit = 9;
        private static readonly int Distance = 75;
        private static readonly int Offset = 75;
        private static readonly int Place_piece_radius = 10;
        private Piece[,] piece = new Piece[Boardlimit, Boardlimit];
        private Point lastplacepiece = NO_node;
        public Point Lastplacepiece { get { return lastplacepiece; } }



        public bool Canbeplace(int x , int y)
        {
            // 找出最近的節點
            Point Close_node = Findtheclosetnode(x,y);

            // 如果沒有的話，回傳false
            if (Close_node == NO_node)
            {
                return false;
            }
            // 如果有的話，確認是否已放置棋子
            if (piece[Close_node.X, Close_node.Y] != null)
            {
                return false;
            }
            return true;
        }

        public Piece Piecebeplace(int x, int y, Piecetype type)
        {
            // 找出最近的節點
            Point Close_node = Findtheclosetnode(x, y);

            // 如果沒有的話，回傳false
            if (Close_node == NO_node)
            {
                return null;
            }
            // 如果有的話，確認是否已放置棋子
            if (piece[Close_node.X,Close_node.Y] != null)
            {
                return null;
            }

            // 根據type對應類型，產生相對應的棋子
            Point formpos = formposition(Close_node);
            if (type == Piecetype.BLACK)
            {
                piece[Close_node.X, Close_node.Y] = new Blackpiece(formpos.X, formpos.Y);
            }
            else if (type == Piecetype.WHITE)
            {
                piece[Close_node.X, Close_node.Y] = new Whitepiece(formpos.X, formpos.Y);
            }
            lastplacepiece = Close_node;
            return piece[Close_node.X, Close_node.Y];
        }

        public Piecetype GetPiecetype(int nodex, int nodey)
        {
            if (piece[nodex,nodey] == null)
            {
                return Piecetype.NONE;
            }
            else
            {
                return piece[nodex, nodey].Getpiecetype();
            }
        }


        private Point formposition(Point nodeID)
        {
            Point formpos = new Point();
            formpos.X = nodeID.X * Distance + Offset;
            formpos.Y = nodeID.Y * Distance + Offset;
            return formpos;
        }

        private Point Findtheclosetnode(int x, int y)
        {
            int nodeIDX = Findtheclosetnode(x);
            if (nodeIDX == -1 || nodeIDX >= Boardlimit)
            {
                return NO_node;
            }

            int nodeIDY = Findtheclosetnode(y);
            if (nodeIDY == -1 || nodeIDY >= Boardlimit)
            {
                return NO_node;
            }

            return new Point(nodeIDX, nodeIDY);
        }

        private int Findtheclosetnode(int pos) // 先從一維做起，再做二維判斷
        {
            int Distance_form_board = pos - Offset;
            int quotient = Distance_form_board / Distance;
            int remainder = Distance_form_board % Distance;

            if (pos <= Offset - Place_piece_radius)
            {
                return -1;
            }

            if (remainder <= Place_piece_radius)
            {
                return quotient;
            }
            else if (remainder >= (Distance - Place_piece_radius))
            {
                return quotient +1;
            }
            else
            {
                return -1; // 代表沒有符合點
            }
        }

        
    }
}
