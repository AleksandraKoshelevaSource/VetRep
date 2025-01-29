using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace VetClinika
{
    public partial class FormReitSotr : Form
    {
        public FormReitSotr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Titles.Clear();
            chart1.Series.RemoveAt(0);
            chart1.Palette = ChartColorPalette.SeaGreen;
            string diagTitle = "Рейтинг сотрудников";
            chart1.Titles.Add(diagTitle);

            Series s1 = new Series("Сотрудники");
            s1.Color = Color.OrangeRed;
            string SQL_text = "SELECT s.fio, count(ou.Id) as kol FROM Sotr s, OkazanieUslugi ou WHERE ou.id_sotr=s.Id " +
                " AND ou.data >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                "' AND ou.data <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                "' GROUP BY s.fio";
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlCommand com1 = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = com1.ExecuteReader();
            string fio = "";
            int kol = 0;
            while (dr.Read())
            {
                fio = Convert.ToString(dr["fio"]);
                kol = Convert.ToInt32(dr["kol"]);
                s1.Points.AddXY(fio, kol);
            }
            dr.Close();
            con1.Close();
            chart1.Series.Add(s1);

        }
    }
}
