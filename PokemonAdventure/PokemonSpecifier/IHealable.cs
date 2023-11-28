namespace PokemonAdventure.PokemonSpecifier
{
    internal interface IHealable
    {
        public void RestoreHealth();
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
    }
}