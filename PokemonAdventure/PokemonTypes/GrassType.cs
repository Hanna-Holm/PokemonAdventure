
using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class GrassType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Razor leaf", 22),
                new AttackMove("Petal dance", 18),
                new AttackMove("Vine whip", 20),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 3),
                new DecreaseDefenceMove("Leer", 3)
                
            };
        public GrassType()
        {
            TypeName = "Grass";
        }
    }
}
