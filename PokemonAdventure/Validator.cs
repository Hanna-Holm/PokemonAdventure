using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class Validator
    {
        Printer printer = new Printer();
        public bool isNameCorrect(string name)
        {
            printer.Print($"Is your name {name}? Y/N");
            ConsoleKeyInfo input = Console.ReadKey();
            if (input.KeyChar == 'Y' || input.KeyChar == 'y')
            {
                printer.Print($"So your name is {name}!");
                return true;
            }

            printer.Print($"Let's enter your name again.");
            return false;
        }
    }
}
