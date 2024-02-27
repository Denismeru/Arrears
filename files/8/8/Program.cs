using System;
using System.IO;
using System.Windows.Forms;

namespace _8
{
    class Program
    {
        public enum EngineState { engineAlive, engineDead }
        // Абстрактный базовый класс в иерархии.
        public abstract class Car
        {
            public string PetName { get; set; }
            public int CurrentSpeed { get; set; }
            public int MaxSpeed { get; set; }
            protected EngineState egnState = EngineState.engineAlive;
            public EngineState EngineState
            {
                get { return egnState; }
            }
            public abstract void TurboBoost();
            public virtual void Show()
            {
                Console.WriteLine(PetName);
                Console.WriteLine(MaxSpeed);
                Console.WriteLine(CurrentSpeed);
                Console.WriteLine(egnState);
            }
            public Car() { } //конструктор по умолчанию
            public Car(string name, int maxSp, int currSp)  // конструктор с параметрами
            {
                PetName = name;
                MaxSpeed = maxSp;
                CurrentSpeed = currSp;
            }
        }
        public class SportsCar : Car
        {
            public SportsCar() { }  // конструктор по умолчанию
            public SportsCar(string name, int maxSp, int currSp) // конструктор с параметрами
            : base(name, maxSp, currSp) { }
            public override void TurboBoost()  // переопределение метода TurboBoost() обязательно!
            {
                MessageBox.Show("Таранная скорость!", "Чем быстрее, тем лучше...");
            }
        }
        public class MiniVan : Car
        {
            public MiniVan() { }  // конструктор по умолчанию
            public MiniVan(string name, int maxSp, int currSp)
            : base(name, maxSp, currSp) { }  // конструктор с параметрами
            public override void TurboBoost()
            {
                egnState = EngineState.engineDead;
                MessageBox.Show("Упс!", " Ваш блок двигателя взорвался!");
            }
        }
        static void Main()
        {
            try
            {
                string nm;
                int ms, cs;
                MiniVan cr1 = new MiniVan("Ser", 100, 60);
                BinaryWriter f = new BinaryWriter(new FileStream("file.bin", FileMode.Create));
                BinaryWriter c = new BinaryWriter(new FileStream("file.xml", FileMode.Create));
                f.Write(cr1.PetName);
                f.Write(cr1.MaxSpeed);
                f.Write(cr1.CurrentSpeed);
                SportsCar cr2 = new SportsCar("Bud", 120, 30);
                c.Write(cr2.PetName);
                c.Write(cr2.MaxSpeed);
                c.Write(cr2.CurrentSpeed);
                f.Close();
                c.Close();
                FileStream lo = new FileStream("file.bin", FileMode.Open);
                BinaryReader fi = new BinaryReader(lo);
                nm = fi.ReadString();
                ms = fi.ReadInt32();
                cs = fi.ReadInt32();
                fi.Close();
                lo.Close();
                FileStream lof = new FileStream("file.xml", FileMode.Open);
                BinaryReader fin = new BinaryReader(lof);
                MiniVan car1 = new MiniVan(nm,ms,cs);
                nm = fin.ReadString();
                ms = fin.ReadInt32();
                cs = fin.ReadInt32();
                SportsCar car2 = new SportsCar(nm, ms, cs);
                fin.Close();
                lof.Close();
                car1.TurboBoost();
                Console.ReadLine();
                car2.TurboBoost();
                Console.ReadLine();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка: {e}");
            }
        }
    }
}
