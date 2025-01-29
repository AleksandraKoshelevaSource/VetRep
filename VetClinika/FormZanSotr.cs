using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace VetClinika
{
    public partial class FormZanSotr : Form
    {
        private Excel.Application excel_app;
        public FormZanSotr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //создать отчет в excell
            excel_app = new Excel.Application();
            excel_app.Visible = true;
            excel_app.SheetsInNewWorkbook = 1;
            excel_app.Workbooks.Add(Type.Missing);

            Excel.Range _excelCells = (Excel.Range)excel_app.get_Range("A1", "E1").Cells;
            _excelCells.Merge(Type.Missing);

            excel_app.Cells[1, 1].Value = "Занятость специалиста Иванов Петр Андреевич" + " за период с " 
                + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                " по " + dateTimePicker2.Value.ToString("yyyy-MM-dd");
            excel_app.Cells[1, 1].Font.Bold = true;
            excel_app.Cells[1, 1].Font.Size = 16;
            excel_app.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            excel_app.Cells[2, 1].Value = "№";
            excel_app.Columns[1].columnwidth = 6;

            excel_app.Cells[2, 2].Value = "Дата";
            excel_app.Columns[2].columnwidth = 20;

            excel_app.Cells[2, 3].Value = "Животное";
            excel_app.Columns[3].columnwidth = 30;

            excel_app.Cells[2, 4].Value = "Услуга";
            excel_app.Columns[4].columnwidth = 50;

            excel_app.Cells[2, 5].Value = "Комментарий";
            excel_app.Columns[5].columnwidth = 35;

            for (int i = 1; i <= 5; i++)
            {
                excel_app.Cells[2, i].Font.Size = 14;
                excel_app.Cells[2, i].Font.Italic = true;
                excel_app.Cells[2, i].Font.Bold = true;
                excel_app.Cells[2, i].Borders.LineStyle = 1;
                excel_app.Cells[2, i].Borders.Weight = Excel.XlBorderWeight.xlThick;
                excel_app.Cells.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            string SQL_text = "SELECT OkazanieUslugi.Id, OkazanieUslugi.data, Givotnie.nom_pasp + '/' + Givotnie.klichka as giv "
                +", Uslugi.naim, OkazanieUslugi.komment " +
                "FROM OkazanieUslugi, USLUGI, Givotnie " +
                "WHERE (OkazanieUslugi.id_usl = Uslugi.kod) AND " +
                " (OkazanieUslugi.id_givot = Givotnie.Id) AND" +
                " (OkazanieUslugi.id_sotr = " + comboBox1.SelectedValue.ToString() +
                " ) AND (OkazanieUslugi.data >= '" + dateTimePicker1.Value.ToString("yyyyMMdd")
                + "') AND (OkazanieUslugi.data <= '" + dateTimePicker2.Value.ToString("yyyyMMdd") + "')";
            //MessageBox.Show(SQL_text);
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand comm = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = comm.ExecuteReader();
            int j = 3;
            int itogo = 0;
            while (dr.Read())
            {
                excel_app.Cells[j, 1].Value = String.Format("{0}", j - 3);
                excel_app.Cells[j, 2].Value = String.Format("{0}", dr["data"]);
                excel_app.Cells[j, 3].Value = String.Format("{0}", dr["giv"]);
                excel_app.Cells[j, 4].Value = String.Format("{0}", dr["naim"]);
                excel_app.Cells[j, 5].Value = String.Format("{0}", dr["komment"]);

                Excel.Range curr_cells = (Excel.Range)excel_app.get_Range("A" + j, "E" + j).Cells;
                curr_cells.Font.Size = 12;
                curr_cells.Borders.LineStyle = 1;

                itogo = itogo + 1;
                j = j + 1;
            }

            dr.Close();
            con1.Close();
        }

        private void zagr_combo()
        {
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            string SQL_text = "SELECT id, fio FROM Sotr";
            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL_text, con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "fio";
            comboBox1.ValueMember = "id";
            con1.Close();
        }

        private void FormZanSotr_Load(object sender, EventArgs e)
        {
            zagr_combo();
        }
    }
}
