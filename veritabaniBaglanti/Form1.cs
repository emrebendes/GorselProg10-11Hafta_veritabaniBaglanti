using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace veritabaniBaglanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=192.168.235.3\EBSQLSERVER;Initial Catalog=kutuphane;User ID=sa;Password=Nevu123"))
            {
                SqlCommand cmd = new SqlCommand("select * from deneme", con);
                
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr["ad"].ToString() + " " +
                           dr["soyad"].ToString() + " >>> " + dr["eposta"].ToString());
                    }
            }


                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OdbcConnection con = new OdbcConnection(@"Driver={SQL Server};Server=192.168.235.3\EBSQLSERVER;DataBase=kutuphane;Uid=sa;Pwd=Nevu123;");
            OdbcCommand cmd = new OdbcCommand("select * from deneme", con);
            try
            {
                con.Open();
                OdbcDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    listBox2.Items.Add(dr["ad"].ToString() + " " +
                       dr["soyad"].ToString() + " >>> " + dr["eposta"].ToString());
                }
                //MessageBox.Show("baðlantý baþarýlý !");

            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally { con.Close(); }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
            DbProviderFactory dbf = DbProviderFactories.GetFactory("System.Data.SqlClient");
            DbConnection con = dbf.CreateConnection();
            con.ConnectionString = @"Data Source=192.168.235.3\EBSQLSERVER;Initial Catalog=kutuphane;User ID=sa;Password=Nevu123";
            try
            {
                con.Open();
                DbCommand cmd = dbf.CreateCommand();
                cmd.CommandText = "select * from deneme";
                cmd.Connection = con;
                DbDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listBox3.Items.Add(dr["ad"].ToString() + " " +
                           dr["soyad"].ToString() + " >>> " + dr["eposta"].ToString());
                }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
            finally { con.Close(); }            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=192.168.235.3\EBSQLSERVER;Initial Catalog=kutuphane;User ID=sa;Password=Nevu123");

            SqlDataAdapter dataAdaptor = new SqlDataAdapter("select * from deneme", con);
            DataSet dataSet = new DataSet();
            dataAdaptor.Fill(dataSet);

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                listBox4.Items.Add(row[1].ToString()+" "+row[2].ToString()
                    + " >>> " + row["eposta"].ToString());

            }          
            


        }

        private void button5_Click(object sender, EventArgs e)
        {
           ekle veriekle = new ekle();
            veriekle.ShowDialog();  
        }
    }
}