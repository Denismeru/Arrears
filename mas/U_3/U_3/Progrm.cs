using System;

namespace U_3
{
    class Progrm
    {
        static void Main()
        {
            try
            {
                const int n = 5;
                int i, j;
                int[,] mas = new int[n, n];
                Random rd = new Random();
                Console.WriteLine("Изначальный массив:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        mas[i, j] = rd.Next(5);
                        Console.Write($"{mas[i, j]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("Измененный массив:");
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (i + j > n - 1) mas[i, j] = 0;
                        if (i + j < n - 1) Console.Write($"{mas[i, j]} ");
                    }
                    Console.WriteLine();
                }
            }
            catch (ArrayTypeMismatchException e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Ошибка обращения к несуществующему элементу массива");
            }
            catch 
            {
                Console.WriteLine("Ошибка");
            }
        }
    }
}
