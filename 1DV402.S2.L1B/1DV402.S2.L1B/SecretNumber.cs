﻿using System;
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

        public bool CanMakeGuess 
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || _guessedNumbers.Length == _number)
                {
                    return false;
                }

                return true;
                
            } 
            
            private set
            {
                
            }
        }

        public int Count { get; private set; }

        public int GuessesLeft { 
            get
            {
                return (MaxNumberOfGuesses - Count);
            }       
        } 


        // Tilldelar _count värdet 0 och ett slumpmässigt tal mellan 1 och 100 till _number
        public void Initialize()
        {
            Array.Clear(_guessedNumbers, 0, _guessedNumbers.Length);

            Random randomNumber = new Random();
            _number = randomNumber.Next(MinValue, MaxValue + 1); 

            CanMakeGuess = true;

            Count = 0;

                  
        }

        public bool MakeGuess(int number)
        {     
            if (Count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException();
            }

            if (number < 1 || number > 100)
            {
                throw new ArgumentOutOfRangeException();
            }

   
            // Hittade lösningen på http://stackoverflow.com/questions/1821045/value-equal-to-any-value-in-an-array




            /*
            if (_guessedNumbers.Contains(number))
            {
                Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                return false;
            }
             


            if (_guessedNumbers[Count] == number)
            {
                Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                throw new ApplicationException();
            }
            */


            //Array.Sort(_guessedNumbers);
            //int sameGuess = Array.BinarySearch(_guessedNumbers, number);
            
            for (int i = 0; i < _guessedNumbers.Length; i++)
            {

                if (number == _guessedNumbers[i])
                {
                    Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                    CanMakeGuess = false;
                    return false;
                }
            }
             
            

            /*
            foreach (int sameGuess in _guessedNumbers)
            {
                if (number == sameGuess)
                {
                    Console.WriteLine("Du har redan gissat på {0}. Gör om gissningen!", number);
                    throw new ApplicationException();
                }
            }
            _guessedNumbers[Count] = number;
             */


            if (CanMakeGuess == true)
            {
                Count++;
            }

            

            if (number == _number)
            {
                Console.WriteLine("RÄTT GISSAT. Du klarade det på {0} försök.", Count);
                CanMakeGuess = false;
                return true;
            }

            if (Count == MaxNumberOfGuesses)
            {
                Console.WriteLine("Det hemliga talet är {0}", _number);
                return false;
            }
            if (number < _number)
            {
                Console.WriteLine("{0} är för lågt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - Count));
                return false;
            }

            else
            {
                Console.WriteLine("{0} är för högt. Du har {1} gissningar kvar.", number, (MaxNumberOfGuesses - Count));
                return false;
            }

        }

        // Konstruktorn som skickar ut värderna som initieras i methoden med samma namn
        public SecretNumber()
        {
            _guessedNumbers = new int[MaxNumberOfGuesses];
            Initialize();
        }
    }
}
