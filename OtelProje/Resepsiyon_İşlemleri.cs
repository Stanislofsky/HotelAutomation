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
    public partial class Resepsiyon_İşlemleri : Form
    {
        public Resepsiyon_İşlemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;        
        private void Resepsiyon_İşlemleri_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;";
        }
        void baglan()
        {
            if (baglanti.State==ConnectionState.Closed)
            {
                baglanti.Open();
            }            
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
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message);
            }
        }
        void Temizle()
        {
            txtad.Clear();
            txtsoyad.Clear();
            txtcep.Clear();
            txtev.Clear();
            txtis.Clear();
            txtmail.Clear();
            txtadres.Clear();
            txtserino.Clear();
            txtcinsiyet.Clear();
            txtanaad.Clear();
            txtbabaad.Clear();
            txtdogumtarih.Clear();
            txtdogumyer.Clear();
            txtoda.Clear();
            txtad.Focus();
        }
        SqlCommand komut;
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "insert into Musteriler(m_ad,m_soyad,m_ceptel,m_evtel,m_istel,m_mail,m_adres,m_kserino,m_cinsiyet,m_anaadi,m_babaadi,m_dogumtarihi,m_dogumyeri,m_kayitlioda) values(@m_ad,@m_soyad,@m_ceptel,@m_evtel,@m_istel,@m_mail,@m_adres,@m_kserino,@m_cinsiyet,@m_anaadi,@m_babaadi,@m_dogumtarihi,@m_dogumyeri,@m_kayitlioda)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@m_ad", txtad.Text);
                komut.Parameters.AddWithValue("@m_soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@m_ceptel", txtcep.Text);
                komut.Parameters.AddWithValue("@m_evtel", txtev.Text);
                komut.Parameters.AddWithValue("@m_istel", txtis.Text);
                komut.Parameters.AddWithValue("@m_mail", txtmail.Text);
                komut.Parameters.AddWithValue("@m_adres", txtadres.Text);
                komut.Parameters.AddWithValue("@m_kserino", txtserino.Text);
                komut.Parameters.AddWithValue("@m_cinsiyet", txtcinsiyet.Text);
                komut.Parameters.AddWithValue("@m_anaadi", txtanaad.Text);
                komut.Parameters.AddWithValue("@m_babaadi", txtbabaad.Text);
                komut.Parameters.AddWithValue("@m_dogumtarihi", txtdogumtarih.Text);
                komut.Parameters.AddWithValue("@m_dogumyeri", txtdogumyer.Text);
                komut.Parameters.AddWithValue("@m_kayitlioda", txtoda.Text);
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarılı...");
                Temizle();
                VeriGetir();
            }
            catch (Exception hata)
            { MessageBox.Show("Hata oluştu" + hata.Message); }
        }
        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
        private void btnodagoster_Click(object sender, EventArgs e)
        {
            Odalar oda = new Odalar();
            oda.Show();
        }
        private void btnkayitsil_Click(object sender, EventArgs e)
        {
            try
            {
                komut = new SqlCommand();
                komut.CommandText = "delete from Musteriler Where m_kayitlioda=" + textBox1.Text;
                baglan();
                using (SqlConnection con = new SqlConnection("Server = mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = *******; Password = ******;"))
                {
                    komut.Connection = con;
                    con.Open();
                    if (komut.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Kayıt Silindi");
                    }
                    else
                    {
                        MessageBox.Show("Hata oluştu. Kayıt Silinemedi lütfen tekrar deneyin");
                    }
                    con.Close();
                }
                baglanti.Close();
                VeriGetir();
                Temizle();
            }
            catch (Exception hata) { MessageBox.Show("Beklenmedik bir hata oluştu" + hata.Message); }
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                komut = new SqlCommand();
                komut.Connection = baglanti;
                komut.CommandText = "Update Musteriler Set m_ad=@m_ad,m_soyad=@m_soyad,m_ceptel=@m_ceptel,m_evtel=@m_evtel,m_istel=@m_istel,m_mail=@m_mail,m_adres=@m_adres,m_kserino=@m_kserino,m_cinsiyet=@m_cinsiyet,m_anaadi=@m_anaadi,m_babaadi=@m_babaadi,m_dogumtarihi=@m_dogumtarihi,m_dogumyeri=@m_dogumyeri,m_kayitlioda=@m_kayitlioda where m_kserino=@m_kserino";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@m_ad", txtad.Text);
                komut.Parameters.AddWithValue("@m_soyad", txtsoyad.Text);
                komut.Parameters.AddWithValue("@m_ceptel", txtcep.Text);
                komut.Parameters.AddWithValue("@m_evtel", txtev.Text);
                komut.Parameters.AddWithValue("@m_istel", txtis.Text);
                komut.Parameters.AddWithValue("@m_mail", txtmail.Text);
                komut.Parameters.AddWithValue("@m_adres", txtadres.Text);
                komut.Parameters.AddWithValue("@m_kserino", txtserino.Text);
                komut.Parameters.AddWithValue("@m_cinsiyet", txtcinsiyet.Text);
                komut.Parameters.AddWithValue("@m_anaadi", txtanaad.Text);
                komut.Parameters.AddWithValue("@m_babaadi", txtbabaad.Text);
                komut.Parameters.AddWithValue("@m_dogumtarihi", txtdogumtarih.Text);
                komut.Parameters.AddWithValue("@m_dogumyeri", txtdogumyer.Text);
                komut.Parameters.AddWithValue("@m_kayitlioda", txtoda.Text);
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme Başarılı...");
                Temizle();
                VeriGetir();
            }
            catch (Exception hata) { MessageBox.Show(hata.Message); }
        }
        private void btnkayitgetir_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_musteriler = new DataTable("Musteriler");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select m_ad as Adı, m_soyad as Soyadı, m_ceptel as Telefon, m_mail as Mail, m_kayitlioda as Oda from Musteriler where m_kayitlioda=" + textBox1.Text, baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_musteriler);
                dataGridView1.DataSource = dt_musteriler.DefaultView;
                baglanti.Close();
            }
            catch (Exception hata) { MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message); }
        }
    }
}
