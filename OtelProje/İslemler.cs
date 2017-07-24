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
using System.IO;
namespace OtelProje
{
    public partial class İslemler : Form
    {
        public İslemler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        private void İslemler_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;"; 
            SqlCommand komut = new SqlCommand("Select resepsiyon_resim from Kullanicilar where resepsiyon_no='" + Form1.kullid + "'", baglanti);
            Image UyeResim = null;
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            SqlDataReader okuyucu = komut.ExecuteReader();
            if (okuyucu.Read())
            {
                byte[] resim = (byte[])okuyucu[0];
                MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                ms.Write(resim, 0, resim.Length);
                UyeResim = Image.FromStream(ms, true);
                pictureBox1.Image = UyeResim;
            }
            okuyucu.Close();
            baglanti.Close();
        }
        private void btnkayit_Click(object sender, EventArgs e)
        {
            Resepsiyon_İşlemleri kayit = new Resepsiyon_İşlemleri();
            kayit.ShowDialog();
        }
        private void btndurum_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar();
            oda.ShowDialog();
        }
        private void btncik_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Oturum kapatılıyor. Tekrardan işlem yapmak için lütfen giriş yapın!");
            this.Close();            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Musteriler musteri = new Musteriler();
            musteri.ShowDialog();
        }       
    }
}
