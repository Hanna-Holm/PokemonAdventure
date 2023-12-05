using PokemonAdventure.Moves;
using PokemonAdventure.PokemonTypes;
using PokemonAdventure.UserInteraction;
using System.Diagnostics.CodeAnalysis;

namespace PokemonAdventure.PokemonSpecifier
{
    /*
      1. Concept: Multiple interfaces
      2. How? Pokemons implements all the multiple interfaces ILevelable, IHealable and IDamageable.
         Pokemon is a concrete class and is a subtype of all these interfaces, this guarantees that all the signatures 
         of all these interaces are implemented in Pokemon.
         When a Pokemon implements several interfaces it promises to fulfill the contract signatures in every one of
         these interfaces.
      3. Why? To enable subtype-polymorphism: to be able to use the subtype Pokemon where the supertype is expected.
         A Pokemon can be in different contexts and have different roles, as a Pokemon for example both can have a level
         as defined in ILevelable, and take damage as defined in IDamageable.
         We can then use a Pokemon whenever any object that implements the interface is expected, such as in PokemonGenerator
         in the method GenerateLevel(ILevelable pokemon), because all ILevelables have a Level.
    */
    internal class Pokemon : ILevelable, IHealable, IDamageable
    {
        public required string Name { get; set; }

        /* 
          1. Concept: Object composition
          2. How? The Pokemon class has a IPokemonType as a property. Pokemon is composed of IPokemonType,
             and each Pokemon instance will have a IPokemonType as a Type.
             So when creating an object of Pokemon, the IPokemonType property will be set to a specific type,
             which can be for example NormalType, WaterType or FireType, each type has their own TypeSpecificMoves.
          3. Why? This enables reuse of IPokemonType. We use dependency injection to the set the type of IPokemonType 
             of a Pokemon instance, which enables each Pokemon to have its own specific IPokemonType.
             This also enables a Pokemon to get access to all the type-specific moves that are within their own IPokemonType type only,
             and not moves from any other type. The type of IPokemonType determines what moves will be available for the Pokemon instance.
             Beacuse the IPokemonType has its own resposibility, this approach increases maintainability of the program,
             as the Pokemon class can be focused on Pokemon and not include all possible types of Pokemon.
        */
        public required IPokemonType Type { get; init; }

        /*
          1. Concept: Encapsulation
          2. How? By using the access modifier private, we ensure that this property ExperiencePoints is only accessible 
             within this class Pokemon, the property is hidden - encapsulated - within the class.
             The private property ExperiencePoints is only accessed and its value is set from the public method 
             IncreaseExperiencePointsBasedOf(Pokemon defeated) within the same class, which is part of the public interface 
             of the Pokemon class which we can access from outside.
          3. Why? We only see the public interface from outside this class, and we hide the implementation details of 
             how this class works under the hood by using the private access modifier on this property, it can only accessed only from 
             within the same class. This guarantees that the property is not accessed by mistake from outside of this class, 
             which otherwise could cause errors and incorrect functionality of the program.
             This also makes the program more maintainable, as we can change the implementation details on how ExperiencePoints works
             under the hood, while keeping the public interface unchanged.
         */
        private int ExperiencePoints { get; set; } = 0;
        private int levelFactor = 10;
        public int Level { get; set; } = 5;

        /*
          1. Concept: Computed properties
          2. How? The computed property calculates the LevelThreshold, a variable needed to determine when the pokemon should level up.
             The calculation is done by using the property Level on the same Pokemon instance.
             The computed property LevelTheshold does not hold any value itself, but instead gets its value from calculating form the Level property
             every time its accessed.
          3. Why? This removes the need for a seperate method to caluculate this value. Each access triggers a new calucaltion
             which is needed every time we need to see if a pokemon should level up or not. 
        */
        public double LevelThreshold => (Level - 4) * 50 + 10;
        public bool ShouldLevelUp => ExperiencePoints >= LevelThreshold;
        private int currentHealth;
        public int CurrentHealth
        {
            get => currentHealth;
            set
            {
                if (value < 0)
                    currentHealth = 0;
                else
                    currentHealth = value;
            }
        }
        public int MaxHealth { get; set; }

        private int power;
        public int Power 
        {
            get => power;
            set
            {
                if (value < 0)
                    power = 0;
                else
                    power = value;
            }
        }
        private int maxAccuracy = 9;
        public int minAccuracy = 3;
        private int accuracy = 9;
        public int Accuracy
        {
            get => accuracy;
            set
            {
                if (value < minAccuracy)
                    accuracy = 3;
                else
                    accuracy = value;
            }
        } 

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

        public List<Move> TypeSpecificMoves { get; }
        public List<Move> Moves { get; private set; } = new List<Move> { };

        private Validator validator = new Validator();
        private ConsolePrinter printer = new ConsolePrinter();
        private int pauseInMs = 1000;

        /* 
          1. Concept: Dependency injection 
          2. How? Creating a pokemon by injecting a IPokemonType. The specific type is created outside of this class 
             before instantiating the pokemon object, and then injected into the constructor of the Pokemon class. 
             The specific value of IPokemonType Type in an instance of the Pokemon is set to the IPokemonType type injected into its consturctor. 
          3. Why? This increases maintainability, since we can change the IPokemonType without affecting the implementation of the pokemon class.
             It also ensures that we do not have to re-write the code of the Pokemon class, instead we can
             simply add to the exisiting code. The creation of the IPokemonType is seperated from how it is used in the Pokemon class.
        */

