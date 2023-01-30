using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class ProdottoElettronico : Prodotto
    {
        //attributi
        private string _codice;

        //proprierties
        public string Codice
        {
            get
            {
                return _codice;
            }
            private set
            {
                if (value != null)
                    _codice = value;
                else
                    throw new Exception("Inserire un codice valido");
            }
        }

        //costruttori
        public ProdottoElettronico(string codice, string id, string nome, string prod, float prezzo) : base(id, nome, prod, prezzo)
        {
            Codice = codice;
        }

        //metodi
        public double getSconto()
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                return this.Prezzo * 0.95;
            }
            else
            {
                return this.Prezzo;
            }
        }
    }
}
