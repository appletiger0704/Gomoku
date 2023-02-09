using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku_test
{
    internal class Game_Manager
    {
        Board board = new Board();
        Piecetype currentplayer = Piecetype.BLACK;
        private static Piecetype winner = Piecetype.NONE;
        public static Piecetype Winner { get { return winner; } }
        private static readonly int Boardlimit = 9;
        private static bool maybehavewinner = false;
        public static bool Maybehavewinner { get { return maybehavewinner; } }

        public Piece Piecebeplace(int x, int y)
        {
            Piece boardpiece = board.Piecebeplace(x, y, currentplayer); // 設置棋子的點，到piece類別裡面設置，才不會跑掉
            Checkwinner(); //先確認是否有贏家產生

            if (boardpiece != null)
            {
                if (currentplayer == Piecetype.BLACK)
                    currentplayer = Piecetype.WHITE;
                else if (currentplayer == Piecetype.WHITE)
                    currentplayer = Piecetype.BLACK;
                return boardpiece;
            }
            return null;
        }

        public bool Canbeplace(int x, int y)
        {
            return board.Canbeplace(x, y);
        }

        private void Checkwinner()
        {
            Checkwinner_method(5);
            Checkwinner_method(4);
            Checkwinner_method(3);
        }

        
        private void Checkwinner_method(int x)
        {
            int centerX = board.Lastplacepiece.X;
            int centerY = board.Lastplacepiece.Y;
            for (int XDirect = -1; XDirect <= 1; XDirect ++)
            {
                for(int YDirect = -1; YDirect <= 1; YDirect ++)
                {
                    int count = 1;
                    while (count < x)
                    {
                        int targetX = centerX + (count * XDirect);
                        int targetY = centerY + (count * YDirect);
                        if (XDirect == 0 && YDirect == 0 ||
                            targetX < 0 || targetX >= 9 ||
                            targetY < 0 || targetY >= 9 ||
                            board.GetPiecetype(targetX, targetY) != currentplayer)
                        {
                            break;
                        }

                        int targetreverseX;
                        int targetreverseY;
                        if (x == 3)
                        {
                            targetreverseX = centerX - (count * XDirect);
                            targetreverseY = centerY - (count * YDirect);
                            if (targetreverseX < 0 || targetreverseX >= Boardlimit ||
                            targetreverseY < 0 || targetreverseY >= Boardlimit ||
                            board.GetPiecetype(targetreverseX, targetreverseY) != currentplayer)
                            {
                                break;
                            }
                        }
                        else if (x == 4)
                        {
                            targetreverseX = centerX -XDirect;
                            targetreverseY = centerY -YDirect;
                            if (targetreverseX < 0 || targetreverseX >= Boardlimit ||
                            targetreverseY < 0 || targetreverseY >= Boardlimit ||
                            board.GetPiecetype(targetreverseX, targetreverseY) != currentplayer)
                            {
                                break;
                            }
                        }
                        count ++;
                    }
                    if (count == x)
                    {
                        winner = currentplayer;
                    }
                }
            } 
        }
    }
}
