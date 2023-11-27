using PokemonAdventure.PokemonSpecifier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonAdventure
{
    internal class PokemonGenerator
    {
        private int levelOffset = 2;

        // 1. Concept: Method overloading
        // 2. How? 
        // 3. Why? 
        public Pokemon GeneratePokemon(AllPokemon world)
        {
            Pokemon pokemon = new Pokemon("Placeholder");
            return world.KnownPokemon[new Random().Next(0, world.KnownPokemon.Count - 1)];
        }

        public Pokemon GeneratePokemon(AllPokemon world, Pokemon playerPokemon)
        {
            Pokemon pokemon = GeneratePokemon(world);
            int rivalLevel = GenerateLevel(playerPokemon.Level);
            pokemon.Level = rivalLevel;
            pokemon.SetStatsBasedOfLevel();
            pokemon.RestoreHealth();
            return pokemon;
        }

        private int GenerateLevel(int level)
        {
            int minValue = level - levelOffset;
            int maxValue = level + levelOffset;
            return new Random().Next(minValue, maxValue);
        }
    }
}
