using System;

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
        public static void PressButton(int coursorPosition)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string notification = "Press any button to continue";
            Console.SetCursorPosition((Console.WindowWidth - notification.Length) / 2, coursorPosition);
            Console.WriteLine(notification.ToUpper());
            Console.ReadKey();
        }
    }
}
