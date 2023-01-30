using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class ProdottoAlimentare: Prodotto
    {
        private string[] _ingredienti = new string[10];
        private DateTime _data;

        public DateTime Data
        {
            get
            {
                return _data;
            }
            private set
            {
                try
                {
                    _data = value;
                }
                catch
                {
                    throw new Exception("Inserire una data corretto");
                }
            }
        }

        //metodi
        public double getSconto()
        {
            var today = DateTime.Today;
            var diff= today-Data;

            if (diff.Days > 7)
            {
                return this.Prezzo * 0.50;
            }
            else
            {
                return this.Prezzo;
            }
        }
    }
}
