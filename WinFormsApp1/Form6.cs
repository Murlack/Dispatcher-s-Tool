using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private GetDocument _getDocument = new GetDocument();
        private Settings _settings = new Settings();
        private XmlDocument _xDocument;
        private XmlElement _xRoot;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (textBox1.Text != "")
            {
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
                    string query = $"delete from devicestatus where devicestatus.DeviceID = '{textBox1.Text}';";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }
                    reader.Close();
                    connection.Close();
                }

                label3.Text = "Удалено";
            }
        }
    }
}
