using PokemonAdventure.UserInteraction;

namespace PokemonAdventure.Moves;

// 1. Concept: Abstract class
// 2. How? The class Move is an abstract class as we used the keyword 'abstract' for it.
// 3. Why? Move is an abstract concept, as there are no such thing as using a move
//    because a Pokemon must use a specific type of move.
//    Therefore, the intention is that the derived classes of move is-a type of move
//    and the implementations are done in the derived classes.
//    Because there are different types of moves, each derived move from this abstract class
//    has their own specific implementation, but each derived class uses the base-implementation
//    of the GetUsedBy() method, and adds their own logic on top of it.
//    This enables an abstract concept that gets implemented in concrete derived classes,
//    while also enabling code-reuse from the base-class.
internal abstract class Move
{
    public abstract string Name { get; init; }
    protected virtual int pauseInMs { get; set; } = 1000;

    // 1. Concept: Access modifier "Protected"
    // 2. How? using the access modifier keyword 'protected' on a field in the Move class
    //    (which is an object of type ConsolePrinter).
    // 3. Why? So that derived classes can use this printer object to call the Print() method
    //    on it to print to console RPG-style, without having to declare it themselves.
    //    The ConsolePrinter object gets inherited to and will be accessible to all derived types 
    //    as well as within this class, but not from any other types.
    //    This enables code reuse, we don't need to initialize a new ConsolePrinter object 
    //    in the derived classes, which saves us from unneccesary code duplication.
    protected ConsolePrinter printer = new ConsolePrinter();

    public virtual void GetUsedBy(Pokemon attacker, Pokemon target)
    {
        printer.Print($"{attacker.Name} used {Name}!");
        Thread.Sleep(pauseInMs);
    }
}
