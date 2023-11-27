using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    class ConsolePrinter : IPrinter
    {
        private int pauseTimeInMs = 18;

        public void Print(string text)
        {
            Console.WriteLine();

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(pauseTimeInMs);

                if (Console.KeyAvailable)
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Console.Write(text);
                        return;
                    }
                }
            }
        }
    }
}
