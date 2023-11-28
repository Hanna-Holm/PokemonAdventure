using PokemonAdventure.UserInteraction;
using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    internal class DecreaseDefenceMove : Move
    {
        public override string Name { get; init; }
        public int DefenceDif { get; init; }
        public override string Description { get; } = "Lowers target defence";

        public DecreaseDefenceMove(string name, int amount)
        {
            Name = name;
            DefenceDif = amount;
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

            target.Defence -= this.DefenceDif;
            printer.Print($"{target.Name} lost {this.DefenceDif} defence and now has {target.Defence} defence left!");
            Thread.Sleep(pauseInMs);
        }
    }
}