using System;
using System.IO;
using System.Net;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            IWay2Word way2Word = new Way2Word();

            while (true)
            {
                Console.WriteLine("Please, type a word to search it position at way2word webservice: ");
                string word = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Please, wait!");
                int numberOfDeadKittens;
                int position = way2Word.Call(word.ToUpper(), out numberOfDeadKittens);

                Console.WriteLine();
                Console.Write("The position of the word ");
                Program.WriteLineWithColor(word, false);
                Console.WriteLine(" at way2word web service dictionary is: ");
                Program.WriteLineWithColor(position);
                Console.Write("Number of dead kittens are: ");
                Program.WriteLineWithColor(numberOfDeadKittens);

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

        private static void WriteLineWithColor(object value, bool breakLine = true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (breakLine)
            {
                Console.WriteLine(value);
            }
            else
            {
                Console.Write(value);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
