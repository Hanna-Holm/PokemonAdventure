using PokemonAdventure.Moves;

namespace PokemonAdventure.PokemonTypes
{
    internal class ElectricType : IPokemonType
    {
        public string TypeName { get; }
        public List<Move> TypeSpecificMoves
            => new List<Move>
            {
                new AttackMove("Thunder shock", 20),
                new AttackMove("Bolt strike", 22),
                new AttackMove("Spark", 18),
                new AttackMove("Volt tackle", 24),
                new AttackMove("Thunder wave", 22),
                new DecreaseAccuracyMove("Sand attack", 2),
                new DecreaseDefenceMove("Leer", 3),
                new DecreaseAttackMove("Growl", 3)
            };

        public ElectricType()
        {
            TypeName = "Electric";
        }
    }
}
