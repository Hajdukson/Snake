﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Fruit
    {
        public Coordinate FruitCoordinate { get; set; }
        public Fruit()
        {
            Random rnd = new Random();
            var x = rnd.Next(1,20);
            var y = rnd.Next(1, 20);
            FruitCoordinate = new Coordinate(x, y);
            Draw();
        }
        void Draw()
        {
            Console.SetCursorPosition(FruitCoordinate.X, FruitCoordinate.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("$");
        }
        
    }
}
