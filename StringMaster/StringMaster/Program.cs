using System;

namespace StringMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Write("Result is {0}", new StringCalculator().Add(args[0]));
        }
    }
}