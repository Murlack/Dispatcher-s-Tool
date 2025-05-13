using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        public Settings _settings = new Settings();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)// удаление пользователя
        {
            label3.Text = "*";

            if (textBox1.Text != "")
            {
                string query = $"delete from usersdata where usersdata.UserID = '{textBox1.Text}';";
                MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    label3.Text = "Удалено";
                    reader.Close();
                    connection.Close();
                }
            }
        }
    }
}
