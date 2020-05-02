using System;

namespace Snake.GameLogic
{
    class Fruit
    {
        public Coordinate FruitCoordinate { get; private set; }
        public Fruit()
        {
            var rnd = new Random();
            var x = rnd.Next(1, Board.Width);
            var y = rnd.Next(2, Board.Height);
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
