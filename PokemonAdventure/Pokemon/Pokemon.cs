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
        // 1. Concept: Subtype-polymorfism
        // 2. How? The method GetUsedBy gets invoked on the run-time type of move.
        //    A Move can be any type derived from the abstract Move class.
        //    For example the concrete classes AttackMove or DecreaseDefenceMove
        //    which both have their own implementation of the GetUsedBy method.
        //    Which method is called is determined in run-time depending on the
        //    run-time type, which is whatever type of Move that is sent in as 
        //    an argument to this MakeMove method.
        // 3. Why? This enables dynamic dispatch which means that the method that
        //    gets invoked depends on what the run-time type of move is.
        //    The GetUsedBy method is invoked on the run-time type.
        //    This is an example of subtype-polymorphism where we can write general
        //    code that can be used for all subtypes.
        //    The method GetUsedBy is called on whatever type the move is at run-time,
        //    which means that we do not need to write several if-statements to decide
        //    what method should be invoked, we can replace conditional with polymorphism.
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
