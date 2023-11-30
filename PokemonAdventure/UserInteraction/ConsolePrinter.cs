
using System.Reflection;

namespace PokemonAdventure.UserInteraction
{
    internal class ConsolePrinter
    {
        private int pauseTimeInMs = 15;
        private int slowTimeInMs = 60;

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
        public void LoadingScene()
        {
            Console.WriteLine();
            string text = ". . . . . ";
            int count = 3;

            while (0 < count)
            {
                foreach (char t in text)
                {
                    Console.Write(t);
                    Thread.Sleep(slowTimeInMs);
                }
                Console.WriteLine();
                count--;
            }
        }
    }
}