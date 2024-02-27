using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; //нужно обязательно подключить!
namespace CarLibrary
{
    public class SportsCar : Car
    {
        public SportsCar() { } // конструктор по умолчанию
        public SportsCar(string name, int maxSp, int currSp) // конструктор с параметрами
        : base(name, maxSp, currSp) { }
        public override void TurboBoost() // переопределение метода TurboBoost() обязательно!
        {
            MessageBox.Show("Таранная скорость!", "Чем быстрее, тем лучше...");
        }
        public enum MusicMedia
        {
            musicCd, // 0
            musicTape, // 1
            musicRadio, // 2
            musicMp3 // 3
        }
        public void TurnOnRadio(bool musicOn, MusicMedia mm)
        {
            if (musicOn) MessageBox.Show(string.Format("Jamming {0}", mm));
            else MessageBox.Show("Quiet time...");
        }
    }
    public class MiniVan : Car
    {
        public MiniVan() { } // конструктор по умолчанию
        public MiniVan(string name, int maxSp, int currSp)
        : base(name, maxSp, currSp) { } // конструктор с параметрами
        public override void TurboBoost() // переопределение метода TurboBoost() обязательно!
        {
            // Минивэны имеют плохие возможности турбонаддува!
            egnState = EngineState.engineDead;
            MessageBox.Show("Упс!", " Ваш блок двигателя взорвался!");
        }
    }
}