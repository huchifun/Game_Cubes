using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Player
    {
        public int Predicted { get; protected set; }
        public int DiceResult { get; protected set; }
        public int Score { get; protected set; }

        public virtual void Predict()
        {
        }

        public virtual bool AskCheat(int round, int dif)
        {
            return false;
        }

        public bool RollDices(bool cheatDessision, int round, string user)
        {
            Dice dice1 = new Dice();
            Dice dice2 = new Dice();
            bool success = true;

            if (cheatDessision)
            {
                Utils.Print($"{user} решил сжульничать");

                int number = Utils.GetRandom(1, round * 2);
                success = number == 1;
 
                if (success)
                {
                    if (Predicted % 2 == 0)
                    {                        
                        dice1.Roll(Predicted / 2);
                        dice2.Roll(Predicted / 2);
                    }
                    else
                    {
                        dice1.Roll(Predicted / 2);
                        dice2.Roll(Predicted - (Predicted / 2));
                    }

                    Utils.Print($"On the dice fell {dice1 + dice2} points");
                    Utils.Print($"{user} удачно сжульничал");
                }
                else
                {
                    dice1.Roll();
                    dice2.Roll();
                    Utils.Print($"On the dice fell {dice1 + dice2} points");
                    Utils.Print($"{user} не удачно сжульничал");
                }
            }
            else
            {
                dice1.Roll();
                dice2.Roll();
                Utils.Print($"On the dice fell {dice1 + dice2} points");
            }

            DiceResult = dice1 + dice2;

            return success;
        }

        public void CalculateScore(bool cheat)
        {
            if (cheat)
            {
                Score = DiceResult - Math.Abs(Predicted - DiceResult) * 2;
                Utils.Print("Result is 11-abs(11-9)*2: {0} points.\n", Score.ToString());
            }
            else
            {
                Score = DiceResult - Math.Abs(Predicted - DiceResult) * 2;
                int Score2 = Score - 10;
                Utils.Print($"Result is 11-abs(11-9)*2: {Score.ToString()} points minus 10 penalty. Total: {Score2}\n");
                Score -= 10;
            } 
        }
    }
}
