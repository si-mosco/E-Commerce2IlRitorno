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
        private List<Prodotto> lista = new List<Prodotto>();

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
                    p[i] = lista[i];
                }
                return p;
            }
            set
            {
                for (int i = 0; i < currentLenght; i++)
                {
                    lista[i] = value[i];
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
            for (int i = 0; i < c.lista.Count; i++)
            {
                if (c.lista[i] != null)
                {
                    lista[i] = c.lista[i].Clone();
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
            for (int i = 0; i < lista.Count; i++)
                lista[i] = null;
        }
        public void Aggiungi(Prodotto p)
        {
            if (currentLenght == MAXCARR)
            {
                throw new Exception("Impossibile aggiungere, dimensione massima carrello raggiunta");
            }

            if (p.GetType()==typeof(ProdottoAlimentare))
            {
                try
                {
                    ProdottoAlimentare r = (ProdottoAlimentare)p;

                    if (r.Data > DateTime.Today)
                    {
                        lista[currentLenght] = p;
                        ++currentLenght;
                    }
                }
                catch
                {
                    throw new Exception("Errore impossibile");
                }                
            } 
            else if (p.GetType() == typeof(ProdottoElettronico))
            {
                try
                {
                    ProdottoElettronico r = (ProdottoElettronico)p;

                    lista[currentLenght] = p;
                    ++currentLenght;
                }
                catch
                {
                    throw new Exception("Errore impossibile");
                }
            }
            else if (p.GetType() == typeof(Penna))
            {
                try
                {
                    Penna r = (Penna)p;

                    lista[currentLenght] = p;
                    ++currentLenght;
                }
                catch
                {
                    throw new Exception("Errore impossibile");
                }
            }
            else if (p.GetType() == typeof(FogliCarta))
            {
                try
                {
                    FogliCarta r = (FogliCarta)p;

                    lista[currentLenght] = p;
                    ++currentLenght;
                }
                catch
                {
                    throw new Exception("Errore impossibile");
                }
            }
            else if (p != null)
            {
                lista[currentLenght] = p;
                ++currentLenght;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }

        private int GetNumProdotti()
        {
            if (currentLenght != lista.Count)
                return currentLenght;
            else
                throw new Exception("Il carrello è pieno");
        }

        public int Esiste(Prodotto q)
        {
            for (int i = 0; i < currentLenght; i++)
            {
                if (lista[i].Equals(q))
                    return i;
            }
            return -1;
        }

        public Prodotto Rimuovi(Prodotto p)
        {
            if (Esiste(p) != -1)
            {
                for (int i = Esiste(p); i < lista.Count - 1; i++)
                    lista[i] = lista[i + 1];

                lista[lista.Count - 1] = null;

                --currentLenght;

                return p;
            }
            else
                throw new Exception("Inserire un prodotto valido");
        }
    }
}
