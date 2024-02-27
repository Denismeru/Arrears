using System;
using System.IO;
namespace Qu_3
{
    class Prog
    {
        static void Main()
        {
            try
            {
                StreamReader f = new StreamReader("Dates.txt");
                StreamWriter S = new StreamWriter("spring.txt");
                string s;
                const int n = 5;
                int[] day = new int[n];
                int[] month = new int[n];
                int[] year = new int[n];
                string[] buf;
                int i = 0;
                while ((s = f.ReadLine()) != null)
                {
                    buf = s.Split('.');
                    day[i] = Convert.ToInt32(buf[0]);
                    month[i] = Convert.ToInt32(buf[1]);
                    year[i] = Convert.ToInt32(buf[2]);
                    if ((day[i] <= 0) || (day[i] > 31) || (month[i] <= 0) || (month[i] > 12) || (year[i] <= 0) || (year[i] > 2024))
                    {
                        Console.WriteLine("Найдена несуществующая дата. Она будет пропущена");
                        continue;
                    }
                    if ((month[i] >= 3) && (month[i]<=5))
                    {
                        S.WriteLine($"{day[i]}.{month[i]}.{year[i]}");
                    }
                    i++;
                }
                f.Close();
                S.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Проверьте правильность имени файла!");
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return;
            }
        }
    }
}
