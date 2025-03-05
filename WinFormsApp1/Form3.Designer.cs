namespace WinFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            panel1 = new Panel();
            panel3 = new Panel();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            label1 = new Label();
            button1 = new Button();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label4 = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 0, 0);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(26, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(688, 667);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Black;
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(button3);
            panel3.Location = new Point(328, 25);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(269, 229);
            panel3.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(11, 8);
            label5.Name = "label5";
            label5.Size = new Size(238, 28);
            label5.TabIndex = 4;
            label5.Text = "Добавление устройств";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.FromArgb(224, 224, 224);
            label6.Location = new Point(112, 191);
            label6.Name = "label6";
            label6.Size = new Size(116, 28);
            label6.TabIndex = 3;
            label6.Text = "Ожидание";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.White;
            label7.Location = new Point(37, 191);
            label7.Name = "label7";
            label7.Size = new Size(79, 28);
            label7.TabIndex = 2;
            label7.Text = "Статус:";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            textBox2.Location = new Point(18, 65);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Название устройства";
            textBox2.Size = new Size(226, 27);
            textBox2.TabIndex = 1;
            // 
            // button3
            // 
            button3.BackColor = Color.White;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(18, 127);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(226, 44);
            button3.TabIndex = 0;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(19, 557);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(255, 44);
            button2.TabIndex = 10;
            button2.Text = "Обновить таблицу";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Black;
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(346, 291);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(229, 337);
            panel2.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(17, 28);
            label1.MaximumSize = new Size(229, 0);
            label1.Name = "label1";
            label1.Size = new Size(223, 56);
            label1.TabIndex = 9;
            label1.Text = "Удаление Данных из файла анализа";
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(17, 183);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(134, 44);
            button1.TabIndex = 4;
            button1.Text = "Удалить";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(97, 231);
            label3.Name = "label3";
            label3.Size = new Size(21, 28);
            label3.TabIndex = 7;
            label3.Text = "*";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(17, 128);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Название Устройства";
            textBox1.Size = new Size(179, 27);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(17, 231);
            label2.Name = "label2";
            label2.Size = new Size(79, 28);
            label2.TabIndex = 6;
            label2.Text = "Статус:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(19, 25);
            label4.Name = "label4";
            label4.Size = new Size(280, 28);
            label4.TabIndex = 2;
            label4.Text = "Данные из файла анализа ";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(19, 75);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(255, 475);
            dataGridView1.TabIndex = 0;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(768, 724);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form3";
            Text = "Despatcher Tool";
            Load += Form3_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Label label4;
        private Button button1;
        private TextBox textBox1;
        private Panel panel2;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private Panel panel3;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBox2;
        private Button button3;
    }
}