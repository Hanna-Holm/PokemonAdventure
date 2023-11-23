using PokemonAdventure.UserInteraction;

namespace PokemonAdventure.Moves;

internal class AttackMove : Move
{
    public override string Name { get; init; }
    private int damage;
    private ConsolePrinter printer = new ConsolePrinter();

    public AttackMove(string name, int damage)
    {
        Name = name;
        this.damage = damage;
    }

    public override void GetUsedBy(Pokemon attacker, Pokemon target)
    {
        base.GetUsedBy(attacker, target);
        target.TakeDamage(damage);
        printer.Print($"{attacker.Name} made {damage} damage to {target.Name}, who now has {target.Health} health left.");
    }
}
