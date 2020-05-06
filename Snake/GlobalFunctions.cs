using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    static class GlobalFunctions
    {
        public static void DrawGraffiti(string[] graffiti, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            foreach (var line in graffiti)
            {
                Console.SetCursorPosition((Console.WindowWidth - line.Length) / 2, Console.CursorTop);
                Console.WriteLine(line.ToUpper());
            }
        }
        public static void PressButton(int coursorPosition = 2)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string notification = "Press any button to continue";
            Console.SetCursorPosition((Console.WindowWidth - notification.Length) / 2, Console.CursorTop + coursorPosition);
            Console.WriteLine(notification.ToUpper());
            Console.ReadKey();
        }
    }
}
