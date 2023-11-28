

using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class FlyingType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Gust", 16),
                new AttackMove("Wing attack", 18),
                new AttackMove("Peck", 20),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 3),
                new DecreaseDefenceMove("Leer", 3)
                
            };
        public FlyingType()
        {
            TypeName = "Flying";
        }
    }
}
