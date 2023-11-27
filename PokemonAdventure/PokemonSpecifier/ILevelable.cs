namespace PokemonAdventure.PokemonSpecifier
{
    internal interface ILevelable
    {
        //int Level { get; set; }
        //int ExperiencePoints { get; }
        //bool shouldLevelUp { get; set; }
        //int LevelUp();

        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public bool ShouldLevelUp {  get; }
        public void LevelUp();

        public int GetMaxHealthForLevel(int level);

        public int GetPowerForLevel(int level);
        public int GetDefenceForLevel(int level);
    }
}