using PokemonAdventure.Moves;
using PokemonAdventure.PokemonSpecifier;
using PokemonAdventure.PokemonTypes;

namespace PokemonAdventure
{
    internal class AllPokemon
    {
        public List<Pokemon> KnownPokemon = new List<Pokemon>
        {
            new Pokemon("Pikachu", new ElectricType()),
            new Pokemon("Jolteon", new ElectricType()),
            new Pokemon("Meowth", new NormalType()),
            new Pokemon("Rattata", new NormalType()),
            new Pokemon("Bulbasaur", new GrassType()),
            new Pokemon("Oddish", new GrassType()),
            new Pokemon("Charmander", new FireType()),
            new Pokemon("Growlithe", new FireType()),
            new Pokemon("Vulpix", new FireType()),
            new Pokemon("Squirtle", new WaterType()),
            new Pokemon("Horsea", new WaterType()),
            new Pokemon("Goldeen", new WaterType()),
            new Pokemon("Krabby", new WaterType()),
            new Pokemon("Vaporeon", new WaterType()),
            new Pokemon("Seel", new WaterType()),
            new Pokemon("Pichu", new ElectricType()),
            new Pokemon("Pidgey", new FlyingType()),
            new Pokemon("Ekans", new NormalType()),
            new Pokemon("Chansey", new NormalType()),
            new Pokemon("Ditto", new NormalType()),
            new Pokemon("Eevee", new NormalType()),
            new Pokemon("Snorlax", new NormalType())
        };
    };
}