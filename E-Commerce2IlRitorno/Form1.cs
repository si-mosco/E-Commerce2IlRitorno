using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Commerce2IlRitorno
{
    public partial class Form1 : Form
    {
        float prezzino = 0;
        double prezzinoscontino = 0;


        //int contRapid = 0;
        bool firsTime = true;
        List<Prodotto> lista = new List<Prodotto>();
        Carrello carrello = new Carrello("CARRELLO1");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (firsTime)//solo la prima volta che apro il programma
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                firsTime = false;

                listView1.Columns.Add("ID", 30);
                listView1.Columns.Add("NOME", 50);
                listView1.Columns.Add("PRODUTTORE", 50);
                listView1.Columns.Add("DESCRIZIONE", 100);
                listView1.Columns.Add("PREZZO", 30);
                listView1.Columns.Add("EXTRA", 100);

                label9.Visible = false;
                label10.Visible = false;
                textBox6.Visible = false;
                monthCalendar1.Visible = false;

                label7.Text = $"PREZZO: {prezzino}";
                label8.Text = $"PREZZO SCONTATO: {prezzinoscontino}";
            }

            StampaElementi(listView1, carrello);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox5.Text != String.Empty && comboBox1.Text != null && comboBox1.SelectedItem!=null)
            {
                try
                {
                    float.Parse(textBox5.Text);
                }
                catch
                {
                    throw new Exception("Inserire un float nel prezzo");
                }


                if (Convert.ToString(comboBox1.SelectedItem) == "Alimentare" && textBox6.Text!= String.Empty)
                {
                    string[] Ingredienti;
                    Ingredienti=textBox6.Text.Split(',');

                    DateTime data = monthCalendar1.SelectionRange.Start;

                    Prodotto p= new ProdottoAlimentare(Ingredienti, data, $"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text));
                    lista.Add(p); 

                    prezzino += p.Prezzo;
                    prezzinoscontino += p.getSconto();

                    carrello.Aggiungi(p);
                }

                if (Convert.ToString(comboBox1.SelectedItem) == "Elettronico" && textBox6.Text != String.Empty)
                {
                    string codice= textBox6.Text;

                    Prodotto p=new ProdottoElettronico(codice, $"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text));
                    lista.Add(p);

                    prezzino += p.Prezzo;
                    prezzinoscontino += p.getSconto();

                    carrello.Aggiungi(p);
                }

                if (Convert.ToString(comboBox1.SelectedItem) == "Cancelleria (Penna)" && textBox6.Text != String.Empty)
                {
                    string funz = textBox6.Text;

                    Prodotto p = new ProdottoElettronico(funz, $"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text));
                    lista.Add(p);

                    prezzino += p.Prezzo;
                    prezzinoscontino += p.getSconto();

                    carrello.Aggiungi(p);
                }

                if (Convert.ToString(comboBox1.SelectedItem) == "Cancelleria (Foglio di Carta)" && textBox6.Text != String.Empty)
                {
                    string gramm = textBox6.Text;

                    Prodotto p = new ProdottoElettronico(gramm, $"{textBox1.Text}", $"{textBox2.Text}", $"{textBox3.Text}", $"{textBox4.Text}", float.Parse(textBox5.Text));
                    lista.Add(p);

                    prezzino += p.Prezzo;
                    prezzinoscontino += p.getSconto();

                    carrello.Aggiungi(p);
                }

                label7.Text = $"PREZZO: {prezzino}";
                label8.Text = $"PREZZO SCONTATO: {prezzinoscontino}";
            }
            else
            {
                MessageBox.Show("Inserire prima i valori");
            }



            Form1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                for (int i = 0; i < listView1.SelectedItems.Count; i++)
                {
                    Prodotto p = CreaProdTemp(listView1.SelectedItems[i].SubItems[0].Text, listView1.SelectedItems[i].SubItems[1].Text, listView1.SelectedItems[i].SubItems[2].Text, listView1.SelectedItems[i].SubItems[3].Text, float.Parse(listView1.SelectedItems[i].SubItems[4].Text));
                    lista.Remove(p);
                    carrello.Rimuovi(p);
                }
                Form1_Load(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            carrello.Svuota();
            lista.Clear();
            Form1_Load(sender, e);
        }

        public Prodotto CreaProdTemp(string id, string nome, string prod, string descr, float prezz)
        {
            Prodotto p = new Prodotto(id, nome, prod, descr, prezz);
            return p;
        }

        public static void StampaElementi(ListView listino, Carrello carr)
        {
            listino.Items.Clear();

            for (int i=0; i<carr.currentLenght; i++)
            {
                string[] temp = carr.Prodotti[i].ToString().Split(';');
                ListViewItem item = new ListViewItem(temp);
                listino.Items.Add(item);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToString(comboBox1.SelectedItem) == "Alimentare")
            {
                label9.Visible = true;
                label9.Text = "INGREDIENTI (..., ..., etc.)";
                textBox6.Visible = true;

                label10.Visible = true;
                monthCalendar1.Visible = true;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Elettronico")
            {
                label9.Visible = true;
                label9.Text = "CODICE SPECIFICO";
                label10.Visible = false;
                monthCalendar1.Visible = false;

                textBox6.Visible = true;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Cancelleria (Penna)")
            {
                label9.Visible = true;
                label9.Text = "MODALITA' DI FUNZIONAMENTO";
                label10.Visible = false;
                monthCalendar1.Visible = false;

                textBox6.Visible = true;
            }
            if (Convert.ToString(comboBox1.SelectedItem) == "Cancelleria (Foglio di Carta)")
            {
                label9.Visible = true;
                label9.Text = "GRAMMATURA";
                label10.Visible = false;
                monthCalendar1.Visible = false;

                textBox6.Visible = true;
            }

        }
    }
}
