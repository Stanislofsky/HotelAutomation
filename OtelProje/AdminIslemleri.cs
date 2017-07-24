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
using Microsoft.Win32;

namespace OtelProje
{
    public partial class AdminIslemleri : Form
    {
        public AdminIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        private void AdminIslemleri_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;";

        }
        void KullaniciGetir()
        {
            try
            {
                DataTable dt_kullanicilar = new DataTable("Kullanicilar");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select resepsiyon_no as 'Resepsiyon No', resepsiyon_parola as 'Resepsiyon Paralo' from Kullanicilar", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_kullanicilar);
                dataGridView1.DataSource = dt_kullanicilar.DefaultView;
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message);
            }
        }
        void OdaGetir()
        {
            try
            {
                DataTable dt_odalar = new DataTable("Odalar");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select oda_no as 'Oda No', oda_kapasite as Kapasite, oda_tur as Tür from Odalar where oda_no=" + txtodano.Text, baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_odalar);
                dataGridView2.DataSource = dt_odalar.DefaultView;
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message);
            }
        }
        void baglan()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }
        SqlCommand komut;
        private void btnpersonelara_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            komut.Connection = baglanti;
            try
            {
                DataTable dt_kullanicilar = new DataTable("Kullanicilar");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select resepsiyon_no as 'Resepsiyon No', resepsiyon_parola as 'Resepsiyon Parola', resepsiyon_resim from Kullanicilar where resepsiyon_no='" + txtrspno.Text + "'", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_kullanicilar);
                dataGridView1.DataSource = dt_kullanicilar.DefaultView;
                SqlCommand komut2 = new SqlCommand("Select resepsiyon_resim from Kullanicilar where resepsiyon_no='" + txtrspno.Text + "'", baglanti);
                Image UyeResim = null;
                SqlDataReader okuyucu = komut2.ExecuteReader();
                if (okuyucu.Read())
                {
                    byte[] resim = (byte[])okuyucu[0];
                    MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                    ms.Write(resim, 0, resim.Length);
                    UyeResim = Image.FromStream(ms, true);
                    pictureBox1.Image = UyeResim;
                }
                okuyucu.Close();
            }
            catch (Exception hata) { MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message); }}              
        private void btnresepsiyonsil_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            komut.CommandText = "delete from Kullanicilar Where resepsiyon_no=" + txtrspno.Text;
            baglan();
            using (SqlConnection con = new SqlConnection("Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;"))
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
            KullaniciGetir();
        }
        private void btnresepsiyonguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                komut.Connection = baglanti;
                komut.CommandText = "Update Kullanicilar Set resepsiyon_no=@resepsiyon_no,resepsiyon__parola=@resepsiyon_parola where resepsiyon_no=@resepsiyon_no";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@resepsiyon_no", txtrspno.Text);
                komut.Parameters.AddWithValue("@resepsiyon_parola", txtrspparola.Text);                
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Resepsiyon Başarıyla Güncellendi");
                OdaGetir();
                txtodano.Clear();
                txtodakapasite.Clear();
                txtodatur.Clear();
            }
            catch (Exception hata) { MessageBox.Show("Resepsiyon güncellenirken bir hata oluştu!" + hata.Message); }
        }
        private void btnpersonelekle_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] byteResim = null;
                FileInfo finfo = new FileInfo(resimYol);
                long sayac = finfo.Length;
                FileStream fstream = new FileStream(resimYol, FileMode.Open, FileAccess.Read);
                BinaryReader breader = new BinaryReader(fstream);
                byteResim = breader.ReadBytes((int)sayac);
                komut = new SqlCommand("ResimKaydet", baglanti);
                komut.CommandText = "insert into Kullanicilar(resepsiyon_no,resepsiyon_parola,resepsiyon_resim) Values(@resepsiyon_no,@resepsiyon_parola,@resepsiyon_resim)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@resepsiyon_no", txtrspno.Text);
                komut.Parameters.AddWithValue("@resepsiyon_parola", txtrspparola.Text);
                komut.Parameters.AddWithValue("@resepsiyon_resim", byteResim);
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Eklendi");
                KullaniciGetir();
                txtrspno.Clear();
                txtrspparola.Clear();
                pictureBox1.Image = null;
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi" + hata.Message);
            }
        }
        string resimYol;
        private void btnresimekle_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdialog = new OpenFileDialog();
            if (DialogResult.OK == fdialog.ShowDialog())
            {
                resimYol = fdialog.FileName;
                pictureBox1.Image = Image.FromFile(resimYol);
            }
        }
        private void btnodaekle_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            komut.Connection = baglanti;
            try
            {
                komut.CommandText = "insert into Odalar(oda_no,oda_kapasite,oda_tur) Values(@oda_no,@oda_kapasite,@oda_tur)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@oda_no", txtodano.Text);
                komut.Parameters.AddWithValue("@oda_kapasite", txtodakapasite.Text);
                komut.Parameters.AddWithValue("@oda_tur", txtodatur.Text);
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Kayıt Başarıyla Eklendi");
                OdaGetir();
                txtodano.Clear();
                txtodakapasite.Clear();
                txtodatur.Clear();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Kayıt Eklenemedi" + hata.Message);
            }
        }
        private void btnodagetir_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand();
            komut.Connection = baglanti;
            OdaGetir();
        }
        private void btnodaguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                komut.Connection = baglanti;
                komut.CommandText = "Update Odalar Set oda_no=@oda_no,oda_kapasite=@oda_kapasite,oda_tur=@oda_tur where oda_no=@oda_no";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@oda_no", txtodano.Text);
                komut.Parameters.AddWithValue("@oda_kapasite", txtodakapasite.Text);
                komut.Parameters.AddWithValue("@oda_tur", txtodatur.Text);
                baglan();
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Oda Başarıyla Güncellendi");
                OdaGetir();
                txtodano.Clear();
                txtodakapasite.Clear();
                txtodatur.Clear();
            }
            catch (Exception hata) { MessageBox.Show("Oda güncellenirken bir hata oluştu!" + hata.Message); }
        }
    }
}
