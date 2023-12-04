namespace PokemonAdventure.PokemonSpecifier
{
    // 1. Concept: Interfaces 
    // 2. How? This is an interface of ILevelable and used by pokemons. 
    // Pokemons are ILevelables meaning that they have the same things as an
    // ILevelable has. All pokemons are ILevelables but not all ILevelables are Pokemons. 
    // 3. Why? It hekps us write code that can operate on a wide range of objects.
    // Meaning that we can re-use instances from and ILevelable for each different type of
    // ILevelable there is. It contains signatures for methods as well as properties.
    internal interface ILevelable
    {
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public bool ShouldLevelUp {  get; }
        public double LevelThreshold { get; }
        public void LevelUp();
        public int GetMaxHealthForLevel(int level);
        public int GetPowerForLevel(int level);
        public int GetDefenceForLevel(int level);
        
    }
}