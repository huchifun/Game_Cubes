using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Utils
    {
        private static Random _random;

        public static void Currentscore(int userscore, int compscore)
        {
            Print("---------- Current score ---------");
            Print($"User:\t\t{userscore} points\nComputer:\t{compscore} points\n");
        }

        public static void PrintResults(Round[] rounds)
        {
            Print("\n #\t|\t\t| Comp\t|User\t");
            Print("-------------------------");

            int userTotal = 0;
            int compTotal = 0;

            foreach (Round round in rounds)
            {
                Print($" \t| Predicted:\t| {round.CompResult.Predicted}\t|{round.UserResult.Predicted}\t");
                Print($" {round.Id}\t| Dice:\t\t| {round.CompResult.DiceResult}\t|{round.UserResult.DiceResult}\t");
                Print($" \t| Penalty:\t| {round.CompResult.Penalty}\t|{round.UserResult.Penalty}\t");
                Print($" \t| Score:\t| {round.CompResult.Score}\t|{round.UserResult.Score}\t");
                Print("-------------------------");

                userTotal += round.UserResult.Score;
                compTotal += round.CompResult.Score;

            }

            Print($" \t| Total Score:\t| {compTotal}\t|{userTotal}\t");
            Print("-------------------------\n");

            int dif = Math.Abs(userTotal - compTotal);

            if (userTotal > compTotal)
            {
                Print($"User wins by {dif}");
            }
            else if (userTotal < compTotal)
            {
                Print($"Comp wins by {dif}");
            }
            else
            {
                Print("Ничья!");
            }
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
        }

        public static void Print(int message)
        {
            Console.WriteLine(message);
        }

        public static void Print(string message, string v)
        {
            Console.WriteLine(message, v);
        }

        public static int GetInt(string message)
        {
            Print(message);
            return Convert.ToInt32(Console.ReadLine());
        }

        public static int GetRandom(int from, int to)
        {
            Random rnd = CreateRandomizer();

            return rnd.Next(from, to + 1);
        }


        // синглтон
        private static Random CreateRandomizer()
        {
            if (_random == null)
            {
                _random = new Random();
            }

            return _random;
        }
    }
}
