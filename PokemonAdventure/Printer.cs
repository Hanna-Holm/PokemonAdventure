using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class Printer
    {
        private int pauseTimeInMs = 18;

        public void Print(string text)
        {
            Console.WriteLine();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(pauseTimeInMs);
            }
        }
    }
}
