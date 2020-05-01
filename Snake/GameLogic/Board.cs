﻿using System;
namespace Snake
{
    static class Board
    {
        public static int Width { get; private set; } = 100;
        public static int Height { get; private set; } = Console.BufferHeight - 2;

        public static void DrawBoard(ConsoleColor color)
        {
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
        private static void Control()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Console.BufferWidth - 17, 10);
            Console.Write("  USE ARROWS TO");
            Console.SetCursorPosition(Console.BufferWidth - 19, 11);
            Console.WriteLine("  CONTROL THE SNAKE");
            int i = 0;
            for (; i < Graffiti.Control.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(Console.BufferWidth - 13, 15 + i);
                Console.WriteLine(Graffiti.Control[i]);
            }
            i += 3;
            Console.SetCursorPosition(Console.BufferWidth - 13, 15 + i);
            Console.Write("  FRUIT");
            i++;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(Console.BufferWidth - 11, 15 + i);
            Console.WriteLine("  ░");

        }
    }
}