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
    public partial class FormDobHoz : Form
    {
        string nmas;
        public FormDobHoz()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            //MessageBox.Show("Update grid");
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL = "Select * from Client";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[2].Width = 90;
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[3].Width = 160;
            dataGridView1.Columns[4].HeaderText = "Эл.адрес";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "Паспортные данные";
            dataGridView1.Columns[5].Width = 160;
            connection1.Close();
        }

        private void FormDobHoz_Load(object sender, EventArgs e)
        {
            UpdateGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE Client set fio=N'" + textBox1.Text +
                            "', telefon=N'" + textBox2.Text +
                            "', adres = N'" + textBox3.Text +
                            "', el_adres = N'" + textBox4.Text +
                            "', pasp = N'" + textBox5.Text +
                            "' WHERE Id=" + nmas;

           // MessageBox.Show(SQL_izm);
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();

            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string SQL_dob = "INSERT INTO Client(fio,telefon, adres, el_adres, pasp) values (N'" + textBox1.Text 
                + "', N'" + textBox2.Text
                + "', N'" + textBox3.Text 
                + "', N'" + textBox4.Text 
                + "', N'" + textBox5.Text + "')";
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
            textBox3.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox4.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox5.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            //textBox2.Text = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            nmas = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            button1.Enabled = true;
            button2.Enabled = false;
        }
    }
}
