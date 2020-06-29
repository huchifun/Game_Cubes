using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Dice
    {
        public int Number { get; private set; }

        public void Roll()
        {
            Number = Utils.GetRandom(1, 6);
            Print(Number);
        }

        public void Roll(int number)
        {
            Number = number;
            Print(Number);
        }

        public static int operator +(Dice d1, Dice d2)
        {
            return d1.Number + d2.Number;
        }

        public static bool operator >(Dice d1, Dice d2)
        {
            return d1.Number > d2.Number;
        }

        public static bool operator <(Dice d1, Dice d2)
        {
            return d1.Number < d2.Number;
        }

        void Print(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("---------\n|       |\n|   #   |\n|       |\n---------");
                    break;
                case 2:
                    Console.WriteLine("---------\n| #     |\n|       |\n|     # |\n---------");
                    break;
                case 3:
                    Console.WriteLine("---------\n| #     |\n|   #   |\n|     # |\n---------");
                    break;
                case 4:
                    Console.WriteLine("---------\n| #   # |\n|       |\n| #   # |\n---------");
                    break;
                case 5:
                    Console.WriteLine("---------\n| #   # |\n|   #   |\n| #   # |\n---------");
                    break;
                case 6:
                    Console.WriteLine("---------\n| #   # |\n| #   # |\n| #   # |\n---------");
                    break;
            }
        }
    }
}
