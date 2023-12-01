using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    internal class DecreaseDefenceMove : Move
    {
        public required override string Name { get; init; }
        public int DefenceDifference { get; init; }
        public override string Description => "Lowers target defence";

        [SetsRequiredMembers]
        public DecreaseDefenceMove(string name, int DefenceDifference)
        {
            this.Name = name;
            this.DefenceDifference = DefenceDifference;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            if (target.Defence == 0)
            {
                printer.Print("But it failed.");
                Thread.Sleep(pauseInMs);
                return;
            }

            target.Defence -= this.DefenceDifference;
            printer.Print($"{target.Name} lost {this.DefenceDifference} defence and now has {target.Defence} defence left!");
            Thread.Sleep(pauseInMs);
        }
    }
}