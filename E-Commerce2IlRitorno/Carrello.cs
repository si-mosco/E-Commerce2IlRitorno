using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class Carrello
    {
        //attributi
        private const int MAXCARR = 999;
        private string _id;
        public int currentLenght;
        private Prodotto[] _prod = new Prodotto[MAXCARR];

        //set e get mediante properties

        public string Id
        {
            get
            {
                return _id;
            }
            private set
            {
                if (value != null)
                    _id = value;
                else
                    throw new Exception("Inserire un id corretto");
            }
        }

        public Prodotto[] Prodotti
        {
            get
            {
                Prodotto[] p = new Prodotto[currentLenght];
                for (int i = 0; i < currentLenght; i++)
                {
                    p[i] = _prod[i];
                }
                return p;
            }
            set
            {
                for (int i = 0; i < currentLenght; i++)
                {
                    _prod[i] = value[i];
                }
            }
        }

        //costruttori
        public Carrello(string id)
        {
            this.Id = id;
            Svuota();//inizializzo il vettore vuoto
        }

        //costruttore di copia per clone
        protected Carrello(Carrello c) : this(c.Id)
        {
            Id = c.Id;
            currentLenght = c.currentLenght;
            for (int i = 0; i < c._prod.Length; i++)
            {
                if (c._prod[i] != null)
                {
                    _prod[i] = c._prod[i].Clone();
                }
            }
        }

        public Carrello Clone()
        {
            return new Carrello(this);
        }

        //metodi specifici
        public void Svuota()
        {
            currentLenght = 0;
            for (int i = 0; i < _prod.Length; i++)
                _prod[i] = null;
        }
        public void Aggiungi(Prodotto p)
        {
            if (currentLenght == MAXCARR)
            {
                throw new Exception("Impossibile aggiungere, dimensione massima carrello raggiunta");
            }

            if (p != null)
            {
                _prod[currentLenght] = p;
                ++currentLenght;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        private int GetNumProdotti()
        {
            if (currentLenght != _prod.Length)
                return currentLenght;
            else
                throw new Exception("Il carrello è pieno");
        }

        public int Esiste(Prodotto q)
        {
            for (int i = 0; i < currentLenght; i++)
            {
                if (_prod[i].Equals(q))
                    return i;
            }
            return -1;
        }

        public Prodotto Rimuovi(Prodotto p)
        {
            if (Esiste(p) != -1)
            {
                for (int i = Esiste(p); i < _prod.Length - 1; i++)
                    _prod[i] = _prod[i + 1];

                _prod[_prod.Length - 1] = null;

                --currentLenght;

                return p;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }
    }
}
