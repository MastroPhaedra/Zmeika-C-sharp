using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeika_C_sharp
{
    public class Speed
    {
        public Speed(int count, int FPS)
        {
            if (count<=10)
            {
                FPS = 24;
                //Thread.Sleep(1000 / FPS);
            }
            else if (count >= 11 && count <= 20)
            {
                FPS = 26;
            }
            else if (count >= 21 && count <= 30)
            {
                FPS = 28;
            }
            else if (count >= 31 && count <= 40)
            {
                FPS = 30;
            }
            else if (count >= 41 && count <= 50)
            {
                FPS = 35;
            }
            else if (count >= 51)
            {
                FPS++;
            }
        }
    }
}
