using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Board
    {
        public Board()
        {
            DrawBoard();
        }
        void DrawBoard()
        {
            int szer = 110;
            int wys = 25;

            for(int i = 0; i <= szer; i++)
                Console.Write("#");
            Console.WriteLine();
            for(int  i =0; i < wys; i++)
            {
                Console.Write("#");
                for (int j = 0; j < szer - 1; j++)
                    Console.Write(" ");
                Console.WriteLine("#");
            }
            for (int i = 0; i <= szer; i++)
                Console.Write("#");

        }
    }
}
