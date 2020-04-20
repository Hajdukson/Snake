using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Board
    {
        public static int Width { get; private set; } = 100;
        public static int Height { get; private set; } = Console.BufferHeight - 2;
        public Board()
        {
            DrawBoard();
        }
        private void DrawBoard()
        {
            for (int i = 0; i <= Width; i++)
                Console.Write("#");
            Console.Write("\n");
            for (int i = 0; i < Height; i++)
            {
                Console.Write("#");
                for (int j = 0; j < Width - 1; j++)
                    Console.Write(" ");
                Console.Write("#\n");
            }
            for (int i = 0; i <= Width; i++)
                Console.Write("#");

        }
    }
}
