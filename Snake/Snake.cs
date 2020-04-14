using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : ISnake
    {
        public int Length { get; set; }
        public Direction Direction { get; set; } = Direction.Right;
        public Coordinate HeadPosition { get; set; } = new Coordinate();
        List<Coordinate> Tail { get; set; } = new List<Coordinate>();
        private bool outOfRange = false;

        public bool GameOver
        {
            get 
            {
                return (Tail.Where(c => c.X == HeadPosition.X
                && c.Y == HeadPosition.Y).ToList().Count > 1) || outOfRange;
            }
            
        }
        public void EatMeal()
        {
            Length++;
        }

        public void Move()
        {
            
        }
    }
    enum Direction { Left, Right, Up, Down}
}
