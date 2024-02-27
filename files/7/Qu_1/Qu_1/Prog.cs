using System;
using System.IO;
namespace Qu_1
{
    class Prog
    {
        static void Main()
        {
            try
            {
                const int n = 5;
                int i = 1;
                double x, y, maxY=0, maxX=0,mx=-9;
                string der, der2,m,l;
                BinaryWriter f = new BinaryWriter(new FileStream("binary.dat", FileMode.Create));
                Random r = new Random();
                while (i < n)
                {
                    x = r.NextDouble();
                    y = r.NextDouble();
                    string xString = string.Format("{0:f}", x);
                    string yString = string.Format("{0:f}", y);
                    f.Write($"{xString}");
                    f.Write($"{yString}");
                    i++;
                }
                f.Close();
                FileStream lol = new FileStream("binary.dat", FileMode.Open);
                BinaryReader fin = new BinaryReader(lol);
                try
                {
                    while (true)
                    {
                        der = fin.ReadString();     // чтение из файла вещественных чисел 
                        der2 = fin.ReadString();
                        x = double.Parse(der);
                        y = double.Parse(der2);
                        if (mx < Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)))
                        {
                            mx = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
                            maxX = x;
                            maxY = y;
                        }
                    }
                }
                catch (EndOfStreamException) { }
                fin.Close();
                lol.Close();
                f = new BinaryWriter(new FileStream("binary.dat", FileMode.Append));
                m = Convert.ToString(maxX);
                l = Convert.ToString(maxY);
                f.Write($"{m}");
                f.Write($"{l}");
                f.Close();
                fin = new BinaryReader(new FileStream("binary.dat", FileMode.Open));
                Console.WriteLine("Координаты в файле:\n");
                for (int j = 1; j < n; j++)   // печать содержащихся в файле вещественных чисел
                {
                    der = fin.ReadString();
                    der2 = fin.ReadString();
                    Console.WriteLine($"{j}-ые координаты - ({der};{der2})");
                }
                der = fin.ReadString();
                der2 = fin.ReadString();
                Console.WriteLine();
                Console.WriteLine($"Самые отдаленные координаты - ({der};{der2})");
                fin.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error end: " + e.Message);
                return;
            }
        }
    }
}