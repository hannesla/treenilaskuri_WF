using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace viikkotehtava2
{
    /**
     * Luokkaa käytetään aika-arvojen syöttämiseen
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class TimeTextBox : TextBox
    {
        public Tapahtui_TextChanged muutos;
        private TimeSpan aikaValue = new TimeSpan(0, 0, 0);

        private bool isValidatedValue = false;

        /// <summary>
        /// Palautaa ajan arvon
        /// </summary>
        public TimeSpan aika
        {
            get { return aikaValue; }
        }

        /// <summary>
        /// Ajan asettaminen ja saanti minuutteina
        /// </summary>
        public double aikaMinuutteina
        {
            get { return aikaValue.TotalMinutes; }
            set { aikaValue = new TimeSpan(0, Convert.ToInt16(value), 0); }
        }

        /// <summary>
        /// ajan asettaminen ja saanti tunteina
        /// </summary>
        public double aikaTunteina
        {
            get { return aikaValue.TotalHours; }
            set { aikaValue = new TimeSpan(Convert.ToInt16(value), 0, 0); }
        }

        /// <summary>
        /// palauttaa tiedon, onko ajan oikea muoto varmistettu
        /// </summary>
        public bool isValidated
        {
            get { return isValidatedValue; }
        }

        private TimeSpan max = new TimeSpan(23, 59, 59);

        /// <summary>
        /// Konstruktori.
        /// </summary>
        public TimeTextBox()
        {
            InitializeComponent();
            Text = aika.ToString();
        }

        /// <summary>
        /// Tarkistaa onko aika oikeassa muodossa
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void TimeTextBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TimeSpan ehdotettuAika = TimeSpan.Parse(Text);

                string[] osat = Text.Split(':');

                if (osat.Length != 3)
                {
                     errorProvider1.SetError(this, "ajan on oltava muotoa tt:mm:ss");
                    e.Cancel = true;
                } else if (ehdotettuAika > max) {
                    BackColor = Color.Red;
                    errorProvider1.SetError(this, "Aika on enintään 23:59:59");
                    e.Cancel = true;
                }


            }
            catch (System.OverflowException)
            {
                BackColor = Color.Red;
                errorProvider1.SetError(this, "Aika on enintään 23:59:59");
                e.Cancel = true;
            }
            catch (FormatException)
            {

                    BackColor = Color.Red;
                    errorProvider1.SetError(this, "ajan on oltava muotoa tt:mm:ss");
                    e.Cancel = true;                
            }
            finally
            {
                if (e.Cancel) isValidatedValue = false;
            }
        }

        /// <summary>
        /// Suoritetaan kun ajan oikea muoto on varmistettu
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void TimeTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(this, null);
            BackColor = Color.White;
            isValidatedValue = true;

            try
            {
                aikaValue = TimeSpan.Parse(Text);
            }
            catch (FormatException)
            {
                BackColor = Color.Red;
                errorProvider1.SetError(this, "ajan on oltava muotoa tt:mm:ss");
            }
            catch (Exception)
            {
                // odottamaton poikkeus koska arvo on jo kertaalleen parsittu
                MessageBox.Show("Tapahtui odottamaton virhe!", "Kuntolaskuri", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Suoritetaan kun syötettä muuutetaan
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void TimeTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Text.Split(':').Length != 3) aikaValue = new TimeSpan(0, 0, 0);
                else aikaValue = TimeSpan.Parse(Text);
            }
            catch (FormatException)
            {
                aikaValue = new TimeSpan(0, 0, 0);
                // Tilanne Ok, käyttäjä voi väliaikaisesti syöttää kenttään vääriä arvoja ilman että ohjelma valittaa 
                // validating ei kuitenkaan anna käyttäjän jättää laatikkoon vääränlaista arvoa           
            }
            catch (System.OverflowException)
            {
                aikaValue = new TimeSpan(0, 0, 0);
                // Tilanne Ok, käyttäjä voi väliaikaisesti syöttää kenttään vääriä arvoja ilman että ohjelma valittaa 
                // validating ei kuitenkaan anna käyttäjän jättää laatikkoon vääränlaista arvoa  
            }
            catch (Exception)
            {
                MessageBox.Show("Tapahtui odottamaton virhe!", "Kuntolaskuri", MessageBoxButtons.OK);
            }

            if (muutos == null) return;
            muutos();
        }

        public delegate void Tapahtui_TextChanged();
    }
}
