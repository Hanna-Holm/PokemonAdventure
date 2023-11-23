namespace PokemonAdventure;

internal interface ILevelable
{
    public int ExperiencePoints { get; set; }
    public int Level { get; set; }

    public bool ShouldLevelUp
        => ExperiencePoints >= 100;

    // Default interface method!
    public void LevelUp()
    {
        if (ShouldLevelUp)
        {
            Level++;
        }
    }
}
