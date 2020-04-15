using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var exit = false;
            var fruit = new Fruit();
            var snake = new Snake();
            var frame = 20;

            while (!exit)
            {
                if(Console.KeyAvailable)
                { 
                    ConsoleKeyInfo input = Console.ReadKey();

                    switch(input.Key)
                    {
                        case ConsoleKey.Escape:
                            exit = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            snake.Direction = Direction.Left;
                            break;
                        case ConsoleKey.RightArrow:
                            snake.Direction = Direction.Right;
                            break;
                        case ConsoleKey.UpArrow:
                            snake.Direction = Direction.Up;
                            break;
                        case ConsoleKey.DownArrow:
                            snake.Direction = Direction.Down;
                            break;
                    }
                }
                snake.Move();

                if (fruit.FruitCoordinate.X == snake.HeadPosition.X && fruit.FruitCoordinate.Y == snake.HeadPosition.Y)
                {
                    snake.EatFruit();

                    fruit = new Fruit();
                    

                    frame += 1;
                }
                
                if (snake.GameOver == true)
                {
                    Console.Clear();
                    Console.WriteLine($"GAME OVER. YOUR SCORE: {snake.Length}");
                    exit = true;
                    Console.ReadLine();
                }
                Thread.Sleep(10000 / frame);
            }
        }
    }
}
