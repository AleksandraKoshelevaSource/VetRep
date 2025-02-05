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
    public partial class FormSotr : Form
    {

        string nmas;
        public FormSotr()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            //MessageBox.Show("Update grid");
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL = "Select * from Sotr";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].HeaderText = "Дата рожд.";
            dataGridView1.Columns[2].Width = 70;
            dataGridView1.Columns[3].HeaderText = "Должность";
            dataGridView1.Columns[3].Width = 150;
            dataGridView1.Columns[4].HeaderText = "Специализация";
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[5].HeaderText = "Проф.деят-ть с";
            dataGridView1.Columns[5].Width = 130;
            connection1.Close();
        }

        private void FormSotr_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            UpdateGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string SQL_dob = "INSERT INTO Sotr(fio,data_rozd, dolg, spec, data_npd) values (N'" + textBox1.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") 
                + "', N'" + textBox2.Text + "', N'" + textBox3.Text + "', '"+ dateTimePicker1.Value.ToString("yyyy-MM-dd") +"')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL_izm = "UPDATE Sotr set fio=N'" + textBox1.Text +
                            "', data_rozd='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                            "', dolg = N'" + textBox2.Text + 
                            "', spec = N'" + textBox3.Text +
                            "', data_npd = '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "' WHERE Id=" + nmas;

            //MessageBox.Show(SQL_izm);
            SqlCommand command1 = new SqlCommand(SQL_izm, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            connection1.Close();

            UpdateGrid();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1[1, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox2.Text = dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox3.Text = dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString());
            nmas = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Удаление
        }
    }
}
