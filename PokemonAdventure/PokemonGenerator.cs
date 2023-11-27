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

        public Pokemon GenerateStartingPokemon(PokemonWorld world)
        {
            return world.knownPokemon[new Random().Next(0, world.knownPokemon.Count - 1)];
        }

        public Pokemon GenerateRivalPokemon(PokemonWorld world, Pokemon playerPokemon)
        {
            Pokemon pokemon = GenerateStartingPokemon(world);
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
