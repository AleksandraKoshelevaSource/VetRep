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
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

namespace VetClinika
{
    public partial class FormReitUsl : Form
    {
        public FormReitUsl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Titles.Clear();
            chart1.Series.RemoveAt(0);
            chart1.Palette = ChartColorPalette.SeaGreen;
            string diagTitle = "Рейтинг услуг";
            chart1.Titles.Add(diagTitle);

            Series s1 = new Series("Услуги");
            s1.Color = Color.Bisque;
            string SQL_text = "SELECT u.naim, count(ou.Id) as kol FROM Uslugi u, OkazanieUslugi ou WHERE ou.id_usl=u.kod " +
                " AND ou.data >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                "' AND ou.data <= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd") +
                "' GROUP BY u.naim";
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlCommand com1 = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = com1.ExecuteReader();
            string naim = "";
            int kol = 0;
            while (dr.Read())
            {
                naim = Convert.ToString(dr["naim"]);
                kol = Convert.ToInt32(dr["kol"]);
                s1.Points.AddXY(naim, kol);
            }
            dr.Close();
            con1.Close();
            chart1.Series.Add(s1);
        }
    }
}
