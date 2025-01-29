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
    public partial class FormPosVet : Form
    {
        public FormPosVet()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Titles.Clear();
            chart1.Series.RemoveAt(0);
            chart1.Palette = ChartColorPalette.SeaGreen;
            string diagTitle = "Посещение ветклиники";
            chart1.Titles.Add(diagTitle);

            Series s1 = new Series("Месяц");
            s1.Color = Color.Aqua;
            string SQL_text = "SELECT count(Id) as kol, Month(data) as mon, count(data)  FROM OkazanieUslugi WHERE " +
                "  data >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                "' AND data <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                "' GROUP BY Month(data)";
                 
            //MessageBox.Show(SQL_text);
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlCommand com1 = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = com1.ExecuteReader();
            string mon = "";
            int kol = 0;
            while (dr.Read())
            {
                mon = Convert.ToString(dr["mon"]);
                kol = Convert.ToInt32(dr["kol"]);
                s1.Points.AddXY(mon, kol);
            }
            dr.Close();
            con1.Close();
            chart1.Series.Add(s1);
        }
    }
}
