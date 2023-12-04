using PokemonAdventure.PokemonSpecifier;

namespace PokemonAdventure
{
    internal class PokemonGenerator
    {
        private int levelOffset = 2;
        private int gymLeaderLevel = 7;

        /*
          1. Concept: Method overloading
          2. How? We have two methods with the same name in the same class but with different parameter lists.
             The first GeneratePokemon method takes AllPokemon as a parameter and generates a Pokemon from all
             knownPokemon from AllPokemon, while the second GeneratePokemon method also takes a parameter for the
             current Pokemon owned by the player, and it generates a Pokemon that matches the level of the playerPokemon.
          3. Why? Because both these methods generates Pokemon, they both should be named GeneratePokemon, as it is what they do.
             However, the methods must have a unique parameter list if the identifiers are the same. The parameter list must
             differ in the number of parameters or/and the parameter types, for the compiler to be able to identify which method
             to run. The method name and its parameters is the signature for the method, and each method must have an unique
             signature.
             This also creates more readability, that these methods do the same thing just in a slightly different way.
        */
        public Pokemon GeneratePokemon(AllPokemon all)
        {
            Pokemon samplePokemon = all.KnownPokemon[new Random().Next(0, all.KnownPokemon.Count)];
            return samplePokemon.Clone();
        }

        public Pokemon GeneratePokemon(AllPokemon all, Pokemon playerPokemon)
        {
            Pokemon pokemon = GeneratePokemon(all);
            int rivalLevel = GenerateLevel(playerPokemon);
            pokemon.Level = rivalLevel;
            return pokemon;
        }

        public Pokemon GenerateGymLeaderPokemon(AllPokemon all)
        {
            Pokemon pokemon = new Pokemon(GeneratePokemon(all), gymLeaderLevel);
            pokemon.Accuracy += 2;
            return pokemon;
        }

        private int GenerateLevel(ILevelable pokemon)
        {
            int level = pokemon.Level;
            int minValue = level - levelOffset;
            int maxValue = level + levelOffset;
            return new Random().Next(minValue, maxValue);
        }
    }
}
