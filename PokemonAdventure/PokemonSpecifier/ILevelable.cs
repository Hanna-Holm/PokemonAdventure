namespace PokemonAdventure.PokemonSpecifier
{
    internal interface ILevelable
    {
        /*
          1. Concept: Interfaces 
          2. How? This is an interface of ILevelable and used by pokemons.
             The name of an interface has a convention to start with an "I".
             Pokemons are ILevelables meaning that they have all things that an
             ILevelable has. All pokemons are ILevelables but not all ILevelables are Pokemons.
             ILevelable contains signatures for methods as well as propertiesm that is mandatory for its subtypes to implement.
             It defines what must get implemented in the classes that implements this interface.
             The interface is a contract that all the types that implements this interface will have
             implementations for all the members that the interface have signatures for.
             The ILevelable interface does not have any default implementation itself.
             All members in the interface has the access modifier public, and the exact signature must
             be implemented for the members in the subtypes as defined in the interface.
             The specific signature for a members signature includes access modifier, data type, accessors,
             return type and parameter list.
          3. Why? Subtype-polymorphism! It helps us write code that can operate on a wide range of objects.
             Meaning that we can re-use instances from an ILevelable for each different type of
             ILevelable there is, meaning that we can use the supertype ILevelable wherever a subtype of ILevelable
             is expected. 
        */

        public int Level { get; set; }
        public bool ShouldLevelUp {  get; }
        public double LevelThreshold { get; }
        public void LevelUp();
        public int GetMaxHealthForLevel(int level);
        public int GetPowerForLevel(int level);
        public int GetDefenceForLevel(int level);
        
    }
}