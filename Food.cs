using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeika_C_sharp
{
    public class Food
    {
        private const char FoodSymbol = '¤';
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Food()
        {
            var arenaWidth = Game.Current.Width;
            var arenaHeight = Game.Current.Height;

            var random = new Random();
            PosX = random.Next(0, arenaWidth);
            PosY = random.Next(0, arenaHeight);
        }
        public void Clear()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(' ');
        }
        public void Draw()
        {
            Clear();
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(FoodSymbol);
        }
    }
}
