using PokemonAdventure.PokemonSpecifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAccuracyMove : Move
    {
        public override string Name { get; init; }
        public override string Description { get; } = "Lowers target accuracy";
        private readonly int accuracyDecrease;

        public DecreaseAccuracyMove(string name, int accuracyDecrease)
        {
            this.Name = name;
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
