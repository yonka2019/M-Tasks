using System;

namespace Game2048.Models
{
    internal static class ConsoleColored
    {
        internal static void Write(string data, ConsoleColor cc = ConsoleColor.Gray)
        {
            Console.ForegroundColor = cc;
            Console.Write(data);

            Console.ResetColor();
        }
        internal static void WriteLine(string data, ConsoleColor cc = ConsoleColor.Gray)
        {
            Write(data, cc);
            Write("\n");
        }
    }
}
