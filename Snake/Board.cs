using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class Board
    {
        public static int Width { get; private set; } = 100;
        public static int Height { get; private set; } = Console.BufferHeight - 2;

        public static void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
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

            Console.ForegroundColor = ConsoleColor.Magenta;
            Control();
        }
        private static void Control()
        {
            Console.SetCursorPosition(Console.BufferWidth - 17, 10);
            Console.Write("USE ARROWS TO");
            Console.SetCursorPosition(Console.BufferWidth - 17, 11);
            Console.WriteLine("CHANGE DIRECTION");
            Console.SetCursorPosition(Console.BufferWidth - 17, 12);
            Console.WriteLine("OF THE SNAKE HEAD");
            for (int i = 0; i < Graffiti.Control.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(Console.BufferWidth - 14, 15 + i);
                Console.WriteLine(Graffiti.Control[i]);
            }
        }
    }
}
