using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ćwiczenie___zdarzenia_i_taski
{
    

    public class Obliczenia
    {
        //public delegate void RozpoczecieObliczen();
        //public event RozpoczecieObliczen RozpoczecieObliczenEvent;

        public event Action RozpoczecieObliczenEvent;
        //Action<T>, Func<T,K>

        //public delegate void ProgresObliczen(ProgresEventArgs progresObliczen_EventArgs);
        //public event ProgresObliczen ProgresObliczenEvent;
        public event Action<ProgresEventArgs> ProgresObliczenEvent;

        //public delegate void ZakonczenieObliczen();
        //public event ZakonczenieObliczen ZakonczenieObliczenEvent;
        public event Action ZakonczenieObliczenEvent;

        //TODO: klasa ma definiować zdarzenia "rozpoczecieObliczen", "progresObliczen", "zakonczenieObliczen" ok
        //TODO: zdarzenie "progresObliczen" ma mieć atrybut "progresObliczen_EventArgs" który przechowuje aktualną wartość zmiennej 'wynik'


        public int Obliczaj()
        {
            int wynik = -1;
            RozpoczecieObliczenEvent();
            //TODO: wywołanie zdarzenia "rozpoczecieObliczen" bez atrybutów zdarzenia

            for (int i = 0; i <= 100; i++)
            {
                wynik++;
                Thread.Sleep(100);
                ProgresObliczenEvent(new ProgresEventArgs() { wynik=wynik});

                //TODO: wywołanie zdarzenia "progresObliczen" z atrybutem zdarzenia który zawierać ma aktualną wartość zmiennej 'wynik'
            }

            //TODO: wywołanie zdarzenia "zakonczenieObliczen" baz atrybutów zdarzenia
            ZakonczenieObliczenEvent(); 
            return wynik;
        }
    }
}
