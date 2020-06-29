using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class RoundResult
    {
        public int Predicted { get; set; }
        public int DiceResult { get; set; }
        public int Penalty { get; set; }
        public int Score { get; set; }
    }

    public class Round
    {
        public int Id { get; set; }

        public RoundResult UserResult { get; set; }
        public RoundResult CompResult { get; set; }

        public void Print()
        {
            Utils.Print($"Comp score: {CompResult.Score}");
            Utils.Print($"User score: {UserResult.Score}");
        }
    }
}
