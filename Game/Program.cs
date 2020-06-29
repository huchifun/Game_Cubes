using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Player user = new User();
            Player computer = new Computer();

            Round[] rounds = new Round[3];

            Utils.Print("--- Start game ---\n");

            do
            {
                for (int i = 0; i < 3; i++)
                {
                    rounds[i] = new Round()
                    {
                        Id = i + 1
                    };

                    int dif = Math.Abs(user.Score - computer.Score);
                    user.Predict();
                    bool userCheatDesission = user.AskCheat(i + 1, dif);
                    bool userCheatSuccess = user.RollDices(userCheatDesission, i + 1, "Пользователь");
                    user.CalculateScore(userCheatSuccess);

                    rounds[i].UserResult = new RoundResult()
                    {
                        Predicted = user.Predicted,
                        DiceResult = user.DiceResult,
                        Score = user.Score,
                        Penalty = userCheatSuccess ? 0 : 10
                    };

                    computer.Predict();
                    bool compCheatDesission = computer.AskCheat(i + 1, dif);
                    bool compChaetSuccess = computer.RollDices(compCheatDesission, i + 1, "Компьютер");
                    computer.CalculateScore(compChaetSuccess);

                    rounds[i].CompResult = new RoundResult()
                    {
                        Predicted = computer.Predicted,
                        DiceResult = computer.DiceResult,
                        Score = computer.Score,
                        Penalty = compChaetSuccess ? 0 : 10
                    };

                    Utils.Currentscore(user.Score, computer.Score);
                }

                Utils.PrintResults(rounds);

                Utils.Print("\nDo you want to play ones more (Y/N)");
            }
            while (Console.ReadLine() == "Y");
        }
    }
}
