using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure
{
    internal class Trainer
    {
        public string Name { get; private set; }
        public List<Pokemon> capturedPokemon { get; private set; } = new List<Pokemon>();
        ConsolePrinter printer = new ConsolePrinter();
        Validator validator = new Validator();
        public List<Pokemon> CapturedPokemon { get; private set; }

        public Trainer(Pokemon pokemon) => this.capturedPokemon.Add(pokemon);

        public void SetName()
        {
            do
            {
                printer.Print("Enter your name: ");
                Name = Console.ReadLine();
            } while (!validator.ConfirmName(Name));
        }

    }
}