using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zmeika_C_sharp
{
    public class Game
    {
        // FPS = SPEED
        public int FPS = 24; //Game Curent FPS=***;
        public int Width { get; set; }
        public int Height { get; set; }
        public Snake Snake { get; set; }
        public int Score_max_amount;
        //
        public static Game Current;
        //
        public bool IsGameOver { get; set; }
        public Food Food { get; set;}
        //Params settings = new Params();
        public Sounds main_sound=new Sounds("путь и название файла");
        main_sound.Play();
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
            // тут должна стоять основная задняя тема музыки

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
            //Snake.Draw();
            new Speed(Snake.count,FPS);
            Thread.Sleep(1000 / FPS);
        }
        public void CheckCollisions()
        {
            if (Snake.Head.PosX == Food.PosX && Snake.Head.PosY == Food.PosY)
            {
                Snake.Grow();
                Food = new Food();
            }
            if (Snake.Body.Any(body => Snake.Head.PosX == body.PosX && Snake.Head.PosY == body.PosY)|| (Snake.count >= Score_max_amount))
            {
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
