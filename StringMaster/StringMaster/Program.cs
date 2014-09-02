using System;

namespace StringMaster
{
    public class Program
    {
        public static IConsole ConsoleWrapper = new ConsoleWrapper();

        public static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                Console.Write("The result is {0}\n", new StringCalculator().Add(args[0]));
                return;
            }
            
            string input = ConsoleWrapper.ReadLine();
            while (input != string.Empty)
            {
                Console.Write("The result is {0}\n", new StringCalculator().Add(input));
                Console.Write("another input please\n");

                input = ConsoleWrapper.ReadLine();
            }
            
        }
    }
}