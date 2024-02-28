using System;
using System.Threading;

namespace SemaphoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 8; i++)
            {
                Reader reader = new Reader(i);
            }
            Console.ReadLine();
            Console.Write("Стада больше нет...");
            Console.ReadLine();
        }
    }

    class Reader
    {
        // создаем семафор
        static Semaphore sem = new Semaphore(4, 4);
        Thread myThread;
        int count = 1;// счетчик насыщения

        public Reader(int i)
        {
            myThread = new Thread(Read);
            myThread.Name = $"Животное {i.ToString()}";
            myThread.Start();
        }

        public void Read()
        {
            while (count > 0)
            {
                sem.WaitOne();

                Console.WriteLine($"{Thread.CurrentThread.Name} пришло на поляну");

                Console.WriteLine($"{Thread.CurrentThread.Name} начало есть");
                for (int j = 1; j <= 5; j++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} наелось на {20 * j} процентов");
                    Thread.Sleep(500);
                }

                Console.WriteLine($"{Thread.CurrentThread.Name} лопнуло от обжорства :(");
                sem.Release();
                count--;
                Thread.Sleep(1000);
            }
        }
    }
}