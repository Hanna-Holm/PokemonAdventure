using PokemonAdventure.Moves;
using PokemonAdventure.UserInteraction;

namespace PokemonAdventure;

internal class Pokemon : ILevelable, IHealable, IDamageable
{
    public string Name { get; init; }
    public int Level { get; set; } = 5;
    public int ExperiencePoints { get; set; }
    public int Health { get; set; }
    private int maxHealth { get; set; } = 100;
    public int Speed { get; set; } = 25;
    public int Accuracy { get; set; } = 3;
    private int defence = 25;
    public int Defence 
    {
        get => defence;
        set
        {
            if (value < 0)
                defence = 0;
            else
                defence = value;
        }
    }

    public List<Move> Moves { get; private set; } = new List<Move> { };

    private Validator validator = new Validator();
    private ConsolePrinter printer = new ConsolePrinter();

    public Pokemon(string name, Move move)
    {
        Name = name;
        Moves.Add(move);
        this.Health = maxHealth;
        Moves.Add(new DecreaseDefenceMove("Screech", 5));
    }

    public Pokemon(string name, Move move, int Level) : this(name, move)
    {
        this.Level = Level;
    }

    public Move ChooseMove()
    {
        bool isValid = false;
        int numberOfMovesAvailable = this.Moves.Count;
        string choice = "";

        do
        {
            printer.Print("Press the number for which attack you want to do:\n");

            for (int i = 0; i < numberOfMovesAvailable; i++)
            {
                Console.WriteLine($"{i + 1}. {this.Moves[i].Name}");
            }
            choice = Console.ReadLine();
            isValid = validator.CheckIfValidNumber(choice, numberOfMovesAvailable);
        } while (!isValid);

        int moveNumber = int.Parse(choice);
        return this.Moves[moveNumber - 1];
    }

    public void MakeMove(Move move, Pokemon target)
    {
        // Subtypspolymorfism? Beroende på vilken typ av move det är anropas GetUsedBy på den typen
        move.GetUsedBy(this, target);
    }

    public void TakeDamage(int damage)
    {
        this.Health -= damage;
    }

    public void Heal(int amount)
    {
        this.Health += amount;
    }
}
