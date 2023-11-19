using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class Trainer
    {
        public string Name { get; private set; }
        public List<Pokemon> capturedPokemon { get; private set; }
        Printer printer = new Printer();
        Validator validator = new Validator();

        public Trainer()
        {
            capturedPokemon = new List<Pokemon>
            {
                new Pokemon("Pikachu")
            };
        }

        public void SetName()
        {
            do
            {
                printer.Print("What is your name? ");
                Name = Console.ReadLine();
            } while (!validator.isNameCorrect(Name));
        }

        
    }
}
