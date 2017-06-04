namespace SimpleDiscordBot
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    internal class Program
    {
        internal static string _Token        = "";
        internal static string _Prefix       = "!";
        internal static Client _Client       = null;
        internal static Stopwatch _Stopwatch = new Stopwatch();

        /// <summary>
        /// Entry point of the Program.
        /// </summary>
        /// <param name="args"></param>
        internal static void Main(string[] args)
        {
            Console.Title = $"SimpleDiscordBot | 1.0.0 | ©{DateTime.UtcNow.Year}";

            IntPtr Handle = GetConsoleWindow();
            SetWindowLong(Handle, -20, (int)GetWindowLong(Handle, -20) ^ 0x80000);
            SetLayeredWindowAttributes(Handle, 0, 227, 0x2);

            Log.Info("Starting Bot...");
            _Stopwatch.Start();
            _Client = new Client(_Token);
            _Stopwatch.Stop();
            Log.Info($"Bot has been started in {_Stopwatch.ElapsedMilliseconds}ms.");

            Console.ReadKey(true);
        }

        [DllImport("user32.dll")]
        internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        internal static extern bool SetLayeredWindowAttributes(IntPtr hWnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetConsoleWindow();
    }
}
