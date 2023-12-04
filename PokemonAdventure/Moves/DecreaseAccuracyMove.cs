using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAccuracyMove : Move
    {
        public required override string Name { get; init; }
        public override string Description => "Lowers target accuracy";
        private readonly int accuracyDecrease;

        [SetsRequiredMembers]
        public DecreaseAccuracyMove(string name, int accuracyDecrease)
        {
            Name = name;
            this.accuracyDecrease = accuracyDecrease;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            PrintUsingMessage(attacker);

            if (target.Accuracy == 0)
            {
                PrintAndPause("But it failed.");
                return;
            }
            target.Accuracy -= this.accuracyDecrease;

            PrintAndPause($"{target.Name}s accuracy decreased with {this.accuracyDecrease} and is now {target.Accuracy}!");
        }
    }
}
