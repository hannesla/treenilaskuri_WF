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
     * Yhden treeni kokonaisuuden hallitseva luokka joka sisältää ajan ja matkan syötön sekä vauhdin ja nopeuden näyttämisen
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class ExcerciseFlowLayoutPanel : FlowLayoutPanel
    {
        private NumberTextBox matkaBox;
        private TimeTextBox aikaBox;
        private PaceLabel laskettuPaceLabel;
        private SpeedLabel laskettuSpeedLabel;
        private Button poistaButton;

        private static int treeniNro = 0;

        public TreeniValmis excerciseValmis;
        public TiedotMuuttuivat tiedotMuuttuivat;
        public event TreeniPoistettiin treeniPoistettiin;

        /// <summary>
        /// Palauttaa matkan tämänhetkisen arvon
        /// </summary>
        public double matka
        { 
            get { return matkaBox.arvo; }
        }

        /// <summary>
        /// palauttaa ajan tämänhetkisen arvon  
        /// </summary>
        public TimeSpan aika
        {
            get { return aikaBox.aika; }
        }

        /// <summary>
        /// alustaa tarvittavat komponentit.
        /// </summary>
        public ExcerciseFlowLayoutPanel()
        {
            InitializeComponent();

            // sisennys jotta errorProvider-pallukat näkyvät ja jää väliä Excercises olioiden välille
            Padding = new Padding(0, 15, 15, 0);

            AutoSize = true;
            BorderStyle = BorderStyle.FixedSingle;

            Label treeniNroLabel = new Label();
            treeniNroLabel.Text = "Treeni " + ++treeniNro;
            Controls.Add(treeniNroLabel);

            Label matkaLabel = new Label();
            matkaLabel.AutoSize = true;
            Controls.Add(matkaLabel);

            matkaBox = new NumberTextBox();
            matkaBox.max = 100; // tästä voidaan säätää harjoitukselle annettavaa maksimi matkaa
            matkaBox.min = 0; // tästä voidaan säätää harjoitukselle annettavaa minimi matkaa
            Controls.Add(matkaBox);

            matkaLabel.Text = "Matkan pituus (" + matkaBox.min + "-" + matkaBox.max + " km)";

            Label aikaLabel = new Label();
            aikaLabel.AutoSize = true;
            aikaLabel.Text = "Matkan kesto (tt:mm:ss): ";
            Controls.Add(aikaLabel);

            aikaBox = new TimeTextBox();
            Controls.Add(aikaBox);

            Label vauhtiLabel = new Label();
            vauhtiLabel.Text = "Vauhti: ";
            Controls.Add(vauhtiLabel);

            laskettuPaceLabel = new PaceLabel();
            laskettuPaceLabel.Text = "0 min/km";
            //asetataan rajat sille, mitkä luvut laukaisevat tapahtuman slow, avarge tai fast tapahtuman
            laskettuPaceLabel.FastMin = 4;
            laskettuPaceLabel.SlowMin = 6;
            Controls.Add(laskettuPaceLabel);

            Label nopeusLabel = new Label();
            nopeusLabel.Text = "Nopeus: ";
            Controls.Add(nopeusLabel);

            laskettuSpeedLabel = new SpeedLabel();
            laskettuSpeedLabel.Text = "0 km/h";
            //asetataan rajat sille, mitkä luvut laukaisevat tapahtuman slow, avarge tai fast tapahtuman
            laskettuSpeedLabel.SlowMin = 6;  
            laskettuSpeedLabel.FastMin = 15; 
            Controls.Add(laskettuSpeedLabel);

            // Kuuntelut
            matkaBox.muutos += new NumberTextBox.Tapahtui_TextChanged(TarkistaLuvut);
            aikaBox.muutos += new TimeTextBox.Tapahtui_TextChanged(TarkistaLuvut);
        }

        /// <summary>
        /// Tarkistaa lukujen validiuden ja aiheuttaa tapahtumat treenivalmis ja tiedotmuuttuivat tarpeen mukaan.
        /// </summary>
        public void TarkistaLuvut()
        {
            // Hakee pääikkunan jotta voidaan validioida
            Form paaikkuna = (Form)Parent.Parent.Parent;
            
            if ( paaikkuna.Validate()) // Validoi siis valittuna olevan Controllin
            {
                laskettuPaceLabel.LaskeMinuuttiaPerKm(matkaBox.arvo, aikaBox.aikaMinuutteina);
                laskettuSpeedLabel.LaskeKmPerTunti(matkaBox.arvo, aikaBox.aikaTunteina);

                if (excerciseValmis == null) return;
                if (matkaBox.isValidated && aikaBox.isValidated && poistaButton == null)
                {
                    poistaButton = new Button();
                    poistaButton.AutoSize = true;
                    poistaButton.Text = "Poista treeni nro " + treeniNro;
                    poistaButton.Click += PoistaButton_Click;
                    Controls.Add(poistaButton);
                         
                    excerciseValmis();
                }

                if (tiedotMuuttuivat == null) return;
                tiedotMuuttuivat();
            }                               
        }

        /// <summary>
        /// Painikkeen klikkaus poistaa kyseessä olevan treenin
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">ei käytetä</param>
        private void PoistaButton_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            if (treeniPoistettiin == null) return;
            treeniPoistettiin(this, new EventArgs());
        }

        public delegate void TreeniValmis();
        public delegate void TiedotMuuttuivat();
        public delegate void TreeniPoistettiin(object sender, EventArgs e);
    }
}
