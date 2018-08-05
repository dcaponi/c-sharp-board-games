using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BoardGameSuite
{
    class WoFBoard : IBoard
    {
        private string category;
        private string solution;
        public bool Solved;
        private char[] puzzle;
        private List<string> guessesList = new List<string>();
        private bool playerCanMoveAgain;

        public WoFBoard()
        {
            Solved = false;
            setPuzzle();
            puzzle = dashes(solution);
            printPuzzle();
        }

        private static char[] dashes(string Solution)
        {
            int nLetters = Solution.Length;

            char[] puzzle = new char[nLetters];

            for (int i = 0; i < nLetters; i++)
            {
                puzzle[i] = '_';
            }

            return puzzle;
        }

        private void printPuzzle()
        {
            string line = String.Concat(Enumerable.Repeat("---", puzzle.Length));
            Console.WriteLine(line);
            Console.Write("\n    ");
            for (int i = 0; i < puzzle.Length; i++)
            {
                Console.Write(puzzle[i] + " ");
            }
            Console.WriteLine("\n");
            Console.WriteLine(line);
            Console.WriteLine("\n");
            Console.WriteLine(category);
        }

        private void setPuzzle()
        {
            Dictionary<string, string[]> puzzles = new Dictionary<string, string[]>();

            string[] animals = new string[] { "COBRA", "ELEPHANT", "OSTRICH", "CHICKEN" };
            puzzles.Add("Animals", animals);

            string[] instruments = new string[] { "FLUTE", "BANJO", "HARP", "GUITAR", "FRENCH HORN" };
            puzzles.Add("Instruments", instruments);

            string[] desserts = new string[] { "PIE", "COOKIES", "CAKE" };
            puzzles.Add("Desserts", desserts);

            string[] states = new string[] { "ALABAMA", "ALASKA", "ARIZONA", "ARKANSAS", "CALIFORNIA", "COLORADO", "CONNECTICUT", "DELAWARE", "FLORIDA", "GEORGIA", "HAWAII", "IDAHO", "ILLINOIS", "INDIANA", "IOWA", "KANSAS", "KENTUCKY", "LOUISIANA", "MAINE", "MARYLAND", "MASSACHUSETTS", "MICHIGAN", "MINNESOTA", "MISSISSIPPI", "MISSOURI", "MONTANA NEBRASKA", "NEVADA", "NEW HAMPSHIRE", "NEW JERSEY", "NEW MEXICO", "NEW YORK", "NORTH CAROLINA", "NORTH DAKOTA", "OHIO", "OKLAHOMA", "OREGON", "PENNSYLVANIA RHODE ISLAND", "SOUTH CAROLINA", "SOUTH DAKOTA", "TENNESSEE", "TEXAS", "UTAH", "VERMONT", "VIRGINIA", "WASHINGTON", "WEST VIRGINIA", "WISCONSIN", "WYOMING" };
            puzzles.Add("States", states);

            string[] classmates = new string[] { "AIDAY", "CANDICE", "CHIDOZIE", "DANIEL", "DAVID", "DAVID", "DIMITRI", "DOMINICK", "EKAM", "ELENA", "ESMERY", "FILIZ", "HAVISHA", "JAMAL", "JANE", "JAYSER", "JONATHON", "JULIA", "KENDRA", "KENNY", "MAGGIE", "MICHAEL", "MIKAELA", "MONIQUE", "OBINNA", "PABLO", "PARVATHI", "RUTHA", "SAUL", "SONYA", "SUSAN", "TABITHA", "THINLEY", "THOMAS", "THUY", "TIMOTHY", "VILDE", "ZEWDITU" };
            puzzles.Add("Classmate First Names", classmates);

            List<string> keys = new List<string>(puzzles.Keys);
            int size = puzzles.Count;
            Random rand = new Random();
            category = keys[rand.Next(size)];
            solution = puzzles[category][rand.Next(puzzles[category].Length)];

        }

        private bool guessLetter(char letter)
        {
            bool inSolution = false;
            letter = char.ToUpper(letter);

            for (int i = 0; i < solution.Length; i++)
            {
                if (solution[i] == letter)
                {
                    puzzle[i] = letter;
                    inSolution = true;
                }
            }

            printPuzzle();

            return inSolution;
        }

        private void attemptSolve(string guess)
        {
            bool isSolution = false;

            guess = guess.ToUpper();

            if (solution == guess)
            {
                puzzle = guess.ToCharArray();
                isSolution = true;
            }

            printPuzzle();

        }
        public bool goAgain()
        {
            if (playerCanMoveAgain)
            {
                playerCanMoveAgain = false;
                return true;
            }
            return false;
        }
        public void acceptMove( Move moveInput )
        {
            playerCanMoveAgain = false;
            WoFMove move = (WoFMove) moveInput;
            if( move.guess.Length == 1)
            {
                playerCanMoveAgain = guessLetter(move.guess[0]);
            }
            else
            {
                attemptSolve(move.guess);
            }
        }
        public bool isSolved()
        {
            return (puzzle.SequenceEqual(solution.ToCharArray()));
        }
    }
}
