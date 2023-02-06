using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce2IlRitorno
{
    public class Prodotto
    {
        //ATTRIBUTI
        private string _id, _nome, _produttore, _descrizione;
        private float _prezzo;

        //SET AND GET MEDIANTE PROPERTIES
        public float Prezzo
        {
            get
            {
                return _prezzo;
            }
            set
            {
                if (value > 0)
                    _prezzo = value;
                else
                    throw new Exception("Il prezzo deve essere positivo");
            }
        }

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
                    throw new Exception("Inserire un id valido");
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }
            private set
            {
                if (value != null)
                    _nome = value;
                else
                    throw new Exception("Inserire un nome valido");
            }
        }

        public string Produttore
        {
            get
            {
                return _produttore;
            }
            private set
            {
                if (value != null)
                    _produttore = value;
                else
                    throw new Exception("Inserire un produttore valido");
            }
        }

        public string Descrizione
        {
            get
            {
                return _descrizione;
            }
            private set
            {
                if (value != null)
                    _descrizione = value;
                else
                    throw new Exception("Inserire una descrizione valida");
            }
        }

        //COSTRUTTORI
        public Prodotto(string id, string nome, string prod, string descr, float prezzo)
        {
            Id = id;
            Nome = nome;
            Produttore = prod;
            Descrizione = descr;
            Prezzo = prezzo;
        }

        public Prodotto(string id, string nome, string prod, string descr) : this(id, nome, prod, descr, 10)
        {
        }

        public Prodotto(string id, string nome, string prod) : this(id, nome, prod, "N/A", 10)
        {
        }

        public Prodotto() : this("IDVUOTO", "N/A", "N/A", "N/A", 10)
        {
        }

        public Prodotto(string id, string nome, string prod, float prezzo) : this(id, nome, prod, "N/A", prezzo)
        {

        }

        //COSTRUTTORE DI COPIA (PROTETTO) PER CLONE
        protected Prodotto(Prodotto other) : this(other.Id, other.Nome, other.Produttore, other.Descrizione, other.Prezzo)
        {
        }

        //clone
        public Prodotto Clone()
        {
            return new Prodotto(this);
        }
        

        //Equals
        public bool Equals(Prodotto p)
        {
            if (p == null) return false;

            if (this == p) return true;

            return (this.Id == p.Id);
        }

        //ToString
        public virtual string ToString()
        {
            return Id + ";" + Nome + ";" + Descrizione + ";" + Prezzo;
        }

        public virtual double getSconto()
        {
            return this.Prezzo;
        }
    }
}
