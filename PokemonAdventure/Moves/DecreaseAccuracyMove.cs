using PokemonAdventure.PokemonSpecifier;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAccuracyMove : Move
    {
        public required override string Name { get; init; }
        private int accuracyDifference { get; init; }
        public override string Description => "Lowers target accuracy";

        [SetsRequiredMembers]
        public DecreaseAccuracyMove(string name, int accuracyDifference)
        {
            this.Name = name;
            this.accuracyDifference = accuracyDifference;
        }
        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            base.GetUsedBy(attacker, target);
            if (target.Accuracy == 0)
            {
                printer.Print("But it failed.");
                Thread.Sleep(pauseInMs);
                return;
            }
            target.Accuracy -= this.accuracyDifference;
            printer.Print($"{target.Name}s accuracy decreased with {this.accuracyDifference} and is now {target.Accuracy}!");
            Thread.Sleep(pauseInMs);

        }
    }
}
