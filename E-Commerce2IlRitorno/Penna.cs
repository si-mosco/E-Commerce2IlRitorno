using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class Penna: ProdottiCancelleria
    {
        //attributi
        private string _modalita;

        public string Modalita
        {
            get
            {
                return _modalita;
            }
            private set
            {
                if (value != null)
                    _modalita = value;
                else
                    throw new Exception("Inserire una grammatura valido");
            }
        }

        //costruttore
        public Penna(string modalita, string id, string nome, string prod, string descrizione, float prezzo) : base(id, nome, prod, descrizione, prezzo)
        {
            Modalita = modalita;
        }

        public override string ToString()
        {
            return base.ToString() + Modalita;
        }
    }
}
