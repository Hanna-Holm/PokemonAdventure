using PokemonAdventure.UserInteraction;

namespace PokemonAdventure.Moves;

internal abstract class Move
{
    public abstract string Name { get; init; }

    // Using protected keyword so that derived classes can use this printer object to print to console RPG-style.
    protected ConsolePrinter printer = new ConsolePrinter();

    public virtual void GetUsedBy(Pokemon attacker, Pokemon target)
    {
        printer.Print($"{attacker.Name} used {Name}!");
    }
}
