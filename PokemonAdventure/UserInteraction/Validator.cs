
namespace PokemonAdventure.UserInteraction
{
    internal class Validator
    {
        ConsolePrinter printer = new ConsolePrinter();
        public bool ConfirmName(string name)
        {
            if (name == "")
            {
                printer.Print("Well now... You must have a name?");
                return false;
            }

            printer.Print($"Is your name {name}?\n");
            Console.WriteLine("1. Yes, continue.");
            Console.WriteLine("2. No, change name.");
            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.NumPad1)
            {
                return true;
            }

            printer.Print($"Let's enter your name again.");
            return false;
        }
        public bool CheckIfValidNumber(ConsoleKeyInfo input, int numberOfChoices)
        {
            if (char.IsDigit(input.KeyChar))
            {
                int.TryParse(input.KeyChar.ToString(), out int number);

                if (number > 0 && number < numberOfChoices + 1)
                {
                    return true;
                }
            }

            Console.Clear();
            Console.WriteLine("Please enter a valid number.");
            return false;
        }
    }
}