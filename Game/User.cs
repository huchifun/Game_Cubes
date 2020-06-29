using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class User : Player
    {
        public override void Predict()
        {
            Predicted = Utils.GetInt("Введи число от 2 до 12");

            if (Predicted < 2 || Predicted > 12)
            {
                Utils.Print($"{Predicted} - не входит в допустимый диапазон от 1 до 12. Введи еще раз");
                Predict();
            }

            Utils.Print($"Пользователь загадал число {Predicted}");
        }

        public override bool AskCheat(int round, int dif)
        {
            Utils.Print("Будете жульничать?");

            string reply = Console.ReadLine().ToLower();

            bool answer = reply == "да" || reply == "yes" || reply == "y";

            return answer;
        }

    }
}
