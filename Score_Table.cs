using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
namespace Zmeika_C_sharp
{
    public class Score_Table
    {
        //https://metanit.com/sharp/tutorial/5.4.php
        // void не будет ничего возвращать
        public static void save_and_read(string nickname, int score)
        {
            // создаем каталог для файла
            string path = @"Results.json";
            var scores= new Dictionary<string, int>(); //generic (то, что в треугольных скобках)
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                // 
                try
                {
                    scores = JsonConvert.DeserializeObject<Dictionary<string, int>>(json); //метод считывания 
                }
                catch //отлавливает все ошибки и пропускает их
                {}
            }
            scores[string.IsNullOrWhiteSpace(nickname)?"NoNameUSER/ANONUMUS":nickname] = score; //update score
            scores = scores.OrderByDescending(x=>x.Value).ToDictionary(x => x.Key, x => x.Value);
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("TOP5 players:");
            Console.WriteLine(" ");
            for (int i=0; i<5 && i<scores.Count; i++)
            {
                var pair = scores.ElementAt(i); 
                Console.WriteLine($"   {pair.Key} - {pair.Value}");
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(scores));
        }
    }
}
