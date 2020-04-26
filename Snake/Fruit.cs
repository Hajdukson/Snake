using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace Snake
{
    class Fruit
    {
        public Coordinate FruitCoordinate { get; private set; }
        public Fruit()
        {
            var rnd = new Random();
            var x = rnd.Next(1,Board.Width);
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
