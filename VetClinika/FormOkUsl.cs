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
using Excel = Microsoft.Office.Interop.Excel;

namespace VetClinika
{
    public partial class FormOkUsl : Form
    {

        private Excel.Application excel_app;
        string dk_naim, dk_inn, dk_kpp, dk_rs;
        string dk_bik, dk_adres, dk_telef;

        string rz_fio, rz_pasp, rz_adres, rz_tel;

        string id_okaz_usl;

        public FormOkUsl()
        {
            InitializeComponent();
        }

        private void UpdateGrid()
        {
            //MessageBox.Show("Update grid");
            SqlConnection connection1 = new SqlConnection(Data.Glob_connection_string);
            connection1.Open();

            string SQL = "Select ou.Id, ou.data, g.id, g.nom_pasp, g.klichka, g.vid,"
                + " s.Id, s.fio, u.kod, u.naim, ou.komment"
                + " from OkazanieUslugi as ou, Givotnie as g, Sotr as s, Uslugi as u"
                + " WHERE ou.id_givot = g.Id AND ou.id_sotr = s.Id AND ou.id_usl = u.kod";
            //MessageBox.Show(SQL);
            SqlDataAdapter adapter = new SqlDataAdapter(SQL, connection1);
            DataTable tb = new DataTable();
            adapter.Fill(tb);

            dataGridView1.Refresh();
            dataGridView1.DataSource = tb;
            dataGridView1.Columns[0].HeaderText = "N";
            dataGridView1.Columns[0].Width = 20;
            dataGridView1.Columns[1].HeaderText = "Дата";
            dataGridView1.Columns[1].Width = 70;

            dataGridView1.Columns[2].HeaderText = "Id";
            dataGridView1.Columns[2].Width = 0;
            dataGridView1.Columns[3].HeaderText = "Ном.пасп.";
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].HeaderText = "Кличка";
            dataGridView1.Columns[4].Width = 60;
            dataGridView1.Columns[5].HeaderText = "Вид";
            dataGridView1.Columns[5].Width = 60;
            dataGridView1.Columns[6].HeaderText = "Idсотр";
            dataGridView1.Columns[6].Width = 0;
            dataGridView1.Columns[7].HeaderText = "Сотрудник";
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.Columns[8].HeaderText = "Код_усл";
            dataGridView1.Columns[8].Width = 0;
            dataGridView1.Columns[9].HeaderText = "Услуга";
            dataGridView1.Columns[9].Width = 110;

            dataGridView1.Columns[10].HeaderText = "Комментарий";
            dataGridView1.Columns[10].Width = 90;

            connection1.Close();
        }

