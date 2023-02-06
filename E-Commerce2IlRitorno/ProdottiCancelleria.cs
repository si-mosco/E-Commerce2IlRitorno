using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public abstract class ProdottiCancelleria: Prodotto
    {
        //costruttori
        public ProdottiCancelleria(string id, string nome, string prod, string descrizione, float prezzo) : base(id, nome, prod, descrizione, prezzo)
        {
        }

        //metodi
        public override double getSconto()
        {
            var today = DateTime.Today;

            if (today.Day%2==0)
            {
                return this.Prezzo * 0.97;
            }
            else
            {
                return this.Prezzo;
            }
        }
    }
}