        [SetsRequiredMembers]
        public Pokemon(string name, IPokemonType type)
        {
            this.Name = name;
            this.Type = type;
            GenerateMoves(4);
        }

        /*
          1. Concept: Constructor overload
          2. How? We define two different constructors in this class, one the that takes the parameters
             string name and IPokemonType, and one that takes the parameters Pokemon pokemon and int Level
          3. Why? This enables object construction is two different ways. We can create new objects of this class
             by calling either one of these two constructors. This makes the creation of objects more flexible.
        
          1. Concept: Constructor chaining
          2. How? We use the syntax : this() in the second constructor. The keyword this refers to the same class.
             and we pass on the parameters needed in the first constructor which in this case is name and type. 
             The way this works is that when creating a new object by calling this second constructor,
             the chained constructor is called first with name and type, and after that this constructor
             that called the chained constructor is executed.
          3. Why? This enables code reuse, and avoids code duplication, as we can run the code from the chained constructor first
             and therefore do not need to write the same code twice, while also ensuring that each instance of Pokemon will be created
             in a correct way.
        */
        [SetsRequiredMembers]
        public Pokemon(Pokemon pokemon, int Level) : this(pokemon.Name, pokemon.Type)
        {
            this.Level = Level;
        }

        private void GenerateMoves(int numberOfMoves)
        {
            int random = new Random().Next(0, Type.TypeSpecificMoves.Count - numberOfMoves + 1);

            for (int i = 0; i < numberOfMoves; i++)
            {
                Moves.Add(Type.TypeSpecificMoves[random]);
                random++;
            }
        }

        public Move ChooseMove()
        {
            bool isValid = false;
            int numberOfMovesAvailable = this.Moves.Count;
            ConsoleKeyInfo choice;

            do
            {
                printer.Print("Choose attack:\n");

                for (int i = 0; i < numberOfMovesAvailable; i++)
                {
                    Console.WriteLine($"{i + 1}. {this.Moves[i].Name} \t - {this.Moves[i].Description}");
                }
                choice = Console.ReadKey();
                isValid = validator.CheckIfValidNumber(choice, numberOfMovesAvailable);
            } while (!isValid);

            int moveNumber = int.Parse(choice.KeyChar.ToString());
            Console.Clear();
            return this.Moves[moveNumber - 1];
        }

        public void MakeMove(Move move, Pokemon target)
        {
            /*
              1. Concept: Subtype-polymorphism
              2. How? The method GetUsedBy gets invoked on the run-time type of move. A Move can be any subtype 
                 derived from the abstract Move class. And this method GetUsedBy exists on all of the derived types of Move.
                 For example the concrete classes AttackMove or DecreaseDefenceMove which both have their own 
                 implementation of the GetUsedBy method. Which method is called is determined in run-time 
                 depending on the run-time type, which can be any derived type of Move.
              3. Why? This is subtype-polymorphism by dynamic dispatch which means that the method that gets invoked depends on 
                 what the run-time type of move is. The GetUsedBy method is invoked on the run-time type.
                 The method GetUsedBy is called on whatever type the move is at run-time, which means that we do 
                 not need to write several if-statements to decide what method should be invoked, we can replace 
                 conditional with polymorphism.
            */
            move.GetUsedBy(this, target);
            Console.ReadKey();
        }

        public void TakeDamage(int damage) => this.CurrentHealth -= damage;

        public void IncreaseExperiencePointsBasedOf(Pokemon defeated)
        {
            this.ExperiencePoints += defeated.Level * levelFactor;
            printer.Print($"{this.Name} gained {defeated.Level * levelFactor} XP!");
            
            if (this.ShouldLevelUp)
            {
                while (this.ShouldLevelUp)
                    LevelUp();
            }
            else
                printer.Print($"Current XP count: {this.ExperiencePoints}. You need {LevelThreshold - this.ExperiencePoints} more to level up.");

            Console.ReadKey();
        }

        public void SetStatsBasedOfLevel()
        {
            this.MaxHealth = GetMaxHealthForLevel(this.Level);
            this.Power = GetPowerForLevel(this.Level);
            this.Defence = GetDefenceForLevel(this.Level);
            this.accuracy = maxAccuracy;
        }

        public void LevelUp()
        {
            Level++;
            printer.Print($"{this.Name} grew to level {this.Level}!");
            Console.WriteLine();
            Thread.Sleep(pauseInMs);

            SetStatsBasedOfLevel();
            PrintNewLevelStats();
        }

        public void PrintNewLevelStats()
        {
            Console.WriteLine($"\nMax HP: {this.MaxHealth} (+{MaxHealth - GetMaxHealthForLevel(this.Level - 1)})");
            Console.WriteLine($"Attack: {this.Power} (+{Power - GetPowerForLevel(this.Level - 1)})");
            Console.WriteLine($"Defence: {this.Defence} (+{Defence - GetDefenceForLevel(this.Level - 1)})");
        }

        public void PrintStats() 
            => Console.WriteLine($"Level {Level} {Name}\t HP: {CurrentHealth}/{MaxHealth} | Defence: {this.Defence} | Attack: {this.Power}");

        public void RestoreHealth() => CurrentHealth = MaxHealth;

        public int GetMaxHealthForLevel(int level) => level * 20;

        public int GetPowerForLevel(int level) => level * 6;
        public int GetDefenceForLevel(int level) => level * 5;

        public Pokemon Clone() => new Pokemon(this.Name, this.Type);
    }
}