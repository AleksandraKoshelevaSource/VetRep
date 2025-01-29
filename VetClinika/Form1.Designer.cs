namespace VetClinika
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.услугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.данныеОрганизацииToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оказаниеУслугиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингСотрудниковЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.посущаемостьВетклиникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рейтингУслугЗаПериодToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.занятостьСотрудникаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.клиентыToolStripMenuItem,
            this.справочникиToolStripMenuItem,
            this.сотToolStripMenuItem,
            this.оказаниеУслугиToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.услугиToolStripMenuItem,
            this.данныеОрганизацииToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // услугиToolStripMenuItem
            // 
            this.услугиToolStripMenuItem.Name = "услугиToolStripMenuItem";
            this.услугиToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.услугиToolStripMenuItem.Text = "Услуги";
            this.услугиToolStripMenuItem.Click += new System.EventHandler(this.услугиToolStripMenuItem_Click);
            // 
            // данныеОрганизацииToolStripMenuItem
            // 
            this.данныеОрганизацииToolStripMenuItem.Name = "данныеОрганизацииToolStripMenuItem";
            this.данныеОрганизацииToolStripMenuItem.Size = new System.Drawing.Size(235, 26);
            this.данныеОрганизацииToolStripMenuItem.Text = "Данные организации";
            this.данныеОрганизацииToolStripMenuItem.Click += new System.EventHandler(this.данныеОрганизацииToolStripMenuItem_Click);
            // 
            // сотToolStripMenuItem
            // 
            this.сотToolStripMenuItem.Name = "сотToolStripMenuItem";
            this.сотToolStripMenuItem.Size = new System.Drawing.Size(103, 24);
            this.сотToolStripMenuItem.Text = "Сотрудники";
            this.сотToolStripMenuItem.Click += new System.EventHandler(this.сотToolStripMenuItem_Click);
            // 
            // оказаниеУслугиToolStripMenuItem
            // 
            this.оказаниеУслугиToolStripMenuItem.Name = "оказаниеУслугиToolStripMenuItem";
            this.оказаниеУслугиToolStripMenuItem.Size = new System.Drawing.Size(136, 24);
            this.оказаниеУслугиToolStripMenuItem.Text = "Оказание услуги";
            this.оказаниеУслугиToolStripMenuItem.Click += new System.EventHandler(this.оказаниеУслугиToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.рейтингСотрудниковЗаПериодToolStripMenuItem,
            this.посущаемостьВетклиникиToolStripMenuItem,
            this.рейтингУслугЗаПериодToolStripMenuItem,
            this.занятостьСотрудникаToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // рейтингСотрудниковЗаПериодToolStripMenuItem
            // 
            this.рейтингСотрудниковЗаПериодToolStripMenuItem.Name = "рейтингСотрудниковЗаПериодToolStripMenuItem";
            this.рейтингСотрудниковЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.рейтингСотрудниковЗаПериодToolStripMenuItem.Text = "Рейтинг сотрудников за период";
            this.рейтингСотрудниковЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.рейтингСотрудниковЗаПериодToolStripMenuItem_Click);
            // 
            // посущаемостьВетклиникиToolStripMenuItem
            // 
            this.посущаемостьВетклиникиToolStripMenuItem.Name = "посущаемостьВетклиникиToolStripMenuItem";
            this.посущаемостьВетклиникиToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.посущаемостьВетклиникиToolStripMenuItem.Text = "Посещаемость ветклиники";
            this.посущаемостьВетклиникиToolStripMenuItem.Click += new System.EventHandler(this.посещаемостьВетклиникиToolStripMenuItem_Click);
            // 
            // рейтингУслугЗаПериодToolStripMenuItem
            // 
            this.рейтингУслугЗаПериодToolStripMenuItem.Name = "рейтингУслугЗаПериодToolStripMenuItem";
            this.рейтингУслугЗаПериодToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.рейтингУслугЗаПериодToolStripMenuItem.Text = "Рейтинг услуг за период";
            this.рейтингУслугЗаПериодToolStripMenuItem.Click += new System.EventHandler(this.рейтингУслугЗаПериодToolStripMenuItem_Click);
            // 
            // занятостьСотрудникаToolStripMenuItem
            // 
            this.занятостьСотрудникаToolStripMenuItem.Name = "занятостьСотрудникаToolStripMenuItem";
            this.занятостьСотрудникаToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.занятостьСотрудникаToolStripMenuItem.Text = "Занятость специалиста";
            this.занятостьСотрудникаToolStripMenuItem.Click += new System.EventHandler(this.занятостьСотрудникаToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 388);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Ветеринарная клиника";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem клиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem услугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem данныеОрганизацииToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оказаниеУслугиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейтингСотрудниковЗаПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem посущаемостьВетклиникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рейтингУслугЗаПериодToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem занятостьСотрудникаToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

