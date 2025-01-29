using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VetClinika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void услугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUslugi fu = new FormUslugi();
            fu.ShowDialog();
        }

        private void сотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSotr fs = new FormSotr();
            fs.ShowDialog();
        }

        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClienti fc = new FormClienti();
            fc.ShowDialog();
        }

        private void данныеОрганизацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanOrg fdo = new FormDanOrg();
            fdo.ShowDialog();
        }

        private void оказаниеУслугиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOkUsl fou = new FormOkUsl();
            fou.ShowDialog();
        }

        private void рейтингСотрудниковЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReitSotr fr = new FormReitSotr();
            fr.ShowDialog();
         }

       

        private void услугиЖивотномуЗаПериодToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FormUslGiv fug = new FormUslGiv();
            fug.ShowDialog();
        }

        private void посещаемостьВетклиникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPosVet fpv = new FormPosVet();
            fpv.ShowDialog();
        }

        private void рейтингУслугЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReitUsl fru = new FormReitUsl();
            fru.ShowDialog();
        }

        private void занятостьСотрудникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormZanSotr fzs = new FormZanSotr();
            fzs.ShowDialog();
        }
    }
}
