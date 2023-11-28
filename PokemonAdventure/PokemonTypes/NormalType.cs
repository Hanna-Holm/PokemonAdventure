using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class NormalType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Scratch", 16),
                new AttackMove("Bite", 22),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseAttackMove("Growl", 3),
                new DecreaseDefenceMove("Leer", 3)
                
            };
        public NormalType()
        {
            TypeName = "Normal";
        }
    }
}
