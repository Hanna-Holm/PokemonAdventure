using PokemonAdventure.UserInteraction;
namespace PokemonAdventure.Moves;

internal class DecreaseDefenceMove : Move
{
    public override string Name { get; init; }
    public int Amount { get; init; }

    public DecreaseDefenceMove(string name, int amount)
    {
        Name = name;
        Amount = amount;
    }

    public override void GetUsedBy(Pokemon attacker, Pokemon target)
    {
        base.GetUsedBy(attacker, target);
        target.Defence -= this.Amount;
        printer.Print($"{target.Name} lost {this.Amount} defence and now has {target.Defence} defence left!");
    }
}
