namespace PokemonAdventure.PokemonSpecifier
{
    internal interface ILevelable
    {
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public bool ShouldLevelUp {  get; }
        public int LevelThreshold { get; }
        public void LevelUp();

        public int GetMaxHealthForLevel(int level);

        public int GetPowerForLevel(int level);
        public int GetDefenceForLevel(int level);
    }
}