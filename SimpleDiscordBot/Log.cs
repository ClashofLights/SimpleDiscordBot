namespace SimpleDiscordBot
{
    using System;

    internal class Log
    {
        internal static void Info(string _Text)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("[INFO]    ");
            Console.ResetColor();
            Console.WriteLine(_Text);
        }

        internal static void Error(string _Text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[ERROR]    ");
            Console.ResetColor();
            Console.WriteLine(_Text);
        }

        internal static void Execute(string _Text)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write("[ CMD ]    ");
            Console.ResetColor();
            Console.WriteLine(_Text);
        }

        internal static void Stats(string _Text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[STATS]    ");
            Console.ResetColor();
            Console.WriteLine(_Text);
        }

        internal static void Debug(string _Text)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[DEBUG]    ");
            Console.ResetColor();
            Console.WriteLine(_Text);
        }
    }
}
