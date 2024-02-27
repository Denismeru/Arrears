using System;
using System.IO;
namespace Qu_1
{
    class Program
    {
        static void Main()
        {
            try
            {
                FileStream f = new FileStream("test.txt", FileMode.Create, FileAccess.ReadWrite);
                byte[] x = new byte[10];
                Random rd = new Random();
                rd.NextBytes(x);
                Console.Write("Массив х: ");
                for (int i = 0;i<10;i++) Console.Write($"{x[i]} ");
                Console.WriteLine();
                f.Write(x, 0, 10);
                int a;
                bool b = false,c = false;
                f.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < 10; i++)
                {
                    a = f.ReadByte();
                    int d = (int)Math.Sqrt(a);
                    if (Math.Pow(d,2)==a)
                    {
                        b = true;
                        if (!c)
                        {
                            Console.Write("Числа, которые являются квадратами некоторого целого числа: ");
                            c = true;
                        }
                        Console.Write($"{a} ");
                        
                    }
                }
                if (!b) Console.Write("Нет чисел, которые являются квадратами некоторого целого числа.");
                Console.WriteLine();
                f.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}