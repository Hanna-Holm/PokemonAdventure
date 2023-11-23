using PokemonAdventure.UserInteraction;

namespace PokemonAdventure;

internal class Trainer
{
    public string Name { get; private set; }
    public List<Pokemon> capturedPokemon { get; private set; }
    ConsolePrinter printer = new ConsolePrinter();
    Validator validator = new Validator();

    public Trainer(Pokemon pokemon)
    {
        this.capturedPokemon = new List<Pokemon>
        {
            pokemon
        };
    }

    public void SetName()
    {
        do
        {
            printer.Print("What is your name? ");
            Name = Console.ReadLine();
        } while (!validator.ConfirmName(Name));
    }
}
