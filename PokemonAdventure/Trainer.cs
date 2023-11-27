using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    class Trainer
    {
        ConsolePrinter printer = new ConsolePrinter();
        Validator validator = new Validator();
        public string Name { get; private set; }
        public List<Pokemon> CapturedPokemon { get; private set; }


        public Trainer(Pokemon pokemon)
        {
            this.CapturedPokemon = new List<Pokemon> { pokemon };
        }
        public void SetName()
        {
            do
            {
                printer.Print("Enter your name.");
                Name = Console.ReadLine();
            } while (!validator.ConfirmName(Name));
        }

    }
}
