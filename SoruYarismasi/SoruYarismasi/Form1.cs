using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace SoruYarismasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string ConnectionString = "Server=LAPTOP-63TIC6E6\\SQLEXPRESS;Database=BilgiYarismasi; User Id=SoruYarismasi; Password=123; connection timeout=30;";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnectionString;
            conn.Open();
            MessageBox.Show("Bağlantı Açıldı.");

            SqlCommand command = new SqlCommand("select top 4 percent * from [Sorular] order by newid()", conn);
            SqlCommand command2 = new SqlCommand("select Ad from BilgiYarismasi.dbo.Yarismacilar where Ad ='"+textBox1.Text+"'",conn);
            SqlDataReader reader2 = command2.ExecuteReader();
            if(reader2.Read())
            { 
            }
             MessageBox.Show(reader2.GetValue(0).ToString());
            reader2.Close();
            SqlDataReader reader = command.ExecuteReader();
         


            string isim = textBox1.Text;
            
            if (isim != null)
            {

                List<string> Sorular=new List<string>();
                List<string> yanlıs1 = new List<string>();
                List<string> yanlıs2 = new List<string>();
                List<string> yanlıs3 = new List<string>();
                List<string> dogru = new List<string>();

                while (reader.Read())
                {
                    Sorular.Add(reader.GetValue(reader.GetOrdinal("soru")).ToString() + "\n");
                    yanlıs1.Add(reader.GetValue(reader.GetOrdinal("Yanlış1")).ToString() + "\n");
                    yanlıs2.Add(reader.GetValue(reader.GetOrdinal("Yanlış2")).ToString() + "\n");
                    yanlıs3.Add(reader.GetValue(reader.GetOrdinal("Yanlış3")).ToString() + "\n");
                    dogru.Add(reader.GetValue(reader.GetOrdinal("Doğru")).ToString() + "\n");



                }

                label1.Text = Sorular[0];
                button2.Text=yanlıs1[0];
                button3.Text = yanlıs2[0];
                button4.Text = yanlıs3[0];
                button5.Text = dogru[0];
            }

        }
    }
}
//string ConnectionString = "Server=LAPTOP-63TIC6E6\\SQLEXPRESS;Database=BilgiYarismasi; User Id=SoruYarismasi; Password=123; connection timeout=30;";
//SqlConnection conn = new SqlConnection();
//conn.ConnectionString = ConnectionString;
//conn.Open();
//MessageBox.Show("Bağlantı Açıldı.");

//SqlCommand command = new SqlCommand("select * from Sorular", conn);
//SqlDataReader reader = command.ExecuteReader();

//while (reader.Read())
//{

//}

//conn.Close();