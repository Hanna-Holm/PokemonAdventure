using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAttackMove : Move
    {
        public required override string Name { get; init; }
        private int powerDifference { get; init; }
        public override string Description => "Lowers target attack";

        [SetsRequiredMembers]
        public DecreaseAttackMove(string name, int powerDifference)
        {
            Name = name;
            this.powerDifference = powerDifference;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            if (target.Power == 0)
            {
                printer.Print("But it failed.");
                Thread.Sleep(pauseInMs);
                return;
            }
            target.Power -= this.powerDifference;
            printer.Print($"{target.Name}s attack decreased with {this.powerDifference} and is now {target.Power}!");
            Thread.Sleep(pauseInMs);
        }
    }
}
