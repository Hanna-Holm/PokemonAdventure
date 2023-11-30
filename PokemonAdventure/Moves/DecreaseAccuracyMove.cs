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
        private int accuracyDif { get; init; }
        public override string Description => "Lowers target accuracy";

        public DecreaseAccuracyMove(string name, int accuracyDif)
        {
            this.Name = name;
            this.accuracyDif = accuracyDif;
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
            target.Accuracy -= this.accuracyDif;
            printer.Print($"{target.Name}s accuracy decreased with {this.accuracyDif} and is now {target.Accuracy}!");
            Thread.Sleep(pauseInMs);

        }
    }
}
