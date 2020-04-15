using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : ISnake
    {
        public int Length { get; set; } = 5;
        public Direction Direction { get; set; } = Direction.Right;
        public Coordinate HeadPosition { get; set; } = new Coordinate();
        public List<Coordinate> Tail { get; private set; } = new List<Coordinate>();
        private bool outOfRange = false;

        public bool GameOver
        {
            get 
            {
                return (Tail.Where(c => c.X == HeadPosition.X
                && c.Y == HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
        }
        public void EatFruit()
        {
            Length++;
        }

        public void Move()
        {
            switch(Direction)
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
            try 
            { 
                Console.SetCursorPosition(HeadPosition.X, HeadPosition.Y);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("O");
                Tail.Add(new Coordinate(HeadPosition.X, HeadPosition.Y));
                if(Tail.Count > Length)
                {
                    var endTail = Tail.First();
                    Console.SetCursorPosition(endTail.X, endTail.Y);
                    Console.Write(" ");
                    Tail.Remove(endTail);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
    }
    enum Direction { Left, Right, Up, Down}
}