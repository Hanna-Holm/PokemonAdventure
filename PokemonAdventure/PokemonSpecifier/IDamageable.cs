namespace PokemonAdventure.PokemonSpecifier
{
    internal interface IDamageable
    {
        //int Health { get; set; }
        //void TakeDamage(int health, Pokemon otherPokemon);
        public void TakeDamage(int damage);
    }
}