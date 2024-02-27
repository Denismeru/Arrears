using System;
using System.IO;
namespace ConsoleApplication1
{
    class Class1
    {
        static void Main()
        {
            try
            {
                // работа с потоком байтов символы
                FileStream fchar = new FileStream("test1.txt", FileMode.Create, FileAccess.ReadWrite);
                char[] x = new char[10];
                int i;
                Console.WriteLine("Введите 10 символов");
                for (i = 0; i < 10; ++i)
                {
                    x[i] = (char)Console.Read();
                    fchar.WriteByte((byte)x[i]);   // записывается элемент массива 
                }
                Console.ReadLine();
                int a;
                int[] mas = new int[10];
                bool bo=false;
                fchar.Seek(0, SeekOrigin.Begin);    // текущий указатель - на начало 
                for (i = 0; i < 10; i++)
                {
                    a = fchar.ReadByte();
                    if (a == 101)
                    {
                        bo = !bo;
                        mas[i] = a;
                    }
                    if (bo) mas[i] = a;
                }
                if (bo) throw new Exception("Не найдено второй буквы 'e'");
                for (i=0;i<10;i++)
                Console.Write((char)mas[i]+" ");
                fchar.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка работы с файлом: " + e.Message);
            }
        }
    }
}
