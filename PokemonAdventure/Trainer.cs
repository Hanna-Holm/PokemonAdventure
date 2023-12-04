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

        // 1. Concept: Object compostion
        // 2. How? A trainer has a Pokemon.
        // 3. Why? We can have many trainers that have one or many pokemons. 
        // There can even be different types of pokemons. This allows us to change the behaviour of objects at run-time.
        // An example of this is that pokemons has an attack. And these attacks
        // are set and can be changed at run-time.
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