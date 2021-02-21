using System;
using System.Linq;

namespace Zmeika_C_sharp
{
    public class Game
    {
        Params settings = new Params();
        public int Width { get; set; }
        public int Height { get; set; }
        public Snake Snake { get; set; }
        public int Score_max_amount;
        //
        public static Game Current;
        //
        public bool IsGameOver { get; set; }
        public Food Food { get; set;}
        public Speed Speed;
        public Game(int width, int height)
        {
            Current=this;
            Width = width;
            Height = height;

            Score_max_amount = (Width * Height) - 3; //максимальное кол-во очков в поле

            Console.CursorVisible = false;
            Console.SetWindowSize(Width, Height);

        }
        public void Start()
        {
            Snake = new Snake(5, Height / 2);
            Food = new Food();
            Sounds main_sound = new Sounds(settings.GetResourcesFolder());
            main_sound.Play();

            while (true)
            {
                Update();
            }
        }
        public void Update()
        {
            if (IsGameOver)
            {
                return; //после return код не исполняется
            }
            //Console.Clear();

            Snake.Rotate();
            CheckCollisions();
            Snake.Move();
            //
            Food.Draw();
            //
            Speed = new Speed();
        }
        public void CheckCollisions()
        {
            if (Snake.Head.PosX == Food.PosX && Snake.Head.PosY == Food.PosY)
            {
                Sounds eat_sound = new Sounds(settings.GetResourcesFolder());
                eat_sound.PlayEat();
                Snake.Grow();
                Food = new Food();
            }
            if (Snake.Body.Any(body => Snake.Head.PosX == body.PosX && Snake.Head.PosY == body.PosY)|| (Snake.count >= Score_max_amount))
            {
                Sounds dead_sound = new Sounds(settings.GetResourcesFolder());
                dead_sound.GameEnd();
                IsGameOver = true;
                GameOverText.Draw(Width, Height, Snake.count);
                var key = ConsoleKey.Enter;
                while (key != ConsoleKey.R && key != ConsoleKey.Escape)
                {
                    key = Console.ReadKey(true).Key;
                }
                if (key == ConsoleKey.R)
                {
                    Console.Clear();
                    Snake.count = 0;
                    IsGameOver = false;
                    Snake = new Snake(5, Height / 2);
                    Food = new Food();
                }
                else if (key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
