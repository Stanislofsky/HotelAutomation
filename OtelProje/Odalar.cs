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

namespace OtelProje{
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }
        SqlConnection baglanti;
        
        private void Odalar_Load(object sender, EventArgs e)
        {            
            baglanti = new SqlConnection();
            baglanti.ConnectionString = "Server =mssql11.domainhizmetleri.com; Initial Catalog = alicanba_proje; Persist Security Info = False; User ID = ******; Password = ******;";
            VeriGetir();
        }
        void VeriGetir()
        {
            try
            {
                DataTable dt_odalar = new DataTable("Odalar");
                SqlDataAdapter adaptor = new SqlDataAdapter("Select oda_no as 'Oda No', oda_kapasite as Kapasite, oda_tur as Tür from Odalar", baglanti);
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                adaptor.Fill(dt_odalar);
                dataGridView1.DataSource = dt_odalar.DefaultView;
                baglanti.Close();
            } catch (Exception hata) {MessageBox.Show("Beklenmedik bir hata oluştu..." + hata.Message);}
        }
    }
}
