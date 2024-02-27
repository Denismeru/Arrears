using System;
using System.IO;
namespace Qu_2
{
    class Prog
    {
        static void Main()
        {
            try
            {
                // назначение источника данных для ввода, вместо клавиатуры
                StreamReader F = new StreamReader("f.txt");
                Console.SetIn(F);
                // назначение приемника данных, вместо экрана
                StreamWriter G = new StreamWriter("g.txt");
                Console.SetOut(G);

                // тест перенаправленного ввода-вывода
                string s = Console.ReadLine();
                Console.WriteLine(s);
                try
                {
                    throw new Exception("what is it?!");
                }
                catch (Exception)
                {
                    Console.WriteLine("Что-то пошло не так...");
                }
                // закрытие потоков ввода-вывода
                F.Close();
                G.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error end: " + e.Message);
                return;
            }
        }
    }
}