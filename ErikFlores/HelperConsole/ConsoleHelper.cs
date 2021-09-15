using System;
using System.Collections.Generic;
using System.Text;

namespace HelperConsole
{
   public static class ConsoleHelper
    {
		public static void WrileRedLine(string text)
		{
			try
			{
				System.Console.ForegroundColor = ConsoleColor.Red;
				System.Console.BackgroundColor = ConsoleColor.Black;
				System.Console.WriteLine(text);
			}
			finally
			{
				System.Console.ResetColor();
			}
		}

		public static void WrileYellowLine(string text)
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

		public static void WrileYellow(string text)
		{
			try
			{
				System.Console.ForegroundColor = ConsoleColor.Yellow;
				System.Console.BackgroundColor = ConsoleColor.Black;
				System.Console.Write(text);
			}
			finally
			{
				System.Console.ResetColor();
			}
		}
	}
}
