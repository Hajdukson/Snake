using System;
namespace Snake.GameLogic
{
    class Board
    {
        public int Width { get; private set; } = 50;
        public int Height { get; private set; } = 38;
        public Board()
        {
            Console.SetWindowSize(70, 40);
            Console.SetBufferSize(70, 40);
        }
        public void DrawBoard(ConsoleColor color)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            for (int i = 0; i <= Width; i++)
                Console.Write("█");
            Console.Write("\n");
            for (int i = 0; i < Height; i++)
            {
                Console.Write("█");
                for (int j = 0; j < Width - 1; j++)
                    Console.Write(" ");
                Console.Write("█\n");
            }
            for (int i = 0; i <= Width; i++)
                Console.Write("█");

            Control();
        }
        private void Control()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.BufferWidth - 17, 16);
            Console.Write(" USE ARROWS TO");
            Console.SetCursorPosition(Console.BufferWidth - 19, 17);
            Console.WriteLine(" CONTROL THE SNAKE");

            int i = 0;
            for (; i < Graffiti.Control.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.BufferWidth - 14, 21 + i);
                Console.WriteLine(Graffiti.Control[i]);
            }
            i += 3;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.BufferWidth - 13, 21 + i);
            Console.Write(" FRUIT");
            i++;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.BufferWidth - 11, 21 + i);
            Console.WriteLine(" ░");

        }
    }
}
