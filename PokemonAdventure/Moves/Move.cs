using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
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
        public abstract string Description { get; }
        private int pauseInMs { get; set; } = 1000;

        private ConsolePrinter printer = new ConsolePrinter();

        // 1. Concept: Access modifier "Protected"
        // 2. How? using the access modifier keyword 'protected'
        // 3. Why? 
        protected void PrintAndPause(string message)
        {
            printer.Print(message);
            Thread.Sleep(pauseInMs);
        }

        public abstract void GetUsedBy(Pokemon attacker, Pokemon target);

        protected void PrintUsingMessage(Pokemon attacker)
        {
            PrintAndPause($"{attacker.Name} used {this.Name}!");
        }
    }
}