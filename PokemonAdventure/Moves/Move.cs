using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    /*
       1. Concept: Abstract class
       2. How? The class Move is an abstract class as we used the keyword 'abstract' for it.
       3. Why? Move is an abstract concept, as there are no such thing as using a move
       because a Pokemon must use a specific type of move.
       Therefore, the intention is that the derived classes of move is-a type of move.
       Because there are different types of moves, each derived move from this abstract class
       can have their own specific implementation, but each derived class uses the base-implementation
       of the methods PrintAndPause and PrintUsingMessage, and each derived class
       implements their own logic to the GetUsedBy method.
       This enables an abstract concept that gets implemented in concrete derived classes,
       while also enabling code-reuse from the base-class.
       It also enables subtypepolymorphism, that we can use a subtype of Move whenever Move is expected.
    */
    internal abstract class Move
    {
        public required abstract string Name { get; init; }
        public abstract string Description { get; }
        private int pauseInMs { get; set; } = 1000;

        private ConsolePrinter printer = new ConsolePrinter();

        /*
          1. Concept: Access modifier "Protected"
          2. How? using the access modifier keyword 'protected' on a member of a class.
          3. Why? This ensures that the member will be accessible within this class and within
             all derived classes, but not from any other class.
             The benfits of using the protected access modifer is that it is more resticted than public
             but enables derived types to have access to the protected member, which is not possible if
             the member would had been private. 
             The subclasses can then use the PrintAndPause and the PrintUsingMessage methods, but these 
             methods are not available elsewhere than in Move and all derived classes of Move.
        */

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