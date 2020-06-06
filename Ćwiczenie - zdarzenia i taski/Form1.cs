using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ćwiczenie___zdarzenia_i_taski
{
    //TODO: praca zespołowa - założyć repozytorium na github-ie https://github.com/GrzegorzZukowski/EventsAndTasks

    public partial class Form1 : Form
    {
        Obliczenia obliczenia;

        //public delegate int UstawProgressBar();
        //public event UstawProgressBar ustawProgressBar;

        Action<int> ustawProgressBar;
        public Form1()
        {
            InitializeComponent();
            ustawProgressBar += value => progressBar.Value = value;
        }
        

        private void ButtonOblicz_Click(object sender, EventArgs e)
        {
             obliczenia = new Obliczenia();
            //TODO: zaimplementować obsługę zdarzeń "rozpoczecieObliczen", "progresObliczen", "zakonczenieObliczen"
            //TODO: rozpoczecieObliczen ustawia progressBar na 0%
            //TODO: zakonczenieObliczen ustawia progressBar na 100%
            //TODO: progresObliczen ustawia progressBar na % taki jak wartość zmiennej wynik w atrybucie zdarzenia

            //obliczenia.RozpoczecieObliczenEvent += new Obliczenia.RozpoczecieObliczen(Rozpoczecie_Obliczen);
            //obliczenia.RozpoczecieObliczenEvent += Rozpoczecie_Obliczen;

            obliczenia.RozpoczecieObliczenEvent += Rozpoczecie_Obliczen;
            obliczenia.ZakonczenieObliczenEvent += Zakonczenie_Obliczen;
            obliczenia.ProgresObliczenEvent += Progres_Obliczen;

            //TODO: wykonać metodę Obliczaj() asynchronicznie (async - await) 
            //int wynik = obliczenia.Obliczaj();
            Task<int> wynik = ObliczajAsync();

            do { Application.DoEvents(); } while (!wynik.IsCompleted);
            MessageBox.Show($"wynik: {wynik.Result}");

        }

        async Task<int> ObliczajAsync() 
        {
            return await Task<int>.Run(obliczenia.Obliczaj);
        }

        void Rozpoczecie_Obliczen()
        {
            //progressBar.Value = 0;
            this.Invoke(ustawProgressBar, 0);
        }

        void Zakonczenie_Obliczen()
        {
            //progressBar.Value = 100;
            this.Invoke(ustawProgressBar, 100);
        }

        void Progres_Obliczen(ProgresEventArgs postep)
        {
            //progressBar.Value = postep.wynik;
            this.Invoke(ustawProgressBar, postep.wynik);
        }

    }
}
