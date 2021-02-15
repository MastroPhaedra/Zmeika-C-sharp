using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zmeika_C_sharp
{
    public class BodyPart
    {
        public char Symbol { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }
        public BodyPart(char symbol, int posX, int posY)
        {
            Symbol = symbol;

            PosX = posX;
            PosY = posY;
        }
        public void SetPosition(int x, int y)
        {
            Clear();

            PosX = x;
            PosY = y;
            Draw();
        }
        public void Move(MoveDirection direction)
        {
            Clear();

            switch (direction)
            {
                case MoveDirection.UP:
                    PosY--;
                    break;
                case MoveDirection.DOWN:
                    PosY++;
                    break;
                case MoveDirection.LEFT:
                    PosX--;
                    break;
                case MoveDirection.RIGHT:
                    PosX++;
                    break;
            }

            var arenaWidth = Game.Current.Width;
            var arenaHeight = Game.Current.Height;

            // https://github.com/MarinaOleinik/Snake_King/blob/master/Snake/Walls.cs
            // https://habr.com/ru/post/348262/

            if (PosX<0)
            {
                PosX = arenaWidth - 1;
            }
            else if (PosX >=arenaWidth)
            {
                PosX = 0;
            }
            //
            if(PosY<0)
            {
                PosY = arenaHeight - 1;
            }
            else if (PosY >=arenaHeight)
            {
                PosY = 0;
            }
            //

            Draw();
        }
        public void Clear()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(' ');
        }

        public void Draw()
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(Symbol);
        }
    }
}
