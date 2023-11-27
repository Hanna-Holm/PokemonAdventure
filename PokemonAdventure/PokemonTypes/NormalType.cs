using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class NormalType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Scratch", 80),
                new AttackMove("Bite", 110),
                new DecreaseAttackMove("Growl", 10),
                new DecreaseDefenceMove("Leer", 10)
            };
        public NormalType()
        {
            TypeName = "Normal";
        }
    }
}
