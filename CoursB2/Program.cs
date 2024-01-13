
class program
{
    /// <summary>
    /// Exercice fizzbuzz
    /// </summary>
    class FizzBuzz
    {
        public void Execute()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine("FizzBuzz");
                else if (i % 3 == 0)
                    Console.WriteLine("Buzz");
                else if (i % 5 == 0)
                    Console.WriteLine("Fizz");
                else
                    Console.WriteLine(i);
            }
        }
    }

    /// <summary>
    /// Exercice palindrome
    /// </summary>
    class Palindrome
    {
        public bool CheckWordIfPalindrome(string word)
        {
            int length = word.Length;
            string ReverseWord = "";

            for (int i = 0; i < length; i++)
            {
                ReverseWord += word[length - i - 1];
            }
            Console.WriteLine($"{ReverseWord} x {word}");
            return ReverseWord == word;

        }
    }

    /// <summary>
    /// Exercice de tri de tableau 
    /// </summary>
    class OrderArray
    {
        public void OrderArrayExo(int[] array)
        {
            int taille = array.Length;
            bool echange;

            do
            {
                echange = false;
                for (int i = 0; i < taille - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;

                        echange = true;
                    }
                }
            } while (echange);

            foreach (int number in array)
            {
                Console.Write($"{number} ");
            }
        }
    }

    #region POO/ActionEvent - Exo 
    enum Object
    {
        Apple = 2,
        Pinapple = 4,
        PineApplePen = 6
    }
    class Personnage
    {
        public Action<int> OnGetReward;
        private ScoreContainer scoreContainer;

        public Personnage()
        {
            scoreContainer = new ScoreContainer();
            RegisterEvent();
        }

        public void RegisterEvent()
        {
            OnGetReward += scoreContainer.UpdateScore;

        }
        public void UnegisterEvent()
        {
            OnGetReward -= scoreContainer.UpdateScore;

        }

        public void GetReward(Object a_rewardObject)
        {
            //On cast l'enum en int
            OnGetReward?.Invoke((int)a_rewardObject);
        }


    }

    class ScoreContainer
    {
        int CurrentScore = 0;

        public void UpdateScore(int a_scoreToAdd)
        {
            CurrentScore += a_scoreToAdd;
            Console.WriteLine(CurrentScore);
        }

    }

    #endregion


    #region Exemples du cours
    class monster : IDamageable
    {
        int currentHealth = 5;
        public Action<int> OnHealthChanged;

        InterfaceHealth mobInterface = new InterfaceHealth();

        public monster()
        {
            RegisterEvents();
        }

        public void RegisterEvents()
        {
            OnHealthChanged += mobInterface.ShowCurrentHealth;

        }
        public void UnregisterEvents()
        {
            OnHealthChanged -= mobInterface.ShowCurrentHealth;

        }
        public void TakeDamage(int a_amount)
        {
            currentHealth -= a_amount;
            OnHealthChanged?.Invoke(currentHealth);
        }
    }

    public class InterfaceHealth
    {
        public int displayedHealth;
        


        public void ShowCurrentHealth(int a_currentHealth)
        {
            displayedHealth = a_currentHealth;
            Console.WriteLine($"{displayedHealth}");
        }

    }

    interface IDamageable
    {
        public void TakeDamage(int a_amount);
    }
    #endregion
    static void Main()
    {
        program program = new program();

        //Initialiation des objets d'exercices
        FizzBuzz fizzbuzz = new FizzBuzz();
        Palindrome palindrome = new Palindrome();
        Personnage personnage = new Personnage();
        OrderArray orderArray = new OrderArray();

        monster monster = new monster();


        //utilisations des objets pour les exercices
        int[] arrayInt = { 9, 1, 1, 2, 3, 5, 7, 6, 15 };
        orderArray.OrderArrayExo(arrayInt);

        //monster.TakeDamage(10);
        //monster.UnregisterEvents();
        
        // personnage.GetReward(Object.PineApplePen);
        // personnage.GetReward(Object.Apple);
        //
        // personnage.UnegisterEvent();
    }
}







