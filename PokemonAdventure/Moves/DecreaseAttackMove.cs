using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure.Moves
{
    internal class DecreaseAttackMove : Move
    {
        public override string Name { get; init; }
        private int powerDif { get; init; }
        public override string Description { get; } = "Lowers target attack";
        private readonly int powerDecrease;

        public DecreaseAttackMove(string name, int powerDecrease)
        {
            Name = name;
            this.powerDecrease = powerDecrease;
        }

        public override void GetUsedBy(Pokemon attacker, Pokemon target)
        {
            PrintUsingMessage(attacker);

            if (target.Power == 0)
            {
                PrintAndPause("But it failed.");
                return;
            }
            target.Power -= this.powerDecrease;

            PrintAndPause($"{target.Name}s attack decreased with {this.powerDecrease} and is now {target.Power}!");
        }
    }
}
