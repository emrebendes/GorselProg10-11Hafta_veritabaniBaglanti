using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace veritabaniBaglanti
{
    public partial class ekle : Form
    {
        public ekle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.235.3\EBSQLSERVER;Initial Catalog=kutuphane;User ID=sa;Password=Nevu123"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into deneme " +
                    "(ad,soyad,tel,eposta) values " +
                    "(@ad,@soyad,@tel,@eposta)", con);
                cmd.Parameters.AddWithValue("@ad", Ad.Text);
                cmd.Parameters.AddWithValue("@soyad", Soyad.Text);
                cmd.Parameters.AddWithValue("@tel", Tel.Text);
                cmd.Parameters.AddWithValue("@Eposta", Eposta.Text);
                cmd.ExecuteNonQuery();
                this.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.235.3\EBSQLSERVER;Initial Catalog=kutuphane;User ID=sa;Password=Nevu123"))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from deneme",con);
                DataSet ds = new DataSet(); 
                adapter.Fill(ds);
                DataRow dr = ds.Tables[0].NewRow();
                dr["ad"]=Ad.Text;
                dr["soyad"]=Soyad.Text;
                dr[3]=Tel.Text;
                dr[4]=Eposta.Text;
                ds.Tables[0].Rows.Add(dr);
                adapter.InsertCommand = new SqlCommand("insert into deneme " +
                    "(ad,soyad,tel,eposta) values " +
                    "(@ad,@soyad,@tel,@eposta)", con);
                adapter.InsertCommand.Parameters.Add("@ad", SqlDbType.VarChar, 50, "ad");
                adapter.InsertCommand.Parameters.Add("@soyad", SqlDbType.VarChar, 50, "soyad");
                adapter.InsertCommand.Parameters.Add("@tel", SqlDbType.VarChar, 50, "tel");
                adapter.InsertCommand.Parameters.Add("@eposta", SqlDbType.VarChar, 50, "eposta");
                adapter.Update(ds);

            }
        }
    }
}
