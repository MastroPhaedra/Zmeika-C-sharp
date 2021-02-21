using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Zmeika_C_sharp
{
    public class Snake
    {
        public static int count = 0;
        private const char HeadSymbol = '#';
        private const char BodySymbol = '+';

        //public int startX, startY;
        public BodyPart Head { get; set; }
        public List<BodyPart> Body { get; set; }

        public MoveDirection MoveDirection { get; set; } = MoveDirection.RIGHT;

        public Snake(int startX, int startY)
        {
            Head = new BodyPart(HeadSymbol, startX, startY);
            Body = new List<BodyPart>
            {
                new BodyPart(BodySymbol,startX-1,startY),
                new BodyPart(BodySymbol,startX-2,startY)//,
                //new BodyPart(BodySymbol,startX-3,startY)
            };
        }

        public void Rotate()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key==ConsoleKey.W && MoveDirection !=MoveDirection.DOWN)
                {
                    MoveDirection = MoveDirection.UP;
                }
                else if (key==ConsoleKey.S && MoveDirection !=MoveDirection.UP)
                {
                    MoveDirection = MoveDirection.DOWN;
                }
                else if (key==ConsoleKey.A && MoveDirection !=MoveDirection.RIGHT)
                {
                    MoveDirection = MoveDirection.LEFT;
                }
                else if (key==ConsoleKey.D && MoveDirection !=MoveDirection.LEFT)
                {
                    MoveDirection = MoveDirection.RIGHT;
                }
                else if (key == ConsoleKey.P) // ПАУЗА
                {
                    Console.SetCursorPosition(00,00);
                    Console.WriteLine("\n    Press any key (but not 'P') to resume");
                    while (!Console.KeyAvailable) //Console.KeyAvailable == false (то же самое)
                        Thread.Sleep(250); // Loop until input is entered.
                    Console.Clear();
                }
            }
        }

        public void Move()
        {
            var lastX = Head.PosX;
            var lastY = Head.PosY;
            Head.Move(MoveDirection);
            foreach (var body in Body)
            {
                var currentX = body.PosX;
                var currentY = body.PosY;

                //body.PosX = lastX;
                //body.PosY = lastY;

                body.SetPosition(lastX, lastY);

                lastX = currentX;
                lastY = currentY;
            }
            //Body.ForEach(body => body.Move(MoveDirection));
        }
        public void Grow()
        {
            var lastBody = Body.Last();
            Body.Add(new BodyPart(BodySymbol, lastBody.PosX, lastBody.PosY));
            count++;
        }
        //public void Pause()
        //{
        //    if (Console.KeyAvailable)
        //    {
        //        var key = Console.ReadKey(true).Key;
        //        if (key == ConsoleKey.P)
        //        {
        //            Thread.Sleep(1500000000);
        //        }
        //    }
        //}
        //public void Draw()
        //{
        //    Head.Draw();
        //    Body.ForEach(body => body.Draw());
        //}
    }
}
