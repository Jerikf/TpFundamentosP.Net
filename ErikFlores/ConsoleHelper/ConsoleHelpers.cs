using System;

namespace ConsoleHelper
{
    public static class ConsoleHelpers
    {
		public static void WrileYellow(string text)
		{
			try
			{
				System.Console.ForegroundColor = ConsoleColor.Yellow;
				System.Console.BackgroundColor = ConsoleColor.Black;
				System.Console.WriteLine(text);
			}
			finally
			{
				System.Console.ResetColor();
			}
		}
	}
}
