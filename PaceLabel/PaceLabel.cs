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
     * Luokkaa käytetään vauhdin laskevien ja näyttävien instanssien tuottamiseen
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class PaceLabel : Label
    {
        public event Fast fast;
        public event Average average;
        public event Slow slow;

        private Color fastColorValue = Color.Red;
        private Color averageColorValue = Color.Yellow;
        private Color slowColorValue = Color.Green;

        private TimeSpan timeValue;
        private double distanceValue;

        private double fastMinValue = 4;
        private double slowMinValue = 6;

        /// <summary>
        /// Palauttaa ja vaihtaa värin jolla merkitään nopea vauhti
        /// </summary>
        public Color FastColor
        {
            get { return fastColorValue; }
            set { fastColorValue = value; }
        }

        /// <summary>
        /// Palauttaa ja vaihtaa värin jolla merkitään keskinkertainen vauhti
        /// </summary>
        public Color AverageColor
        {
            get { return averageColorValue; }
            set { averageColorValue = value; }
        }

        /// <summary>
        /// Palauttaa ja vaihtaa värin jolla merkitään hidas vauhti
        /// </summary>
        public Color SlowColor
        {
            get { return slowColorValue; }
            set { slowColorValue = value; }
        }

        /// <summary>
        /// Palauttaa ja asettaa aika arvon
        /// </summary>
        public TimeSpan time
        {
            get { return timeValue; }
            set { timeValue = value; }
        }
        
        /// <summary>
        /// Palauttaa ja asettaa matkan
        /// </summary>
        public double distance
        {
            get { return distanceValue; }
            set { distanceValue = value; }
        }

        [Category("Sisältö"),
        Description("Määrittelee alarajan rajan nopealle vauhdille"),
        DefaultValue(4),
        Browsable(true)]
        public double FastMin
        {
            get { return fastMinValue; }
            set { fastMinValue = value; }
        }

        [Category("Sisältö"),
        Description("Määrittelee alarajan hitaalle vauhdille"),
        DefaultValue(6),
        Browsable(true)]
        public double SlowMin
        {
            get { return slowMinValue; }
            set { slowMinValue = value; }
        }

        /// <summary>
        /// Konstruktori.
        /// </summary>
        public PaceLabel()
        {
            InitializeComponent();

            fast += new Fast(VaihdaVaria);
            average += new Average(VaihdaVaria);
            slow += new Slow(VaihdaVaria);
        }

        /// <summary>
        /// Vaihtaa komponentin taustaväriä tapahtuman ilmoittaman värin mukaan
        /// </summary>
        /// <param name="sender">ei käytetä</param>
        /// <param name="e">tapahtuma joka kertoo vaihdettavan värin</param>
        public void VaihdaVaria(object sender, VauhtiEventArgs e)
        {
            BackColor = e.vari;
        }

        /// <summary>
        /// Laskee ja näyttää min/km saamiensa parametrien perusteella
        /// </summary>
        /// <param name="km">kilometrit joiden mukaan lasketaan</param>
        /// <param name="minuutit">minuutit joiden mukaan lasketaan</param>
        /// <returns>min/h</returns>
        public double LaskeMinuuttiaPerKm(double km, double minuutit )
        {
            double minuuttiaPerKm;
            if (km != 0) minuuttiaPerKm = minuutit / km;
            else minuuttiaPerKm = 0;

            if (fast != null && slow != null && average != null)
            {
                if (FastMin > minuuttiaPerKm) fast(this, new VauhtiEventArgs(FastColor));
                else if (SlowMin <= minuuttiaPerKm) slow(this, new VauhtiEventArgs(SlowColor));
                else average(this, new VauhtiEventArgs(AverageColor));
            }

            Text = string.Format("{0:0.0}", minuuttiaPerKm) + " min/km";

            return minuuttiaPerKm;
        }
    }

    /// <summary>
    /// Tuottaa tapahtumia, jotka välittävät tiedon väristä
    /// </summary>
    public class VauhtiEventArgs : EventArgs
    {
        private Color vauhdinVari;

        /// <summary>
        /// värin asettaminen ja saanti
        /// </summary>
        public Color vari
        {
            get { return vauhdinVari; }
            set { vauhdinVari = value; }
        }

        /// <summary>
        /// Alustaa tapahtuman
        /// </summary>
        /// <param name="vauhdinVari">Väri joka tapahtumalle annetaan</param>
        public VauhtiEventArgs(Color vauhdinVari)
        {
            vari = vauhdinVari;
        }
    }

    public delegate void Fast(object sender, VauhtiEventArgs e);
    public delegate void Average(object sender, VauhtiEventArgs e);
    public delegate void Slow(object sender, VauhtiEventArgs e);
}
