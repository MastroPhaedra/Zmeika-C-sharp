using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmeika_C_sharp
{
    public class Speed
    {
        // FPS = SPEED
        public int FPS = 26; //Game Curent FPS=***;
        public Speed()
        {
            if (Snake.count <= 10)
            {
                FPS = 26;
            }
            else if (Snake.count >= 11) //&& Snake.count <= 30)
            {
                FPS = 30;
            }
            else if (Snake.count >= 31 && Snake.count <= 50)
            {
                FPS = 35;
            }
            else if (Snake.count >= 51 && Snake.count <= 70)
            {
                FPS = 40;
            }
            else if (Snake.count >= 71)
            {
                FPS = 45;
            }
            Thread.Sleep(1000 / FPS);
            //else if (Snake.count >= 11)
            //{
            //    FPS++; //- ни в коем случае нельзя ставить, иначе змейка летает
            //}
        }
    }
}
