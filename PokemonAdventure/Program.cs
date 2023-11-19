﻿namespace PokemonAdventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"

    ██████╗░░█████╗░██╗░░██╗███████╗██╗░░░██╗░█████╗░███╗░░██╗
    ██╔══██╗██╔══██╗██║░██╔╝██╔════╝███░░███║██╔══██╗████╗░██║
    ██████╔╝██║░░██║█████═╝░█████╗░░██╔██╝██║██║░░██║██╔██╗██║
    ██╔═══╝░██║░░██║██╔═██╗░██╔══╝░░██║░░░██║██║░░██║██║╚████║
    ██║░░░░░╚█████╔╝██║░╚██╗███████╗██║░░░██║╚█████╔╝██║░╚███║
    ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░░╚═╝░╚════╝░╚═╝░░╚══╝
            
          A text-based adventure based on a classic.

");

            Printer printer = new Printer();
            printer.Print("\t    Press Enter to start your Adventure.");

            string input = "";
            do
            {
                input = Console.ReadLine();
            } while (input != "");

            Story story = new Story();
            story.Begin();

            Console.ReadKey();
        }
    }
}