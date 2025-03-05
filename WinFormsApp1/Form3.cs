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
                    string query = $"delete from fileforanalysis where fileforanalysis.NameOfDevice = '{textBox1.Text}';";
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

            //_xRoot = _xDocument.DocumentElement;

            //foreach (XmlElement xmlElements in _xRoot)
            //{
            //    foreach (XmlNode item in xmlElements)
            //    {
            //        if (item.InnerText == textBox1.Text)
            //        {
            //            _xRoot.RemoveChild(xmlElements);
            //        }
            //    }
            //}

            //_xDocument.Save(_pathDocument + _settings._NameFileAnalyser + ".xml");
            //label3.Text = "Удалено";
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
                    string query = $"insert into fileforanalysis (fileforanalysis.NameOfDevice) values ('{textBox2.Text}');";
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
            //XmlDocument _xDoc = null;
            //FileInfo _fileInfo = null;
            //string _pathOfAnalysis = _settings._pathFileAnalysis;
            //string _pathOfDevice = "";
            //string _content =
            //    "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
            //    "<operations>\r\n  " +
            //    "<operation>\r\n    " +
            //    "<deviceID>\r\n    </deviceID>\r\n    " +
            //    "<userID>0000</userID>\r\n    " +
            //    "<sdatetimeSTR>26.10.2001 16:52:10</sdatetimeSTR>\r\n   " +
            //    " <edatetimeSTR>26.10.2001 16:52:11</edatetimeSTR>\r\n  " +
            //    "</operation>\r\n " +
            //    "</operations>  ";

            //_xDoc = _getDoc.GetXmlDocument(_settings._pathFileAnalysis, "\\FileForAnalysis.xml"); // загрузка файла с данными для анализа инвентаризации

            //_device = textBox2.Text;

            //if (_device != "")
            //{
            //    _pathOfDevice = _deviceDefinitionName.DeviceDefinition(ref _device);
            //    _fileInfo = new FileInfo(_pathOfDevice + _device + ".xml");

            //    if (!_fileInfo.Exists)
            //    {
            //        File.AppendAllTextAsync(_fileInfo.FullName, _content);
            //    }

            //    if (_xDoc.DocumentElement != null)
            //    {
            //        _xRoot = _xDoc.DocumentElement;

            //        if (_xRoot != null)
            //        {
            //            _xmlDevice = _xDoc.CreateElement("Device");
            //            _xmlNameOfDevice = _xDoc.CreateElement("NameOfDevice");
            //            _xmlTextName = _xDoc.CreateTextNode(_device);

            //            _xmlNameOfDevice.AppendChild(_xmlTextName);
            //            _xmlDevice.AppendChild(_xmlNameOfDevice);
            //            _xRoot.AppendChild(_xmlDevice);

            //            _xDoc.Save(_settings._pathFileAnalysis + "\\FileForAnalysis.xml");

            //            label6.Text = "Добавлено";
            //        }
            //    }
            //    else
            //    {
            //        label6.Text = "Не добавлено";
            //    }
            //}
        }
    }
    public struct Data
    {
        public string _nameOfDev;
    }
}
