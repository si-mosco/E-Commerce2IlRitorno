using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class FogliCarta: ProdottiCancelleria
    {
        //attributi
        private float _grammatura;

        public float Grammatura
        {
            get
            {
                return _grammatura;
            }
            private set
            {
                if (value > 0)
                    _grammatura = value;
                else
                    throw new Exception("Inserire una grammatura valido");
            }
        }

        //costruttore
        public FogliCarta(float grammatura, string id, string nome, string prod, string descrizione, float prezzo) : base(id, nome, prod, descrizione, prezzo)
        {
            Grammatura = grammatura;
        }

        public override string ToString()
        {
            return Id + ";" + Nome + ";" + Descrizione + ";" + Descrizione + ";" + Prezzo + ";" + Grammatura;
        }
    }
}