        private void ZapolnCombo()
        {
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            string SQL_text = "SELECT id, (g.nom_pasp + ': ' + g.klichka) as giv FROM Givotnie as g";
            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL_text, con1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "giv";
            comboBox1.ValueMember = "id";
            con1.Close();

            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SQL_text = "SELECT kod, naim FROM Uslugi";
            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            da = new SqlDataAdapter(SQL_text, con1);
            dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "naim";
            comboBox2.ValueMember = "kod";
            con1.Close();

            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SQL_text = "SELECT Id, fio FROM Sotr";
            con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();
            da = new SqlDataAdapter(SQL_text, con1);
            dt = new DataTable();
            da.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "fio";
            comboBox3.ValueMember = "Id";
            con1.Close();

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id_okaz_usl = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1[1, dataGridView1.CurrentRow.Index].Value);
            comboBox1.SelectedValue = dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString();
            comboBox2.SelectedValue = dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString();
            comboBox3.SelectedValue = dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString();
            textBox1.Text = dataGridView1[10, dataGridView1.CurrentRow.Index].Value.ToString();
        }

        private void SelectDannie()
        {
            string SQL_text = "SELECT * FROM DannieComp";
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand com1 = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = com1.ExecuteReader();

            
            while (dr.Read())
            {
                //Заполнить переменные данными компании
                dk_naim = String.Format("{0}", dr["naim"]);
                dk_inn = String.Format("{0}", dr["inn"]);
                dk_kpp = String.Format("{0}", dr["kpp"]);
                dk_rs = String.Format("{0}", dr["ras_sch"]);
                dk_bik = String.Format("{0}", dr["bik"]);
                dk_adres = String.Format("{0}", dr["adres"]);
                dk_telef = String.Format("{0}", dr["telefon"]);

                
            }
            dr.Close();
            con1.Close();
           
        }

        private void FormOkUsl_Load(object sender, EventArgs e)
        {
            UpdateGrid();
            ZapolnCombo();
            SelectDannie();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string SQL_dob = "INSERT INTO OkazanieUslugi(data, id_givot, id_usl, id_sotr, komment) values ('"
                + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', "
                + comboBox1.ValueMember.ToString() + ", "
                + comboBox2.ValueMember.ToString() + ", "
                + comboBox3.ValueMember.ToString() + ", N'"
                + textBox1.Text + "')";
               
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

        private void RekvZak()
        {
            string SQL_text = "SELECT C.* FROM Client C, Givotnie G, OkazanieUslugi O  WHERE "
                + "O.Id = " + id_okaz_usl
                + " AND O.id_givot = G.ID AND G.id_hoz = C.Id";
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand com1 = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = com1.ExecuteReader();


            while (dr.Read())
            {
                //Заполнить переменные данными компании
                rz_fio = String.Format("{0}", dr["fio"]);
                rz_pasp = String.Format("{0}", dr["pasp"]);
                rz_adres = String.Format("{0}", dr["adres"]);
                rz_tel = String.Format("{0}", dr["telefon"]);
            }
            dr.Close();
            con1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RekvZak();
            excel_app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            excel_app.Workbooks.Add(Type.Missing);

            Excel.Range _excelCells = (Excel.Range)excel_app.get_Range("A1", "H1").Cells;
            _excelCells.Merge(Type.Missing);

            excel_app.Cells[1, 1].Value = "8. ЮРИДИЧЕСКИЕ АДРЕСА И БАНКОВСКИЕ РЕКВИЗИТЫ СТОРОН";
            excel_app.Cells[1, 1].Font.Bold = true;
            excel_app.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            _excelCells = (Excel.Range)excel_app.get_Range("A3", "D3").Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[3, 1].Value = "Исполнитель:";
            excel_app.Cells[3, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            _excelCells = (Excel.Range)excel_app.get_Range("E3", "H3").Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[3, 5].Value = "Заказчик:";
            excel_app.Cells[3, 5].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            
            for (int i = 5; i <= 12; i++)
            {
               
                _excelCells = (Excel.Range)excel_app.get_Range("A"+i, "D"+i).Cells;
                _excelCells.Merge(Type.Missing);
            }

            _excelCells = (Excel.Range)excel_app.get_Range("E5", "H5").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("E9", "H9").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("E10", "H10").Cells;
            _excelCells.Merge(Type.Missing);


            excel_app.Cells[5, 1].Value = "Наименование: " + dk_naim;
            excel_app.Cells[6, 1].Value = "Адрес: " + dk_adres;
            excel_app.Cells[7, 1].Value = "ИНН: " + dk_inn;
            excel_app.Cells[8, 1].Value = "КПП: " + dk_kpp;
            excel_app.Cells[9, 1].Value = "Р.сч.: " + dk_rs;
            excel_app.Cells[10, 1].Value = "БИК: " + dk_telef;
            excel_app.Cells[11, 1].Value = "Телефон: " + dk_telef;
            excel_app.Cells[12, 1].Value = "Контактное лицо:____________ ";

            _excelCells = (Excel.Range)excel_app.get_Range("E6", "H8").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells.WrapText = true;

            excel_app.Cells[5, 5].Value = "ФИО: " + rz_fio;
            excel_app.Cells[6, 5].Value = "Паспортные данные: " + rz_pasp;
            excel_app.Cells[9, 5].Value = "Адрес: " + rz_adres;
            excel_app.Cells[10, 5].Value = "Телефон: " + rz_tel;

            _excelCells = (Excel.Range)excel_app.get_Range("A14", "D14").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("E14", "H14").Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[14, 1].Value = "________(______________)";
            excel_app.Cells[14, 5].Value = "________(______________)";
            excel_app.Cells[15, 1].Value = "подпись    расшифровка";
            excel_app.Cells[15, 5].Value = "подпись    расшифровка";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            excel_app = new Excel.Application
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            excel_app.Workbooks.Add(Type.Missing);

            Excel.Range _excelCells = (Excel.Range)excel_app.get_Range("A1", "F1").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A2", "F2").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A3", "F3").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A4", "F4").Cells;
            _excelCells.Merge(Type.Missing);
            _excelCells = (Excel.Range)excel_app.get_Range("A5", "F5").Cells;
            _excelCells.Merge(Type.Missing);

            excel_app.Cells[1, 1].Value = "Наименование: " + dk_naim ;
            excel_app.Cells[2, 1].Value = "Адрес: " + dk_adres;
            excel_app.Cells[3, 1].Value = "ИНН: " + dk_inn;
            excel_app.Cells[4, 1].Value = "Р.сч.: " + dk_rs;
            excel_app.Cells[5, 1].Value = "Телефон: " + dk_telef;

            _excelCells = (Excel.Range)excel_app.get_Range("A7", "F7").Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[7, 1].Value = "Квитанция на оплату ветеринарных услуг";
            excel_app.Cells[7, 1].Font.Bold = true;
            excel_app.Cells[7, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            _excelCells = (Excel.Range)excel_app.get_Range("A8", "F8").Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[8, 1].Value = "Потребитель: " ;

            //таблица 
            excel_app.Cells[9, 1].Value = "Вид услуги";
            excel_app.Columns[1].columnwidth = 30;

            excel_app.Cells[9, 2].Value = "Количество";
            excel_app.Columns[2].columnwidth = 10;

            excel_app.Cells[9, 3].Value = "Ед.изм.";
            excel_app.Columns[3].columnwidth = 10;

            excel_app.Cells[9, 4].Value = "Цена";
            excel_app.Columns[4].columnwidth = 12;

            excel_app.Cells[9, 5].Value = "Стоимость";
            excel_app.Columns[5].columnwidth = 12;


            int i;
            for (i = 1; i <= 5; i++)
            {
                excel_app.Cells[9, i].Font.Size = 11;
                excel_app.Cells[9, i].Font.Bold = true;
                excel_app.Cells[9, i].Borders.LineStyle = 1;
                excel_app.Cells[9, i].Borders.Weight = Excel.XlBorderWeight.xlThick;
            }

            string SQL_text = "SELECT O.id, O.data, U.naim, U.cena " +
                "FROM OkazanieUslugi O, USLUGI U  WHERE " +
                "O.id_usl = U.kod AND O.Id = " + id_okaz_usl;
            //MessageBox.Show(SQL_text);
            SqlConnection con1 = new SqlConnection(Data.Glob_connection_string);
            con1.Open();

            SqlCommand comm = new SqlCommand(SQL_text, con1);
            SqlDataReader dr = comm.ExecuteReader();
            i = 10;
            decimal itog_summa = 0;
            string myData = "";
            while (dr.Read())
            {
                //excel_app.Cells[i, 1].Value = i - 9;
                excel_app.Cells[i, 1].Value = String.Format("{0}", dr["naim"]);
                excel_app.Cells[i, 2].Value = String.Format("{0}", "1");
                excel_app.Cells[i, 3].Value = String.Format("{0}", "шт.");
                excel_app.Cells[i, 4].Value = String.Format("{0}", dr["cena"]);
                excel_app.Cells[i, 5].Value = String.Format("{0}", dr["cena"]);

                myData = String.Format("{0}", dr["data"]);

                Excel.Range curr_cells = (Excel.Range)excel_app.get_Range("A" + i, "E" + i).Cells;
                curr_cells.Font.Size = 11;
                curr_cells.Borders.LineStyle = 1;

                itog_summa = itog_summa + Convert.ToDecimal(dr["cena"]);
                i = i + 1;
            }
           
            excel_app.Cells[i, 4].Value = "ИТОГО";
            excel_app.Cells[i, 4].Font.Size = 11;
            excel_app.Cells[i, 4].Borders.LineStyle = 1;
            excel_app.Cells[i, 5].Value = itog_summa;
            excel_app.Cells[i, 5].Font.Size = 11;
            excel_app.Cells[i, 5].Borders.LineStyle = 1;

            i += 1;
            _excelCells = (Excel.Range)excel_app.get_Range("A" + i, "F" + i).Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[i, 1].Value = "Итого оплачено потребителем: ";

            i += 1;
            _excelCells = (Excel.Range)excel_app.get_Range("A" + i, "F" + i).Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[i, 1].Value = "наличными д.с.: ";

            i += 1;
            _excelCells = (Excel.Range)excel_app.get_Range("A" + i, "F" + i).Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[i, 1].Value = "с использованием платежных карт: ";

            i += 1;
            _excelCells = (Excel.Range)excel_app.get_Range("A" + i, "F" + i).Cells;
            _excelCells.Merge(Type.Missing);
            excel_app.Cells[i, 1].Value = "Потребитель: ____________  _______________ " + myData;

            dr.Close();
            con1.Close();
        }
    }
}
