using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAttackMove : Move
    {
        public override string Name { get; init; }
        private int powerDif { get; init; }
        public override string Description { get; } = "Lowers target attack";

        public DecreaseAttackMove(string name, int amount)
        {
            Name = name;
            this.powerDif = amount;
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
            target.Power -= this.powerDif;
            printer.Print($"{target.Name}s attack decreased with {this.powerDif} and is now {target.Power}!");
            Thread.Sleep(pauseInMs);
        }
    }
}
