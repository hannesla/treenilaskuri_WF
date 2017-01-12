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
     * Luokkaa käytetään nopeuden näyttävien ja laskevien instanssien tuottamiseen
     * Graafisten käyttöliittymien ohjelmoinnin viikkotehtävä 2
     * @author Hannes Laukkanen
     * @version 23.6.2016
     */
    public partial class SpeedLabel: PaceLabel
    {
        public new event Fast fast;
        public new event Average average;
        public new event Slow slow;

        /// <summary>
        /// Konstruktori.
        /// </summary>
        public SpeedLabel()
        {
            InitializeComponent();

            FastMin = 15;
            SlowMin = 6;

            fast += VaihdaVaria;
            average += VaihdaVaria;
            slow += VaihdaVaria;  
        }

        /// <summary>
        /// Laskee saamiensa arvojen perusteella km/t nopeuden ja näyttää sen
        /// </summary>
        /// <param name="km">kilometrit joiden mukaan lasketaan</param>
        /// <param name="tunnit">tunnit joiden mukaan lasketaan</param>
        /// <returns></returns>
        public double LaskeKmPerTunti(double km, double tunnit)
        {
            double kilometriaTunnissa;
            if (tunnit != 0) kilometriaTunnissa = km / tunnit;
            else kilometriaTunnissa = 0;                     

            if (fast != null && slow != null && average != null)
            {
                if (FastMin < kilometriaTunnissa) fast(this, new VauhtiEventArgs(FastColor));
                else if (SlowMin >= kilometriaTunnissa) slow(this, new VauhtiEventArgs(SlowColor));
                else average(this, new VauhtiEventArgs(AverageColor));
            }

            Text = string.Format("{0:0.0}", kilometriaTunnissa) + " km/h";

            return kilometriaTunnissa;
        }

        public delegate void Fast(object sender, VauhtiEventArgs e);
        public delegate void Average(object sender, VauhtiEventArgs e);
        public delegate void Slow(object sender, VauhtiEventArgs e);
    }
}
