using System;


namespace Zmeika_C_sharp
{
    public class GameOverText
    {
        public static void Draw(int width, int height, int score)
        {
            Console.SetCursorPosition((width / 2) - 5, height / 2);
            Console.WriteLine("Game over!");
            //
            Console.SetCursorPosition((width / 2) - 6, (height / 2) + 1);
            Console.WriteLine("Vash s4et: " + score);
            //Console.SetCursorPosition((Width / 2) - 10, (Height / 2) + 3);
            //Console.WriteLine("Max vozmozhn s4et: " + Score_max_amount);
            Console.SetCursorPosition((width / 2) - 12, (height / 2) + 2);
            Console.Write("Vvedite vash nickname: ");
            Console.CursorVisible = true;
            string text = Console.ReadLine();
            Console.CursorVisible = false;
            Score_Table.save_and_read(text, score);
            Console.SetCursorPosition((width / 2) - 22, (height / 2) + 3);
            Console.WriteLine("Nazhmite ESC dlja vihoda ili R dla restarta");
        }
    }
}
