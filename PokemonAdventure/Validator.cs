using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    class Validator
    {
        ConsolePrinter printer = new ConsolePrinter();
        public bool ConfirmName(string name)
        {
            printer.Print($"Press Enter to confirm your name {name}. Press Esc to change name.");
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.Enter)
            {
                return true;
            }

            printer.Print($"Let's enter your name again.");
            return false;
        }

        public bool CheckIfValidNumber(string input, int numberOfChoices)
        {
            bool isNumber = int.TryParse(input, out int number);

            if (number > 0 && number < numberOfChoices + 1)
            {
                return true;
            }
            Console.WriteLine("Please enter a valid number.");
            return false;
        }
    }
}
