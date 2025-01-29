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

namespace VetClinika
{
    public partial class FormDanOrg : Form
    {
        public FormDanOrg()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zagruzit()
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_text = "Select * FROM DannieComp";

            SqlCommand command1 = new SqlCommand(SQL_text, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            
            while (dr.Read())
            {
                textBox1.Text = string.Format("{0}", dr["naim"]);
                textBox2.Text = string.Format("{0}", dr["inn"]);
                textBox3.Text = string.Format("{0}", dr["kpp"]);
                textBox4.Text = string.Format("{0}", dr["ras_sch"]);
                textBox5.Text = string.Format("{0}", dr["bik"]);
                textBox6.Text = string.Format("{0}", dr["adres"]);
                textBox7.Text = string.Format("{0}", dr["telefon"]);
            }

        }

        private void FormDanOrg_Load(object sender, EventArgs e)
        {
            zagruzit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE DannieComp set naim=N'" + textBox1.Text +
                            "', inn=" + (textBox2.Text) +
                            ", kpp=" + (textBox3.Text) +
                            ", ras_sch=" + (textBox4.Text) +
                            ", bik=" + (textBox5.Text) +
                            ", adres=N'" + (textBox6.Text) +
                            "', telefon=" + (textBox7.Text) 
                            + " WHERE id=0";

            //MessageBox.Show(SQL_izm);
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();

            
        }
    }
}
