using PokemonAdventure.PokemonSpecifier;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.Moves
{
    internal class DecreaseDefenceMove : Move
    {
        public required override string Name { get; init; }
        public override string Description => "Lowers target defence";
        private readonly int defenceDecrease;

        [SetsRequiredMembers]
        public DecreaseDefenceMove(string name, int defenceDecrease)
        {
            Name = name;
            this.defenceDecrease = defenceDecrease;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            PrintUsingMessage(attacker);

            if (target.Defence == 0)
            {
                PrintAndPause("But it failed.");
                return;
            }

            target.Defence -= this.defenceDecrease;
            PrintAndPause($"{target.Name} lost {this.defenceDecrease} defence and now has {target.Defence} defence left!");
        }
    }
}