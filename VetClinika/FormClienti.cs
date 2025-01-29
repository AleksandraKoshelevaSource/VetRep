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
    public partial class FormClienti : Form
    {
        string selectedHoz;
        public FormClienti()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedHoz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

        }

        private void UpdateGridHoz()
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
            ChangeGridHoz();
            connection1.Close();
        }

        private void UpdateGridGivot()
        {
            //MessageBox.Show("Update grid");
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL = "Select Id, nom_pasp, klichka,vid, data_rogd,komment from Givotnie";

            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView2.Refresh();
            dataGridView2.DataSource = tb;
            dataGridView2.Columns[0].HeaderText = "N";
            dataGridView2.Columns[0].Width = 20;
            dataGridView2.Columns[1].HeaderText = "N пасп";
            dataGridView2.Columns[1].Width = 80;
            dataGridView2.Columns[2].HeaderText = "Кличка";
            dataGridView2.Columns[2].Width = 90;
            dataGridView2.Columns[3].HeaderText = "Вид";
            dataGridView2.Columns[3].Width = 90;
            dataGridView2.Columns[4].HeaderText ="Дата рожд";
            dataGridView2.Columns[4].Width = 90;
            dataGridView2.Columns[5].HeaderText = "Комментарий";
            dataGridView2.Columns[5].Width = 110;

            connection1.Close();
        }
        private void FormClienti_Load(object sender, EventArgs e)
        {
            UpdateGridHoz();
            UpdateGridGivot();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormDobHoz fdh = new FormDobHoz();
            fdh.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string SQL_dob = "INSERT INTO Givotnie(nom_pasp,klichka, data_rogd, vid, komment, id_hoz) values (N'" + textBox4.Text
                + "', N'" + textBox3.Text
                + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd")
                + "', N'" + textBox5.Text
                + "', N'" + textBox6.Text 
                + "', " + selectedHoz + ")"; 
            MessageBox.Show(SQL_dob);

            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            SqlCommand command1 = new SqlCommand(SQL_dob, connection1);
            SqlDataReader dr = command1.ExecuteReader();
            dr.Close();
            connection1.Close();
            // MessageBox.Show("Данные сохранены");

            UpdateGridGivot();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            selectedHoz = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void ChangeGridHoz()
        {
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[1].HeaderText = "ФИО";
            dataGridView1.Columns[1].Width = 170;
            dataGridView1.Columns[2].HeaderText = "Телефон";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].HeaderText = "Эл.почта";
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].HeaderText = "Паспортные данные";
            dataGridView1.Columns[5].Width = 200;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string SQL_text = "SELECT * FROM Client WHERE fio LIKE N'%" + textBox1.Text + "%' AND telefon LIKE N'%" + textBox2.Text + "%'";
            //MessageBox.Show(SQL_text);
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL_text, con1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.Refresh();
            dataGridView1.DataSource = dt;

            ChangeGridHoz();
            con1.Close();
        }
    }
}
