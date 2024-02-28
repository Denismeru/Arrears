using System;
using System.IO;
using System.Threading.Tasks;

namespace AsinApp
{
    class Program
    {
        
    async static Task Main()
        {
            int i;
            bool g=true;
            string[] s = new string[5600];
            async void Search()
            {
                await Task.Delay(5000);//задержка выполнения задания
                StreamWriter file = new StreamWriter("test.txt");
                Random rd = new Random();
                for (i = 0; i < 5600; i++)
                {
                    file.WriteLine(rd.Next());
                }
                file.Close();
                StreamReader f = new StreamReader("test.txt");
                string str;
                i = 0;
                while ((str = f.ReadLine()) != null)
                {
                    s[i] = str;
                    i++;
                }
                f.Close();
                for (i = 0; i < 5600; i++)
                {
                    if (s[i] != null) Console.WriteLine(s[i]);
                }
            }
            void Dialog()
                {
                Console.WriteLine("Жди.......");
            }
            string name, surname,qu;
            Console.Write("Привет! Как тебя зовут? ");
            name = Console.ReadLine();
            Console.Write($"Хорошо... {name}, а какая у тебя фамилия? ") ;
            surname = Console.ReadLine();
            Console.Write($"Хорошо... {surname} {name}, ты хочешь вывести данные из файла на экран? ");
            while (g)
            {
                qu = Console.ReadLine();
                if ((qu == "Да") || (qu == "да"))
                {
                    await Task.Run(() => Search());
                    Console.WriteLine("Хорошо, начинаю выводить!");
                    Console.WriteLine("Сейчас появится экра-");
                    await Task.Run(() => Dialog());
                    g = false;
                }
                else Console.WriteLine("Введи 'Да'...");
            }
            Console.ReadLine();
        }
    }
}