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
        public GetDocument _getdocument = new GetDocument();
        public XmlDocument _xDocument;
        public XmlElement _xRoot;
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
                //string _idUser = textBox1.Text;
                //string _namesUser = textBox2.Text;
                //string _departmentUser = textBox4.Text;
                //int _count = (textBox3.Text == "") ? 1 : Convert.ToInt32(textBox3.Text); // количество записей для удаления 
                //bool n1 = false, n2 = false, n3 = false;
                //XmlElement _parentElement;

                //_xDocument = _getdocument.GetXmlDocument(_settings._pathUsersData, "UsersData.xml");
                //_xRoot = _xDocument.DocumentElement;

                //while (_count > 0)
                //{
                //    foreach (XmlElement _xElements in _xRoot.ChildNodes)
                //    {
                //        foreach (XmlElement _xElement in _xElements.ChildNodes)
                //        {
                //            if (_xElement.InnerText == _idUser && _xElement.Name == "UserID")
                //            {
                //                n1 = true;
                //            }
                //            if (_xElement.InnerText == _namesUser && _xElement.Name == "UserNames")
                //            {
                //                n2 = true;
                //            }
                //            if (_xElement.InnerText == _departmentUser && _xElement.Name == "UserDepartment")
                //            {
                //                n3 = true;
                //            }
                //            if (n1 == true && n2 == true && n3 == true)
                //            {
                //                _parentElement = _xElements;
                //                _xRoot.RemoveChild(_parentElement);
                //                label3.Text = "Удалено";
                //                n1 = false;
                //                n2 = false;
                //                n3 = false;
                //            }
                //        }
                //    }

                //    --_count;
                //}

                //_xDocument.Save(_settings._pathUsersData + "UsersData.xml");
            }
        }
    }
}
