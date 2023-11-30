using PokemonAdventure.PokemonSpecifier;
using PokemonAdventure.PokemonTypes;
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
        private int gymLeaderLevel = 7;

        // 1. Concept: Method overloading
        // 2. How? 
        // 3. Why? 
        public Pokemon GeneratePokemon(AllPokemon all)
        {
            Pokemon samplePokemon = all.KnownPokemon[new Random().Next(0, all.KnownPokemon.Count)];
            return samplePokemon.Clone();
        }

        public Pokemon GeneratePokemon(AllPokemon all, Pokemon playerPokemon)
        {
            Pokemon pokemon = GeneratePokemon(all);
            int rivalLevel = GenerateLevel(playerPokemon.Level);
            pokemon.Level = rivalLevel;
            return pokemon;
        }

        public Pokemon GenerateGymLeaderPokemon(AllPokemon all)
        {
            Pokemon pokemon = GeneratePokemon(all);
            pokemon = new Pokemon(pokemon, gymLeaderLevel);
            pokemon.Accuracy += 2;
            return pokemon;
        }
        public Pokemon GenerateGymLeaderPokemon(AllPokemon all)
        {
            Pokemon pokemon = GeneratePokemon(all);
            int rivalLevel = gymLeaderLevel;
            pokemon.Level = rivalLevel;
            pokemon.Accuracy += 2;
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
