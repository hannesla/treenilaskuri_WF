using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viikkotehtava2
{
    /**
     * Luokka luvun esittämisen annetulta väliltä varten
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class NumberTextBox : TextBox
    {
        public Tapahtui_TextChanged muutos;

        private double vmin = 0.0;
        private double vmax = 100.0;
        private double arvoValue = 0;
        private bool vvoiOllaNolla = true;

        private bool isValidatedValue = false;

        /// <summary>
        /// Palauttaa tiedon siitä, onko arvo validoitu
        /// </summary>
        public bool isValidated
        {
            get { return isValidatedValue; }
        }

        [Category("Sisältö"),
        Description("Voiko luku olla nolla"),
        DefaultValue(true),
        Browsable(true)]
        public bool voiOllaNolla
        {
            get { return vvoiOllaNolla; }
            set { vvoiOllaNolla = value; }
        }

        [Category("Sisältö"),
        Description("Laatikon sisältämä luku"),
        DefaultValue(0),
        Browsable(true)]
        public double arvo
        {
            get { return arvoValue; }
            set { if (value >= min && value <= max) arvoValue = value; }
        }

        [Category("Sisältö"),
        Description("Asettaa luvu alarajan"),
        DefaultValue(0),
        Browsable(true)]
        public double min
        {
            get { return vmin; }
            set { vmin = value; }
        }

        [Category("Sisältö"),
        Description("Asettaa luvu ylärajan"),
        DefaultValue(100),
        Browsable(true)]
        public double max
        {
            get { return vmax; }
            set { vmax = value; }
        }

        /// <summary>
        /// Konstruktori.
        /// </summary>
        public NumberTextBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Selvittää onko laatikon sisältämä arvo validi
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void NumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            string luku = Text.Replace(',', '.');

            try
            {
                if ("".Equals(luku)) arvo = 0;
                else if (double.Parse(luku) < min || double.Parse(luku) > max)
                {
                    errorProvider1.SetError(this, "Luvun pitää olla väliltä: " + min + "-" + max);
                    BackColor = Color.Red;
                    e.Cancel = true;
                }
                else if (!voiOllaNolla && (double.Parse(luku) == 0))
                { // käytin aiemman tason ratkaisussa
                    errorProvider1.SetError(this, "Nolla ei kelpaa tähän kenttään!");
                    BackColor = Color.Red;
                    e.Cancel = true;
                }
                else arvo = double.Parse(luku);
            }
            catch (FormatException)
            {
                errorProvider1.SetError(this, "Ei saa olla kirjaimia eikä muita ylimääräisiä merkkejä!");
                BackColor = Color.Red;
                e.Cancel = true;
            }
            finally
            {
                // jos validointi ei mene läpi, laatikon arvo merkitään ei-validiksi
                if (e.Cancel) isValidatedValue = false; 
            }
        }

        /// <summary>
        /// Suoritetaan jos arvo on tarkistuksen mukaan validi
        /// </summary>
        /// <param name="sender">ei käyteä</param>
        /// <param name="e">ei käytetä</param>
        private void NumberTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this, null);
            BackColor = Color.White;
            isValidatedValue = true;

            string luku = Text.Replace(',', '.');

            try
            {
                if (Text.Length < 1) arvo = 0;
                else arvo = double.Parse(luku);
            }
            catch (Exception)
            {
                // odottamaton poikkeus koska arvo on jo kertaalleen parsittu
                MessageBox.Show("Tapahtui odottamaton virhe!", "Kuntolaskuri", MessageBoxButtons.OK);
            }
        }

        public delegate void Tapahtui_TextChanged();

        /// <summary>
        /// Suoritetaan kun tekstiä muutetaan
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (muutos == null) return;
            if (isValidated)
            {
                try
                {
                    if ("".Equals(Text)) arvo = 0;
                    else if (double.Parse(Text) < min || double.Parse(Text) > max) arvo = 0;
                    else arvo = double.Parse(Text);
                }
                catch (FormatException)
                {
                    arvo = 0;
                    // Tilanne Ok, käyttäjä voi väliaikaisesti syöttää kenttään väriä arvoja ilman että ohjelma valittaa 
                    // validating ei kuitenkaan anna käyttäjän jättää laatikkoon vääränlaista arvoa           
                }
                catch (Exception)
                {
                    MessageBox.Show("Tapahtui odottamaton virhe!", "Kuntolaskuri", MessageBoxButtons.OK);
                }
            }

            muutos();
        }
    }
}
