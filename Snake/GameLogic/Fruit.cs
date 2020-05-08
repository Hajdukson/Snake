using System;
using System.Collections.Generic;

namespace Snake.GameLogic
{
    public class Fruit
    {
        Board board = new Board();
        public Coordinate FruitCoordinate { get; private set; }
        public Fruit()
        {
            var rnd = new Random();
            var x = rnd.Next(1, board.Width);
            var y = rnd.Next(2, board.Height);
            FruitCoordinate = new Coordinate(x, y);
            Draw();
        }
        void Draw()
        {
            Console.SetCursorPosition(FruitCoordinate.X, FruitCoordinate.Y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("░");
        }

    }
}
