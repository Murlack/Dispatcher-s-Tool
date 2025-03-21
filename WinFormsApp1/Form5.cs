﻿using MySql.Data.MySqlClient;
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
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private Settings _settings = new Settings();
        private GetDocument _getDocument = new GetDocument();
        private GenerateColumn _generateColumn = new GenerateColumn();
        private XmlDocument _xDocument;
        private XmlElement _xRoot;
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string query = $"insert into devicestatus (devicestatus.DeviceID, devicestatus.DeviceDescription, devicestatus.Comment) values ('{textBox1.Text}', '{textBox2.Text}','{textBox3.Text}');";
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

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                }
                //_xDocument = _getDocument.GetXmlDocument(_settings._pathDeviceStatus, "DeviceStatus.xml");
                //_xRoot = _xDocument.DocumentElement;

                //if (_xRoot != null)
                //{
                //    XmlElement _xData = _xDocument.CreateElement("Data");
                //    XmlElement _xDeviceID = _xDocument.CreateElement("DeviceID");
                //    XmlElement _xDeviceDescription = _xDocument.CreateElement("DeviceDescription");
                //    XmlElement _xComment = _xDocument.CreateElement("Comment");

                //    XmlText _xUserIDText = _xDocument.CreateTextNode(textBox1.Text);
                //    XmlText _xDeviceDescriptionText = _xDocument.CreateTextNode(textBox2.Text);
                //    XmlText _xCommentText = _xDocument.CreateTextNode((textBox3.Text == "") ? "" : textBox3.Text);

                //    _xDeviceID.AppendChild(_xUserIDText);
                //    _xDeviceDescription.AppendChild(_xDeviceDescriptionText);
                //    _xComment.AppendChild(_xCommentText);

                //    _xData.AppendChild(_xDeviceID);
                //    _xData.AppendChild(_xDeviceDescription);
                //    _xData.AppendChild(_xComment);

                //    _xRoot.AppendChild(_xData);

                //    _xDocument.Save(_settings._pathDeviceStatus + "DeviceStatus.xml");
                //}
            }
            else
            {
                MessageBox.Show("Заполните поля для ввода");
            }
        }
        private void button2_Click(object sender, EventArgs e)// просмотр данных о состоянии
        {
            string query = $"select * from devicestatus";
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
                MySqlCommand command = new MySqlCommand(query,connection);
                MySqlDataReader reader = command.ExecuteReader();
                dataGridView1.Columns.Clear();
                _generateColumn.GenCol(this.dataGridView1, 4);

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}
