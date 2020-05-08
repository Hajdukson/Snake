using System;
using System.Collections.Generic;
using System.Linq;
namespace Snake.GameLogic
{
    class Snake : ISnake
    {
        public int Length { get; private set; } = 5;
        public Direction Direction { get; set; } = Direction.Right;
        public Coordinate HeadPosition { get; private set; } = new Coordinate(1, 1);
        public List<Coordinate> Tail { get; private set; } = new List<Coordinate>();

        public void EatFruit()
        {
            Length++;
        }
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.X--;
                    break;
                case Direction.Right:
                    HeadPosition.X++;
                    break;
                case Direction.Up:
                    HeadPosition.Y--;
                    break;
                case Direction.Down:
                    HeadPosition.Y++;
                    break;
            }
        }
        public void TailLogic()
        {
            //without following two lines when the snake move in horizontal aligment 
            //behind him will be drawing verticals strokes
            Console.SetCursorPosition(Console.BufferWidth - 1, 9);
            Console.Write(" ");
            Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("█");
            Tail.Add(new Coordinate(HeadPosition.X, HeadPosition.Y));
            if (Tail.Count > Length)
            {
                var endTail = Tail.First();
                Console.SetCursorPosition(endTail.X, endTail.Y);
                Console.Write(" ");
                Tail.Remove(endTail);
            }
        }
    }
    enum Direction { Left, Right, Up, Down }
}