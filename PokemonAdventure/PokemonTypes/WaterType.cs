
using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class WaterType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Water gun", 18),
                new AttackMove("Surf", 22),
                new AttackMove("Bubble beam", 20),
                new AttackMove("Bubble", 18),
                new DecreaseAttackMove("Growl", 3),
                new DecreaseDefenceMove("Leer", 3)
            };
        public WaterType()
        {
            TypeName = "Water";
        }
    }
}
