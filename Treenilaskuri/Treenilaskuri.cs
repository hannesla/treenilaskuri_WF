using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace viikkotehtava2
{
    /**
     * Ohjelman ikkuna josta hallitaan komponenttien luomista ja näyttämistä. Tekee myös yhteenvedon treeneistä.
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class Treenilaskuri : Form
    {
        private List<ExcerciseFlowLayoutPanel> treenit = new List<ExcerciseFlowLayoutPanel>();

        /// <summary>
        /// Alustaa ikkunan lähtötilaan
        /// </summary>
        public Treenilaskuri()
        {
            InitializeComponent();
            AutoValidate = AutoValidate.Disable;

            LuoUusiTreeni();     
        }

        /// <summary>
        /// Luo uuden treenin ja liittää siihen kuuntelijan joka kutsuu metodia uudelleen, kun treeni kertoo olevansa valmis.
        /// Lisäksi kuunnellaan myös, mikäli treenejä poistetaan tai muutetaan.
        /// </summary>
        private void LuoUusiTreeni()
        {
            ExcerciseFlowLayoutPanel uusinTreeni = new ExcerciseFlowLayoutPanel();     

            uusinTreeni.excerciseValmis += new ExcerciseFlowLayoutPanel.TreeniValmis(LuoUusiTreeni);
            uusinTreeni.tiedotMuuttuivat += new ExcerciseFlowLayoutPanel.TiedotMuuttuivat(LaskeYhteenveto);
            uusinTreeni.treeniPoistettiin += PoistaTreeni;

            treenit.Add(uusinTreeni);
            flowLayoutPanelTreenit.Controls.Add(uusinTreeni);
        }

        /// <summary>
        /// Poistaa treenin treenit listasta
        /// </summary>
        /// <param name="treeni">treeni joka poistetaan</param>
        /// <param name="e">ei käytetä</param>
        private void PoistaTreeni(object treeni, EventArgs e)
        {
            ExcerciseFlowLayoutPanel eflp = (ExcerciseFlowLayoutPanel)treeni;
            treenit.Remove(eflp);
            LaskeYhteenveto();
        }

        /// <summary>
        /// Luo yhteenvedon kaikista treeneistä käymällä ne läpi
        /// </summary>
        private void LaskeYhteenveto()
        {
            double matkatYhteensa = 0;
            TimeSpan kestotYhteensa = new TimeSpan(0, 0, 0);

            foreach (ExcerciseFlowLayoutPanel treeni in treenit)
            {
                matkatYhteensa += treeni.matka;
                kestotYhteensa += treeni.aika;
            }

            labelMatkat.Text = "Kokonaismatka: " + matkatYhteensa;
            labelKestot.Text = "Kokonaisaika: " + kestotYhteensa;

            if (matkatYhteensa >= 0 && !"00:00:00".Equals(kestotYhteensa.ToString()))
            { 
                string kokonaisnopeus = string.Format("{0:0.0}", matkatYhteensa / kestotYhteensa.TotalHours);
                string kokonaisvauhti = string.Format("{0:0.0}", kestotYhteensa.TotalMinutes / matkatYhteensa);

                labelKokonaisvauhti.Text = "Kokonaisvauhti: " + kokonaisvauhti + " min/km";
                labelKokonaisnopeus.Text = "Kokonaisnopeus: " + kokonaisnopeus + " km/h";
            }
            else
            {
                labelKokonaisvauhti.Text = "Kokonaisvauhti: min/km";
                labelKokonaisnopeus.Text = "Kokonaisnopeus: km/h";
            }
        }
    }
}
