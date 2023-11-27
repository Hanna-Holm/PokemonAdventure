
namespace PokemonAdventure.UserInteraction
{
    internal class ConsolePrinter
    {
        private int pauseTimeInMs = 14;

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