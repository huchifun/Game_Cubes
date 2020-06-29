using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Computer : Player
    {
        public override void Predict()
        {
            Predicted = Utils.GetRandom(2, 12);
            Utils.Print($"Компьютер загадал число {Predicted}");
        }

        public override bool AskCheat(int round, int dif)
        {
            if (round == 1)
            {
                int n1 = Utils.GetRandom(1, 5);
                return n1 == 1;
            }
            else
            {
                if (dif > 5)
                {
                    if (dif > 15)
                    {
                        int n1 = Utils.GetRandom(1, 5);
                        return n1 <= 3;
                    }
                    else
                    {
                        int n1 = Utils.GetRandom(1, 5);
                        return n1 <= 2;
                    }
                }
                else
                {
                    int n1 = Utils.GetRandom(1, 5);
                    return n1 == 1;
                }
            }
        }
    }
}
