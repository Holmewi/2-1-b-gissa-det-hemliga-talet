using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1B
{
    public class SecretNumber
    {
        // Mina commits skickades inte i väg på grund av att jag var i fel mapp. 
        // Jag har lagt upp mina commits i en text-fil som heter Commits
        public const int MaxNumberOfGuesses = 7;
        private int[] _guessedNumbers;
        private int _number;

        public const int MinValue = 1;
        public const int MaxValue = 100;

        public bool CanMakeGuess { get; private set; }

        public int Count { get; private set; }

        public int GuessesLeft { get; private set; }


        // Tilldelar _count värdet 0 och ett slumpmässigt tal mellan 1 och 100 till _number
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, Count);

            CanMakeGuess = true;

            Random randomNumber = new Random();
            _number = randomNumber.Next(MinValue, MaxValue + 1);

            Count = 0;
        }

        public bool MakeGuess(int guessedNumber)
        {
            if (Count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (guessedNumber < 1 || guessedNumber > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

            // Tog ett tag innan jag insåg att jag själv var tvungen att öka världet på _count vid varje gissning.
            Count++;

            if (guessedNumber == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", Count);
                return true;
            }

            if (Count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
                return false;
            }
            if (guessedNumber < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", guessedNumber, (MaxNumberOfGuesses - Count));
                return false;
            }

            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", guessedNumber, (MaxNumberOfGuesses - Count));
                return false;
            }

        }

        // Konstruktorn som skickar ut värderna som initieras i methoden med samma namn
        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            GuessesLeft = MaxNumberOfGuesses - Count;
            Initialize();
        }
    }
}
