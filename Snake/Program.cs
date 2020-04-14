using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var exit = false;
            double frameRate = 1000 / 5.0;
            DateTime lastDate = DateTime.Now;
            Fruit fruit = new Fruit();

            while (!exit)
            {
                ConsoleKeyInfo input = Console.ReadKey();

                switch(input.Key)
                {
                    case ConsoleKey.Escape:
                        exit = true;
                        break;
                    case ConsoleKey.LeftArrow:
                        //x--
                        break;
                    case ConsoleKey.RightArrow:
                        //x++
                        break;
                    case ConsoleKey.UpArrow:
                        //y++
                        break;
                    case ConsoleKey.DownArrow:
                        //y--
                        break;
                }    
            }
            if((DateTime.Now - lastDate).TotalMilliseconds >= frameRate)
            {
                //action
                lastDate = DateTime.Now;
            }
        }
    }
}
