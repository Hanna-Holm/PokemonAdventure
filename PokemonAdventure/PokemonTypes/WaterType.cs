
using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class WaterType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Bubble beam", 100),
                new AttackMove("Water gun", 90),
                new DecreaseAttackMove("Growl", 10),
                new AttackMove("Surf", 110),
                new DecreaseDefenceMove("Leer", 10),
                new AttackMove("Bubble", 90),
            };
        public WaterType()
        {
            TypeName = "Water";
        }
    }
}
