using System;

namespace StringMaster
{
    public class Program
    {
        public static IConsole ConsoleWrapper = new ConsoleWrapper();

        public static void Main(string[] args)
        {
            string input = ConsoleWrapper.ReadLine();
            Console.Write("The result is {0}", new StringCalculator().Add(input));
        }
    }
}