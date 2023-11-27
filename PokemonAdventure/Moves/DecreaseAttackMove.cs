using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAttackMove : Move
    {
        public override string Name { get; init; }
        public override string Description { get; } = "Lowers target attack";
        private int Amount { get; init; }

        public DecreaseAttackMove(string name, int amount)
        {
            Name = name;
            Amount = amount;
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
            target.Power -= this.Amount;
            printer.Print($"{target.Name}s attack decreased with {this.Amount} and is now {target.Power}!");
            Thread.Sleep(pauseInMs);
        }
    }
}
