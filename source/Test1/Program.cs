using System;
using System.IO;
using System.Net;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Please, type a word to search it position at way2word webservice: ");
                string input = Console.ReadLine();




                Console.WriteLine();
                Console.Write("Press 'ESC' to exit OR press any key to search again.");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
