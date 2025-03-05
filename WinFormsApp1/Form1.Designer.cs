using System.Diagnostics.Eventing.Reader;

namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            dataGridView1 = new DataGridView();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            menuStrip1 = new MenuStrip();
            историяУстройствToolStripMenuItem = new ToolStripMenuItem();
            добавитьУстройствоToolStripMenuItem = new ToolStripMenuItem();
            инвентаризацияToolStripMenuItem = new ToolStripMenuItem();
            историяПользователейToolStripMenuItem = new ToolStripMenuItem();
            статистикаToolStripMenuItem = new ToolStripMenuItem();
            пользователиToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            label5 = new Label();
            panel4 = new Panel();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            button5 = new Button();
            dataGridView5 = new DataGridView();
            dataGridView4 = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            button13 = new Button();
            button12 = new Button();
            button8 = new Button();
            dataGridView2 = new DataGridView();
            button3 = new Button();
            label4 = new Label();
            panel3 = new Panel();
            textBox3 = new TextBox();
            button4 = new Button();
            dataGridView3 = new DataGridView();
            label3 = new Label();
            panel6 = new Panel();
            panel9 = new Panel();
            label22 = new Label();
            label21 = new Label();
            label12 = new Label();
            panel7 = new Panel();
            button6 = new Button();
            label16 = new Label();
            label15 = new Label();
            textBox4 = new TextBox();
            label14 = new Label();
            label13 = new Label();
            panel8 = new Panel();
            label28 = new Label();
            label27 = new Label();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            button7 = new Button();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            comboBox1 = new ComboBox();
            panel10 = new Panel();
            button11 = new Button();
            button10 = new Button();
            dataGridView7 = new DataGridView();
            panel11 = new Panel();
            textBox9 = new TextBox();
            label26 = new Label();
            label25 = new Label();
            button9 = new Button();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            label24 = new Label();
            label23 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView7).BeginInit();
            panel11.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllHeaders;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(14, 47);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(790, 307);
            dataGridView1.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatAppearance.BorderColor = Color.Black;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.White;
            button1.Location = new Point(14, 459);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(229, 61);
            button1.TabIndex = 3;
            button1.Text = "проверить таблицу";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 385);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Введите устройство";
            textBox1.Size = new Size(228, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 424);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Количество выводимых записей";
            textBox2.Size = new Size(228, 27);
            textBox2.TabIndex = 5;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.White;
            menuStrip1.Dock = DockStyle.Left;
            menuStrip1.GripStyle = ToolStripGripStyle.Visible;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { историяУстройствToolStripMenuItem, инвентаризацияToolStripMenuItem, историяПользователейToolStripMenuItem, статистикаToolStripMenuItem, пользователиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(3, 3, 0, 3);
            menuStrip1.Size = new Size(194, 593);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // историяУстройствToolStripMenuItem
            // 
            историяУстройствToolStripMenuItem.BackColor = Color.White;
            историяУстройствToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьУстройствоToolStripMenuItem });
            историяУстройствToolStripMenuItem.ForeColor = Color.Black;
            историяУстройствToolStripMenuItem.Name = "историяУстройствToolStripMenuItem";
            историяУстройствToolStripMenuItem.Size = new Size(187, 24);
            историяУстройствToolStripMenuItem.Text = "История устройств";
            историяУстройствToolStripMenuItem.Click += историяУстройствToolStripMenuItem_Click;
            // 
            // добавитьУстройствоToolStripMenuItem
            // 
            добавитьУстройствоToolStripMenuItem.Name = "добавитьУстройствоToolStripMenuItem";
            добавитьУстройствоToolStripMenuItem.Size = new Size(240, 26);
            добавитьУстройствоToolStripMenuItem.Text = "Добавить устройство";
            добавитьУстройствоToolStripMenuItem.Click += добавитьУстройствоToolStripMenuItem_Click;
            // 
            // инвентаризацияToolStripMenuItem
            // 
            инвентаризацияToolStripMenuItem.Name = "инвентаризацияToolStripMenuItem";
            инвентаризацияToolStripMenuItem.Size = new Size(187, 24);
            инвентаризацияToolStripMenuItem.Text = "Инвентаризация";
            инвентаризацияToolStripMenuItem.Click += инвентаризацияToolStripMenuItem_Click;
            // 
            // историяПользователейToolStripMenuItem
            // 
            историяПользователейToolStripMenuItem.Name = "историяПользователейToolStripMenuItem";
            историяПользователейToolStripMenuItem.Size = new Size(187, 24);
            историяПользователейToolStripMenuItem.Text = "История пользователей";
            историяПользователейToolStripMenuItem.Click += историяПользователейToolStripMenuItem_Click;
            // 
            // статистикаToolStripMenuItem
            // 
            статистикаToolStripMenuItem.Name = "статистикаToolStripMenuItem";
            статистикаToolStripMenuItem.Size = new Size(187, 24);
            статистикаToolStripMenuItem.Text = "Статистика";
            статистикаToolStripMenuItem.Click += статистикаToolStripMenuItem_Click;
            // 
            // пользователиToolStripMenuItem
            // 
            пользователиToolStripMenuItem.Name = "пользователиToolStripMenuItem";
            пользователиToolStripMenuItem.Size = new Size(187, 24);
            пользователиToolStripMenuItem.Text = "Пользователи";
            пользователиToolStripMenuItem.Click += пользователиToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 0, 0);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(194, 12);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(840, 539);
            panel1.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(14, 15);
            label5.Name = "label5";
            label5.Size = new Size(199, 28);
            label5.TabIndex = 6;
            label5.Text = "История устройств";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(192, 0, 0);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label10);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(button5);
            panel4.Controls.Add(dataGridView5);
            panel4.Controls.Add(dataGridView4);
            panel4.Controls.Add(label7);
            panel4.Controls.Add(label6);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(194, 16);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(840, 535);
            panel4.TabIndex = 9;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label11.ForeColor = Color.White;
            label11.Location = new Point(195, 91);
            label11.Name = "label11";
            label11.Size = new Size(24, 28);
            label11.TabIndex = 9;
            label11.Text = "0";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = Color.White;
            label10.Location = new Point(195, 53);
            label10.Name = "label10";
            label10.Size = new Size(24, 28);
            label10.TabIndex = 8;
            label10.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = Color.White;
            label9.Location = new Point(3, 91);
            label9.Name = "label9";
            label9.Size = new Size(183, 28);
            label9.TabIndex = 7;
            label9.Text = "Кол-во принятых";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.White;
            label8.Location = new Point(3, 53);
            label8.Name = "label8";
            label8.Size = new Size(177, 28);
            label8.TabIndex = 6;
            label8.Text = "Кол-во выданых";
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = Color.White;
            button5.Location = new Point(3, 140);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(202, 51);
            button5.TabIndex = 5;
            button5.Text = "Обновить данные";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // dataGridView5
            // 
            dataGridView5.AllowUserToAddRows = false;
            dataGridView5.AllowUserToDeleteRows = false;
            dataGridView5.BackgroundColor = Color.White;
            dataGridView5.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView5.Location = new Point(599, 25);
            dataGridView5.Margin = new Padding(3, 4, 3, 4);
            dataGridView5.Name = "dataGridView5";
            dataGridView5.ReadOnly = true;
            dataGridView5.RowHeadersWidth = 51;
            dataGridView5.RowTemplate.Height = 25;
            dataGridView5.Size = new Size(224, 417);
            dataGridView5.TabIndex = 4;
            // 
            // dataGridView4
            // 
            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.BackgroundColor = Color.White;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView4.Location = new Point(317, 25);
            dataGridView4.Margin = new Padding(3, 4, 3, 4);
            dataGridView4.Name = "dataGridView4";
            dataGridView4.ReadOnly = true;
            dataGridView4.RowHeadersWidth = 51;
            dataGridView4.RowTemplate.Height = 25;
            dataGridView4.Size = new Size(243, 417);
            dataGridView4.TabIndex = 3;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(611, 461);
            label7.Name = "label7";
            label7.Size = new Size(111, 28);
            label7.TabIndex = 2;
            label7.Text = "Принятые";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.White;
            label6.Location = new Point(325, 461);
            label6.Name = "label6";
            label6.Size = new Size(115, 28);
            label6.TabIndex = 1;
            label6.Text = "Выданные";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(3, 11);
            label2.Name = "label2";
            label2.Size = new Size(120, 28);
            label2.TabIndex = 0;
            label2.Text = "Статистика";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 0, 0);
            panel2.Controls.Add(button13);
            panel2.Controls.Add(button12);
            panel2.Controls.Add(button8);
            panel2.Controls.Add(dataGridView2);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(label4);
            panel2.Location = new Point(194, 12);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(840, 539);
            panel2.TabIndex = 6;
            // 
            // button13
            // 
            button13.BackColor = Color.Black;
            button13.FlatStyle = FlatStyle.Popup;
            button13.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button13.ForeColor = Color.White;
            button13.Location = new Point(14, 487);
            button13.Margin = new Padding(3, 4, 3, 4);
            button13.Name = "button13";
            button13.Size = new Size(311, 57);
            button13.TabIndex = 6;
            button13.Text = "Провести инвентаризацию";
            button13.UseVisualStyleBackColor = false;
            button13.Visible = false;
            button13.Click += button13_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.Black;
            button12.FlatStyle = FlatStyle.Popup;
            button12.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button12.ForeColor = Color.White;
            button12.Location = new Point(290, 415);
            button12.Margin = new Padding(3, 4, 3, 4);
            button12.Name = "button12";
            button12.Size = new Size(248, 84);
            button12.TabIndex = 5;
            button12.Text = "Состояние устройств";
            button12.UseVisualStyleBackColor = false;
            button12.Click += button12_Click;
            // 
            // button8
            // 
            button8.BackColor = Color.Black;
            button8.FlatStyle = FlatStyle.Popup;
            button8.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button8.ForeColor = Color.White;
            button8.Location = new Point(575, 415);
            button8.Margin = new Padding(3, 4, 3, 4);
            button8.Name = "button8";
            button8.Size = new Size(248, 84);
            button8.TabIndex = 4;
            button8.Text = "Элементы файла анализа";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView2.BackgroundColor = Color.White;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(14, 61);
            dataGridView2.Margin = new Padding(3, 4, 3, 4);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(823, 316);
            dataGridView2.TabIndex = 3;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.White;
            button3.Location = new Point(17, 415);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(186, 84);
            button3.TabIndex = 2;
            button3.Text = "Вывести данные";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(14, 29);
            label4.Name = "label4";
            label4.Size = new Size(421, 28);
            label4.TabIndex = 0;
            label4.Text = "Общая информация об инвентаризации ";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(192, 0, 0);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(button4);
            panel3.Controls.Add(dataGridView3);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(191, 12);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(843, 539);
            panel3.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox3.Location = new Point(17, 377);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Номер бейджика";
            textBox3.Size = new Size(228, 34);
            textBox3.TabIndex = 3;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = Color.White;
            button4.Location = new Point(17, 444);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(229, 48);
            button4.TabIndex = 2;
            button4.Text = "Вывести историю";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.BackgroundColor = Color.White;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(17, 61);
            dataGridView3.Margin = new Padding(3, 4, 3, 4);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(790, 283);
            dataGridView3.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(17, 19);
            label3.Name = "label3";
            label3.Size = new Size(233, 28);
            label3.TabIndex = 0;
            label3.Text = "история пользователя";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(192, 0, 0);
            panel6.Controls.Add(panel9);
            panel6.Controls.Add(panel8);
            panel6.Location = new Point(191, 12);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(843, 539);
            panel6.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Black;
            panel9.Controls.Add(label22);
            panel9.Controls.Add(label21);
            panel9.Controls.Add(label12);
            panel9.Controls.Add(panel7);
            panel9.Controls.Add(label16);
            panel9.Controls.Add(label15);
            panel9.Controls.Add(textBox4);
            panel9.Controls.Add(label14);
            panel9.Controls.Add(label13);
            panel9.Location = new Point(17, 57);
            panel9.Margin = new Padding(3, 4, 3, 4);
            panel9.Name = "panel9";
            panel9.Size = new Size(322, 389);
            panel9.TabIndex = 11;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label22.ForeColor = Color.White;
            label22.Location = new Point(142, 195);
            label22.Name = "label22";
            label22.Size = new Size(184, 28);
            label22.TabIndex = 9;
            label22.Text = "Выберите режим";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label21.ForeColor = Color.White;
            label21.Location = new Point(13, 153);
            label21.Name = "label21";
            label21.Size = new Size(85, 28);
            label21.TabIndex = 8;
            label21.Text = "Режим:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = Color.White;
            label12.Location = new Point(23, 23);
            label12.Name = "label12";
            label12.Size = new Size(285, 32);
            label12.TabIndex = 0;
            label12.Text = "Добавление устройств";
            // 
            // panel7
            // 
            panel7.Controls.Add(button6);
            panel7.Location = new Point(10, 87);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(205, 51);
            panel7.TabIndex = 2;
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(192, 0, 0);
            button6.FlatStyle = FlatStyle.Popup;
            button6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button6.ForeColor = Color.White;
            button6.Location = new Point(23, 0);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(119, 44);
            button6.TabIndex = 4;
            button6.Text = "Запустить";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label16.ForeColor = Color.White;
            label16.Location = new Point(10, 241);
            label16.Name = "label16";
            label16.Size = new Size(184, 28);
            label16.TabIndex = 7;
            label16.Text = "Входные данные:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label15.ForeColor = Color.White;
            label15.Location = new Point(98, 153);
            label15.Name = "label15";
            label15.Size = new Size(184, 28);
            label15.TabIndex = 6;
            label15.Text = "Выберите режим";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(23, 92);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(161, 27);
            textBox4.TabIndex = 1;
            textBox4.KeyUp += textBox4_KeyUp;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label14.ForeColor = Color.White;
            label14.Location = new Point(10, 195);
            label14.Name = "label14";
            label14.Size = new Size(135, 28);
            label14.TabIndex = 5;
            label14.Text = "Инструкция:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label13.ForeColor = Color.White;
            label13.Location = new Point(182, 245);
            label13.Name = "label13";
            label13.Size = new Size(21, 28);
            label13.TabIndex = 3;
            label13.Text = "*";
            // 
            // panel8
            // 
            panel8.BackColor = Color.Black;
            panel8.Controls.Add(label28);
            panel8.Controls.Add(label27);
            panel8.Controls.Add(textBox6);
            panel8.Controls.Add(textBox5);
            panel8.Controls.Add(button7);
            panel8.Controls.Add(label20);
            panel8.Controls.Add(label19);
            panel8.Controls.Add(label18);
            panel8.Controls.Add(label17);
            panel8.Controls.Add(comboBox1);
            panel8.Location = new Point(526, 57);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(281, 389);
            panel8.TabIndex = 10;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label28.ForeColor = Color.White;
            label28.Location = new Point(105, 345);
            label28.Name = "label28";
            label28.Size = new Size(18, 23);
            label28.TabIndex = 17;
            label28.Text = "*";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label27.ForeColor = Color.White;
            label27.Location = new Point(22, 341);
            label27.Name = "label27";
            label27.Size = new Size(79, 28);
            label27.TabIndex = 16;
            label27.Text = "Статус:";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox6.Location = new Point(173, 195);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(97, 34);
            textBox6.TabIndex = 15;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBox5.Location = new Point(173, 149);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(97, 34);
            textBox5.TabIndex = 14;
            // 
            // button7
            // 
            button7.BackColor = Color.FromArgb(192, 0, 0);
            button7.FlatStyle = FlatStyle.Popup;
            button7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button7.ForeColor = Color.White;
            button7.Location = new Point(71, 245);
            button7.Margin = new Padding(3, 4, 3, 4);
            button7.Name = "button7";
            button7.Size = new Size(121, 61);
            button7.TabIndex = 13;
            button7.Text = "Добавить";
            button7.UseVisualStyleBackColor = false;
            button7.Click += button7_Click;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label20.ForeColor = Color.White;
            label20.Location = new Point(3, 152);
            label20.Name = "label20";
            label20.Size = new Size(153, 25);
            label20.TabIndex = 12;
            label20.Text = "Номер бейджа";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label19.ForeColor = Color.White;
            label19.Location = new Point(3, 197);
            label19.Name = "label19";
            label19.Size = new Size(184, 25);
            label19.TabIndex = 11;
            label19.Text = "Номер устройства";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label18.ForeColor = Color.White;
            label18.Location = new Point(3, 76);
            label18.Name = "label18";
            label18.Size = new Size(76, 25);
            label18.TabIndex = 10;
            label18.Text = "Режим";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label17.ForeColor = Color.White;
            label17.Location = new Point(3, 7);
            label17.Name = "label17";
            label17.Size = new Size(248, 32);
            label17.TabIndex = 9;
            label17.Text = "Ручное добавление";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Выдача", "Прием" });
            comboBox1.Location = new Point(131, 73);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(138, 36);
            comboBox1.TabIndex = 8;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(192, 0, 0);
            panel10.Controls.Add(button11);
            panel10.Controls.Add(button10);
            panel10.Controls.Add(dataGridView7);
            panel10.Controls.Add(panel11);
            panel10.Controls.Add(label23);
            panel10.Location = new Point(191, 11);
            panel10.Margin = new Padding(3, 4, 3, 4);
            panel10.Name = "panel10";
            panel10.Size = new Size(848, 540);
            panel10.TabIndex = 11;
            // 
            // button11
            // 
            button11.BackColor = Color.Black;
            button11.FlatAppearance.BorderColor = Color.Black;
            button11.FlatAppearance.BorderSize = 0;
            button11.FlatStyle = FlatStyle.Popup;
            button11.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button11.ForeColor = Color.White;
            button11.Location = new Point(305, 444);
            button11.Margin = new Padding(3, 4, 3, 4);
            button11.Name = "button11";
            button11.Size = new Size(239, 61);
            button11.TabIndex = 6;
            button11.Text = "Удалить пользователей";
            button11.UseVisualStyleBackColor = false;
            button11.Click += button11_Click;
            // 
            // button10
            // 
            button10.BackColor = Color.Black;
            button10.FlatAppearance.BorderColor = Color.Black;
            button10.FlatAppearance.BorderSize = 0;
            button10.FlatStyle = FlatStyle.Popup;
            button10.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            button10.ForeColor = Color.White;
            button10.Location = new Point(547, 444);
            button10.Margin = new Padding(3, 4, 3, 4);
            button10.Name = "button10";
            button10.Size = new Size(297, 61);
            button10.TabIndex = 5;
            button10.Text = "Просмотреть пользователей";
            button10.UseVisualStyleBackColor = false;
            button10.Click += button10_Click;
            // 
            // dataGridView7
            // 
            dataGridView7.AllowUserToAddRows = false;
            dataGridView7.AllowUserToDeleteRows = false;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView7.BackgroundColor = Color.White;
            dataGridView7.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView7.Location = new Point(337, 23);
            dataGridView7.Margin = new Padding(3, 4, 3, 4);
            dataGridView7.Name = "dataGridView7";
            dataGridView7.ReadOnly = true;
            dataGridView7.RowHeadersWidth = 51;
            dataGridView7.RowTemplate.Height = 25;
            dataGridView7.Size = new Size(466, 391);
            dataGridView7.TabIndex = 2;
            // 
            // panel11
            // 
            panel11.BackColor = Color.Black;
            panel11.Controls.Add(textBox9);
            panel11.Controls.Add(label26);
            panel11.Controls.Add(label25);
            panel11.Controls.Add(button9);
            panel11.Controls.Add(textBox8);
            panel11.Controls.Add(textBox7);
            panel11.Controls.Add(label24);
            panel11.Location = new Point(21, 96);
            panel11.Margin = new Padding(3, 4, 3, 4);
            panel11.Name = "panel11";
            panel11.Size = new Size(277, 411);
            panel11.TabIndex = 1;
            // 
            // textBox9
            // 
            textBox9.Location = new Point(13, 181);
            textBox9.Margin = new Padding(3, 4, 3, 4);
            textBox9.Name = "textBox9";
            textBox9.PlaceholderText = "Отдел";
            textBox9.Size = new Size(242, 27);
            textBox9.TabIndex = 7;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label26.ForeColor = Color.White;
            label26.Location = new Point(85, 364);
            label26.Name = "label26";
            label26.Size = new Size(21, 28);
            label26.TabIndex = 6;
            label26.Text = "*";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label25.ForeColor = Color.White;
            label25.Location = new Point(9, 360);
            label25.Name = "label25";
            label25.Size = new Size(74, 28);
            label25.TabIndex = 5;
            label25.Text = "Статус";
            // 
            // button9
            // 
            button9.BackColor = Color.FromArgb(192, 0, 0);
            button9.FlatAppearance.BorderColor = Color.Black;
            button9.FlatAppearance.BorderSize = 0;
            button9.FlatStyle = FlatStyle.Popup;
            button9.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button9.ForeColor = Color.White;
            button9.Location = new Point(13, 271);
            button9.Margin = new Padding(3, 4, 3, 4);
            button9.Name = "button9";
            button9.Size = new Size(242, 61);
            button9.TabIndex = 4;
            button9.Text = "Добавить пользователя";
            button9.UseVisualStyleBackColor = false;
            button9.Click += button9_Click;
            // 
            // textBox8
            // 
            textBox8.Location = new Point(13, 101);
            textBox8.Margin = new Padding(3, 4, 3, 4);
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "Бейдж";
            textBox8.Size = new Size(242, 27);
            textBox8.TabIndex = 2;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(13, 140);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Фио";
            textBox7.Size = new Size(242, 27);
            textBox7.TabIndex = 1;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Black;
            label24.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label24.ForeColor = Color.White;
            label24.Location = new Point(13, 23);
            label24.Name = "label24";
            label24.Size = new Size(265, 28);
            label24.TabIndex = 0;
            label24.Text = "Добавить Пользователей";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label23.ForeColor = Color.White;
            label23.Location = new Point(21, 21);
            label23.Name = "label23";
            label23.Size = new Size(181, 32);
            label23.TabIndex = 0;
            label23.Text = "Пользователи";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1094, 593);
            Controls.Add(menuStrip1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(panel6);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel10);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Despatcher Tool";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView5).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView4).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            panel6.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel7.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView7).EndInit();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem историяУстройствToolStripMenuItem;
        private Panel panel1;
        private ToolStripMenuItem инвентаризацияToolStripMenuItem;
        private ToolStripMenuItem историяПользователейToolStripMenuItem;
        private ToolStripMenuItem статистикаToolStripMenuItem;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DataGridView dataGridView2;
        private Button button3;
        private TextBox textBox3;
        private Button button4;
        private DataGridView dataGridView3;
        private DataGridView dataGridView5;
        private DataGridView dataGridView4;
        private Label label7;
        private Label label6;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button button5;
        private ToolStripMenuItem добавитьУстройствоToolStripMenuItem;
        private Panel panel6;
        private Label label12;
        private TextBox textBox4;
        private Panel panel7;
        private Label label13;
        private Button button6;
        private Label label15;
        private Label label14;
        private Label label16;
        private ComboBox comboBox1;
        private Panel panel8;
        private TextBox textBox6;
        private TextBox textBox5;
        private Button button7;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Panel panel9;
        private Label label22;
        private Label label21;
        private Button button8;
        private ToolStripMenuItem пользователиToolStripMenuItem;
        private Panel panel10;
        private Panel panel11;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label24;
        private Label label23;
        private Button button10;
        private DataGridView dataGridView7;
        private Button button9;
        private Label label26;
        private Label label25;
        private Button button11;
        private Label label28;
        private Label label27;
        private Button button12;
        private Button button13;
        private TextBox textBox9;
    }
}