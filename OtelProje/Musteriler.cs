using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtelProje
{
    public partial class Musteriler : Form
    {
        public Musteriler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        private void Musteriler_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;";
            VeriGetir();
        }
        void VeriGetir()
        {
            try
            {
                DataTable dt_musteriler = new DataTable("Musteriler");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select m_ad as Adı, m_soyad as Soyadı, m_ceptel as Telefon, m_mail as Mail, m_kayitlioda as Oda from Musteriler", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_musteriler);
                dataGridView1.DataSource = dt_musteriler.DefaultView;
                baglanti.Close();
            } catch (Exception hata) {MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message);}

        }
    }
}
