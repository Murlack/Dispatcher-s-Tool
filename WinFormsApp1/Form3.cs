using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private GetDocument _getDocument = new();
        private XmlDocument _xDocument = new();
        private Settings _settings = new();
        private string _pathDocument;
        private XmlElement _xRoot;

        private GetDocument _getDoc = new GetDocument(); // объект загрузки документа
        private XmlElement _xmlDevice = null;
        private XmlElement _xmlNameOfDevice = null;
        private XmlText _xmlTextName = null;
        private DeviceDefinitionName _deviceDefinitionName = new DeviceDefinitionName();

        private string _device = "";
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateDataTeble();
        }

        private XmlDocument GetDocument(string _path, string _nameOfFile)
        {
            return _getDocument.GetXmlDocument(_path, _nameOfFile);
        }
        private void InitializationPathVar(string _path)
        {
            _pathDocument = _path;
        }
        private List<Data> DateAnalys(XmlDocument _xDoc)
        {
            XmlElement _xmlElement = _xDoc.DocumentElement;
            List<Data> _data = new List<Data>();

            foreach (XmlElement _elements in _xmlElement.ChildNodes)
            {
                foreach (XmlNode item in _elements.ChildNodes)
                {
                    _data.Add(new Data() { _nameOfDev = item.InnerText });
                }
            }

            return _data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
            label3.Text = "*";

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
                    string query = $"delete from fileforanalysis where fileforanalysis.NameOfDevice = '{textBox1.Text}' limit 1;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                    label3.Text = "Удалено";

                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Данные из файла анализа 
        {
            UpdateDataTeble();
        }

        private void UpdateDataTeble()
        {
            string query = $"select * from fileforanalysis";
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("", "id");
                dataGridView1.Columns.Add("", "Устройства");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1]);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (textBox2.Text != "")
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
                    string query = $"insert into fileforanalysis (fileforanalysis.NameOfDevice) values ('{textBox2.Text}'); " +
                        $"CREATE TABLE if not exists `{textBox2.Text}` (" +
                        $"`{textBox2.Text}` int NOT NULL AUTO_INCREMENT," +
                        $"`deviceID` varchar(45) NOT NULL," +
                        $"`userID` varchar(45) NOT NULL," +
                        $" `sdatetimeSTR` varchar(45) DEFAULT NULL," +
                        $"  `edatetimeSTR` varchar(45) DEFAULT NULL," +
                        $"  PRIMARY KEY (`{textBox2.Text}`)" +
                        $" ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                    label6.Text = "Добавлено";
                }
            }
            else 
            {
                label6.Text = "Не добавлено";
            }
        }
    }
    public struct Data
    {
        public string _nameOfDev;
    }
}
