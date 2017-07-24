using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Data.SqlClient;

namespace OtelProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;";
        }
        public static string kullid;
        void temizlik()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {               
                baglanti.Open();               
                 SqlCommand komut =new SqlCommand("Select resepsiyon_no,resepsiyon_parola from Kullanicilar where resepsiyon_no='" + textBox1.Text + "'and resepsiyon_parola='" + textBox2.Text + "'",baglanti);
                kullid = textBox1.Text;
                SqlDataReader dr = komut.ExecuteReader();                
                if (dr.Read())
                {
                    İslemler islemsayfasi = new İslemler();                    
                    string tarih = DateTime.Now.ToString();
                    Registry.CurrentUser.OpenSubKey("Girisler", true).SetValue(tarih, textBox1.Text);
                    islemsayfasi.ShowDialog();
                    baglanti.Close();                   
                }
                else
                {
                    MessageBox.Show("Resepsiyon No veya Parola Hatalı!");
                }
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu" + hata.Message);
                temizlik();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="admin" && textBox2.Text=="123"))
            {
                MessageBox.Show("Admin girişi başarılı.Admin sayfasına yönlendiriliyorsunuz...");
                AdminIslemleri adminsayfa = new AdminIslemleri();
                adminsayfa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Admin parolası veya şifresi hatalı!");
            }
        }
    }
}
