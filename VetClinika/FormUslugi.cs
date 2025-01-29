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
    public partial class FormUslugi : Form
    {
        string nmas;
        public FormUslugi()
        {
            InitializeComponent();
        }

        private void FormUslugi_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            //MessageBox.Show("Update grid");
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL = "Select * from Uslugi";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "№ услуги";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[1].Width = 350;
            dataGridView1.Columns[2].HeaderText = "Стоимость";
            dataGridView1.Columns[2].Width = 100;
            connection1.Close();
        }

        private void FormUslugi_Activated(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
     
            string SQL_dob = "INSERT INTO Uslugi(naim,cena) values (N'" + textBox1.Text + "', " + textBox2.Text + ")";
            MessageBox.Show(SQL_dob);

            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            SqlCommand command1 = new SqlCommand(SQL_dob, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            dr.Close();
            connection1.Close();
            // MessageBox.Show("Данные сохранены");

            UpdateGrid();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            nmas = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
            
        }
        private string change_comma(string s)
        {
            int pos = s.IndexOf(",");
            if (pos > 0)
            {
                s = s.Substring(0, pos) + "." + s.Substring(pos + 1, 2);
            }
            return s;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE Uslugi set naim=N'" + textBox1.Text +
                            "', cena=" + change_comma(textBox2.Text) + " WHERE kod=" + nmas;

            //MessageBox.Show(SQL_izm);
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();

            UpdateGrid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
