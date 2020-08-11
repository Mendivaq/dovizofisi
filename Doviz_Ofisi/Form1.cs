using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Doviz_Ofisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugün = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugün);

            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolaralis.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lbldolarsatis.Text = dolarsatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lbleualis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lbleusatis.Text = eurosatis;

        }

        private void btndolaral_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolaralis.Text;
        }

        private void btndolarsat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lbldolarsatis.Text;
        }

        private void btneual_Click(object sender, EventArgs e)
        {
            txtKur.Text = lbleualis.Text;
        }

        private void btneusat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lbleusatis.Text;
        }

        private void btnsatisyap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtmiktar.Text);
            tutar = kur * miktar;
            txttutar.Text = tutar.ToString();

        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            txtKur.Text = txtKur.Text.Replace(".",",");
        }

        private void btnsatisyap2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtmiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            txttutar.Text = tutar.ToString();
            int kalan;
            kalan = (int)(miktar % kur);
            txtkalan.Text = kalan.ToString();
        }
    }
}
