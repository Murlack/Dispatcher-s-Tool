using System.Xml;
using System.Media;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<User> _dataUsers = new(); // данные о пользователях
        private List<DeviceStatus> _deviceStatus = new(); // данные о состоянии устройств
        private OpenPanels? _openPanels;
        private Panel[]? Panels;
        private GetDocument? _getDocument = new();
        private Settings? _settings = new();
        private XmlElement? _xRoot = null;
        private XmlDocument? _xDoc = new();
        private GenerateColumn? _genColumn = new();
        private XmlElement? _xAnyDoc;
        private CheckData? _chkData = new();
        DeviceDefinitionName _deviceDefinitionName = new();
        private string? _pathOfDevace = "";
        private string? _numberPerson = ""; // бейдж
        private string? _sDate = "";
        private string? _eDate = "";
        private int _counter = 0; // счетчик 
        private string? _name = "";
        private string? _nameOfPerson = "";
        private string? _departmentOfUser = "";
        private string _deviceNumber = ""; // номер устройства -------------------------------------------------------------------------------------------------------
        private string _modeWork = ""; // режим
        private SoundPlayer _soundPlayerM001;
        private SoundPlayer _soundPlayerM002;

        public Form1()
        {
            InitializeComponent();
            _soundPlayerM001 = new SoundPlayer("sound/mode1.wav");
            _soundPlayerM002 = new SoundPlayer("sound/mode2.wav");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Panels = new Panel[6] {
                this.panel1,
                this.panel2,
                this.panel3,
                this.panel4,
                this.panel6,
                this.panel10
            };

            _openPanels = new(Panels);
            _openPanels.SetActivePanel(this.panel6);
        }
        private void историяУстройствToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel1);
        }
        private void инвентаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel2);
        }
        private void историяПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel3);
        }
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            label10.Text = "0";
            label11.Text = "0";
            _openPanels.SetActivePanel(this.panel4);
        }
        private void добавитьУстройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel6);
        }
        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel10);
        }
        private void button1_Click_1(object sender, EventArgs e) // вывод истории
        {
            MySqlConnection conn;
            MySqlCommand command;

            string _nameOfDevice = textBox1.Text;
            int _numberDataShow = (textBox2.Text == "") ? 1 : Convert.ToInt32(textBox2.Text);
            //string query = $"SELECT {_nameOfDevice}.{_nameOfDevice}, {_nameOfDevice}.deviceID, {_nameOfDevice}.userID, {_settings._mysql.dataBaseusersdata}.UserNames, {_settings._mysql.dataBaseusersdata}.UserDepartment, {_nameOfDevice}.sdatetimeSTR, {_nameOfDevice}.edatetimeSTR " +
            //    $"FROM {_settings._mysql.database}.{_nameOfDevice},{_settings._mysql.dataBaseusersdata} " +
            //    $"where {_settings._mysql.database}.{_nameOfDevice}.userID = {_settings._mysql.dataBaseusersdata}.UserID " +
            //    $"order by {_settings._mysql.database}.{_nameOfDevice}.{_nameOfDevice} " +
            //    $"desc limit {_numberDataShow};";
            string query = $"select dt.{_nameOfDevice}.{_nameOfDevice}, dt.{_nameOfDevice}.deviceID,dt.{_nameOfDevice}.userID,dt.usersdata.UserNames,dt.usersdata.UserDepartment,dt.{_nameOfDevice}.sdatetimeSTR,dt.{_nameOfDevice}.edatetimeSTR" +
                $" from {_nameOfDevice} " +
                $"left join dt.usersdata on dt.usersdata.UserID = {_nameOfDevice}.userID " +
                $"order by dt.{_nameOfDevice}.{_nameOfDevice} desc " +
                $"limit {_numberDataShow};";

            conn = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClearData(dataGridView1);
                _genColumn.GenCol(this.dataGridView1, 0); // создаем колонны

                command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]); // генерация строк
                }

                reader.Close();
                conn.Close();
            }
        }
        private List<string> Device()
        {
            MySqlConnection connection;
            MySqlCommand command;
            string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";
            List<string> dev = new List<string>();
            connection = new MySqlConnection(_settings._mysql._strconnect);

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

                command = new MySqlCommand(queryfileforanalysis, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dev.Add(reader[0].ToString());
                }

                reader.Close();
                connection.Close();
            }

            return dev;
        }
        private void button3_Click(object sender, EventArgs e) // Инветаризация
        {
            ClearData(dataGridView2);
            _genColumn.GenCol(dataGridView2, 5);

            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
            MySqlCommand command;
            MySqlDataReader reader;

            List<string> dev = Device();

            foreach (string str in dev)
            {
                string query = $"SELECT {str}.{str}, {str}.deviceID, usersdata.UserID, " +
                    $"usersdata.UserNames, usersdata.UserDepartment, {str}.sdatetimeSTR, {str}.edatetimeSTR, " +
                    $"devicestatus.DeviceDescription, devicestatus.comment " +
                    $"FROM {str}" +
                    $" LEFT JOIN devicestatus ON dt.{str}.deviceID = devicestatus.DeviceID " +
                    $"LEFT JOIN usersdata ON {str}.userID = usersdata.UserID " +
                    $"ORDER BY {str}.{str} DESC LIMIT 1;";

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
                    command = new MySqlCommand(query, connection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8]);
                    }


                    reader.Close();
                    connection.Close();
                }
            }
        }
        private void button4_Click(object sender, EventArgs e) // история пользователя
        {
            MySqlConnection connection, connection1;
            MySqlCommand command, command1;
            string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";

            connection = new MySqlConnection(_settings._mysql._strconnect);
            connection1 = new MySqlConnection(_settings._mysql._strconnect);

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
                _numberPerson = (textBox3.Text != "") ? textBox3.Text : "0001"; // бэйдж
                ClearData(dataGridView3);
                _genColumn.GenCol(dataGridView3, -1);
                command = new MySqlCommand(queryfileforanalysis, connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> dev = new List<string>();

                while (reader.Read())
                {
                    dev.Add(reader[0].ToString());
                }

                reader.Close();
                connection.Close();

                foreach (string d in dev)
                {
                    try
                    {
                        connection1.Open();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        string queryDev = $"select {d}.{d}, {d}.deviceID, {d}.userID, {d}.sdatetimeSTR, " +
                                $"{d}.edatetimeSTR from {d} where {d}.userID = '{_numberPerson}' " +
                                $"order by {d}.{d} desc";

                        command1 = new MySqlCommand(queryDev, connection1);
                        MySqlDataReader reader1 = command1.ExecuteReader();

                        while (reader1.Read())
                        {
                            dataGridView3.Rows.Add(reader1[0], reader1[1], reader1[2], reader1[3], reader1[4]);
                        }

                        reader1.Close();
                        connection1.Close();

                    }
                }
            }
        }
        private void button5_Click(object sender, EventArgs e) // статистика
        {
            MySqlConnection connection;
            MySqlCommand command;
            string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";

            connection = new MySqlConnection(_settings._mysql._strconnect);

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
                ClearData(dataGridView4);
                ClearData(dataGridView5);
                _genColumn.GenCol(dataGridView4, 1);
                _genColumn.GenCol(dataGridView5, 2);

                command = new MySqlCommand(queryfileforanalysis, connection);
                MySqlDataReader reader = command.ExecuteReader();

                List<string> dev = new List<string>();

                while (reader.Read())
                {
                    dev.Add(reader[0].ToString());
                }

                reader.Close();
                connection.Close();


                int counter1 = 0;
                int counter2 = 0;
                foreach (string d in dev)
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
                        string queryDevq1 = $"select * from {d} order by {d}.{d} desc limit 1;"; // выд
                        command = new MySqlCommand(queryDevq1, connection);
                        reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            if (reader[3].ToString() != "" && reader[4].ToString() == "")
                            {
                                dataGridView4.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                                label10.Text = $"{++counter1}";
                            }
                            else if (reader[3].ToString() != "" && reader[4].ToString() != "")
                            {
                                dataGridView5.Rows.Add(reader[0], reader[1], reader[2], reader[4]);
                                label11.Text = $"{++counter2}";
                            }
                        }

                        
                        reader.Close();
                        connection.Close();
                    }

                }
            }
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e) //авто режим
        {
            string _mode = "";

            if (e.KeyValue == 13)
            {
                _mode = textBox4.Text;
                textBox4.Text = "";

                label13.Text = _mode;

                switch (_mode)
                {
                    case "M002":
                    case "m002":
                    case "ь002":
                    case "Ь002":
                        _soundPlayerM002.Play();
                        label15.Text = "Прием";
                        _modeWork = "M002";
                        label22.Text = "Введите устройство";
                        break;

                    case "M001":
                    case "m001":
                    case "Ь001":
                    case "ь001":
                        _soundPlayerM001.Play();
                        label15.Text = "Выдача";
                        _modeWork = "M001";
                        label22.Text = "Введите устройство";
                        break;

                    default:
                        if (_mode[0] > 47 && _mode[0] < 58)
                        {
                            _numberPerson = _mode;

                            label22.Text = "Введите устройство или режим";
                        }
                        else
                        {
                            _deviceNumber = _mode;
                            _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _deviceNumber);
                            _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, $"\\{_deviceNumber}.xml");

                            if (_modeWork == "M001")
                            {
                                label22.Text = "Введите бейдж или режим";
                            }
                            else
                            {
                                label22.Text = "Введите устройство или режим";
                            }
                        }
                        break;
                }

                if (_modeWork == "M001" && _numberPerson != "" && _deviceNumber != "")
                {
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
                        string query = $"insert into {_deviceNumber} (deviceID,userID,sdatetimeSTR,edatetimeSTR) values ('{_deviceNumber}','{_numberPerson}','{DateTime.Now}','');";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();

                    }
                    _numberPerson = "";
                    _deviceNumber = "";
                }
                else if (_modeWork == "M002" && _deviceNumber != "")
                {
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
                        string query = $"UPDATE {_deviceNumber} SET edatetimeSTR = '{DateTime.Now}' WHERE edatetimeSTR = '';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();

                    }
                    _numberPerson = "";
                    _deviceNumber = "";
                }
                //_numberPerson = "";
                //_deviceNumber = "";

            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
        private void button7_Click(object sender, EventArgs e) //ручной режим
        {
            string _deviceNumberCo, _personNumber;

            if (comboBox1.Text == "Выдача")
            {
                _modeWork = "M001";

                if (_modeWork != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    _personNumber = textBox5.Text;
                    _deviceNumberCo = textBox6.Text;
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
                        string query = $"insert into {_deviceNumberCo} (deviceID,userID,sdatetimeSTR,edatetimeSTR) values ('{_deviceNumberCo}','{_personNumber}','{DateTime.Now}','');";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();

                    }

                    label28.Text = $"{_deviceNumberCo} выдан";
                }
                else
                {
                    MessageBox.Show("Заполните поля для ввода");
                }
            }
            else if (comboBox1.Text == "Прием")
            {
                _modeWork = "M002";

                if (textBox6.Text != "")
                {
                    _deviceNumberCo = textBox6.Text;

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
                        string query = $"UPDATE {_deviceNumberCo} SET edatetimeSTR = '{DateTime.Now}' WHERE edatetimeSTR = '';";

                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();

                    }

                    label28.Text = $"{_deviceNumberCo} принят";
                }
                else
                {
                    MessageBox.Show("Заполните поля для ввода");
                }
            }

            else
            {
                MessageBox.Show("Заполните поля для ввода");
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            new Form3().Show();
        }
        private void button9_Click(object sender, EventArgs e)
        {
            string _names, _userId, _department;
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (this.textBox8.Text != "" && this.textBox7.Text != "" && this.textBox9.Text != "")
            {
                string query = $"insert into usersdata (usersdata.UserID,usersdata.UserNames,usersdata.UserDepartment) values ('{textBox8.Text}','{textBox7.Text}', '{textBox9.Text}');";

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

                    label26.Text = "Успешно добавлен";


                    connection.Close();
                }
            }
            else
            {
                label26.Text = "Заполните поля";
            }
        }
        private void button10_Click(object sender, EventArgs e) // посмотреть пользователей
        {
            ClearData(this.dataGridView7);
            _genColumn.GenCol(this.dataGridView7, 3);
            string query = $"select * from {_settings._mysql.dataBaseusersdata};";
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
                    dataGridView7.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }
        private void button12_Click(object sender, EventArgs e)
        {
            new Form5().Show();
        }
        private void DeliteDataFromHistoryUses(string _nameOfDocument, string _devicesCopy)
        {
            XmlDocument _xRootHistoryUses = _getDocument.GetXmlDocument(_settings._pathDataUses, _nameOfDocument);
            XmlElement _xDocElem = _xRootHistoryUses.DocumentElement;

            if (_xRootHistoryUses.HasChildNodes)
            {
                foreach (XmlElement _xmlElems in _xDocElem.ChildNodes)
                {
                    foreach (XmlNode _xmlNodeChild in _xmlElems.ChildNodes)
                    {
                        if (_xmlNodeChild.Name == "deviceID" && _xmlNodeChild.InnerText == _devicesCopy)
                        {
                            _xDocElem.RemoveChild(_xmlNodeChild.ParentNode);
                            _xRootHistoryUses.Save(_settings._pathDataUses + _nameOfDocument);
                        }
                    }
                }
            }
        }
        private void AddDataInDocument(XmlDocument _xDocCopy, string _modeCopy, string _devicesCopy, string _tableNumberCopy, string _pathOfDevicesCopy)
        {
            XmlElement _operation = _xDocCopy.CreateElement("operation");
            XmlElement _deviceID = _xDocCopy.CreateElement("deviceID");
            XmlElement _userID = _xDocCopy.CreateElement("userID");
            XmlElement _sdatetimeSTR = _xDocCopy.CreateElement("sdatetimeSTR");
            XmlElement _edatetimeSTR = _xDocCopy.CreateElement("edatetimeSTR");

            XmlText _deviceIDText = null;
            XmlText _userIDText = null;
            XmlText _sdatetimeSTRText = null;
            XmlText _edatetimeSTRText = null;

            if (_modeCopy == "M001")
            {
                _deviceIDText = _xDocCopy.CreateTextNode(_devicesCopy);
                _userIDText = _xDocCopy.CreateTextNode(_tableNumberCopy);
                _sdatetimeSTRText = _xDocCopy.CreateTextNode($"{DateTime.Now}");
                _edatetimeSTRText = _xDocCopy.CreateTextNode($"");

                _deviceID.AppendChild(_deviceIDText);
                _userID.AppendChild(_userIDText);
                _sdatetimeSTR.AppendChild(_sdatetimeSTRText);
                _edatetimeSTR.AppendChild(_edatetimeSTRText);

                _operation.AppendChild(_deviceID);
                _operation.AppendChild(_userID);
                _operation.AppendChild(_sdatetimeSTR);
                _operation.AppendChild(_edatetimeSTR);

                XmlElement _xRoot = _xDocCopy.DocumentElement;

                if (_xRoot != null)
                {
                    _xRoot.AppendChild(_operation);
                }
            }
            else if (_modeCopy == "M002")
            {
                //DeliteDataFromHistoryUses("devices.xml", _devicesCopy);

                XmlElement _xelem = _xDocCopy.DocumentElement;

                foreach (XmlNode node in _xelem.ChildNodes)
                {

                    foreach (XmlNode _nodeLastChild in node.ChildNodes)
                    {
                        if (_nodeLastChild.Name == "edatetimeSTR" && _nodeLastChild.InnerText == "")
                            _nodeLastChild.InnerText = DateTime.Now + "";
                    }
                }
            }

            _xDocCopy.Save(_pathOfDevicesCopy);

        }
        private void ClearData(DataGridView data)
        {
            data.Columns.Clear(); // чистим колонны
            data.Rows.Clear(); // чистим строки 
        }
        private List<string> AnalysisFileSorting(List<string> _namesOfdevices)
        {
            string? _storage = "";
            List<string> _st = new();

            _xDoc = _getDocument.GetXmlDocument(_settings._pathFileAnalysis, "FileForAnalysis.xml");
            _xRoot = _xDoc.DocumentElement;

            foreach (XmlElement _xElems in _xRoot.ChildNodes) // заполнение первичных данных
            {
                foreach (XmlNode _xNode in _xElems.ChildNodes)
                {
                    _namesOfdevices.Add(_xNode.InnerText);
                }
            }

            for (int i = 0; i < _namesOfdevices.Count; i++) // сортировка от повторяющихся данных
            {
                if (_namesOfdevices[i] != null)
                {
                    _storage = _namesOfdevices[i];
                    _st.Add(_namesOfdevices[i]);
                }
                for (int l = i + 1; l < _namesOfdevices.Count; l++)
                {
                    if (_namesOfdevices[l] == _storage)
                        _namesOfdevices[l] = null;
                }
            }

            return _st;
        }
        private void RenderingDataGread(List<DataDev> _data, DataGridView _gridView, int _numberRenderGrid)
        {
            int n_1 = 0, // ограничивающая переменная
                n_2 = 0, // ограничивающая переменная
                p_1 = 1, // число выданных
                p_2 = 1; // число принятых

            for (int i = 0; i < _data.Count; i++)
            {
                foreach (XmlElement _xitem in _data[i]._element)
                {
                    switch (_numberRenderGrid)
                    {
                        case 1:
                            if (_xitem.Name == "deviceID")
                                _name = _data[i]._nameDev;

                            if (_xitem.Name == "userID")
                                _numberPerson = _xitem.InnerText;

                            if (_xitem.Name == "sdatetimeSTR")
                                _sDate = _xitem.InnerText;
                            n_1++;
                            break;

                        case 2:
                            if (_xitem.Name == "deviceID")
                                _name = _data[i]._nameDev;

                            if (_xitem.Name == "userID")
                                _numberPerson = _xitem.InnerText;

                            if (_xitem.Name == "edatetimeSTR")
                                _eDate = _xitem.InnerText;
                            n_2++;
                            break;
                    }

                    if (_numberRenderGrid == 1)
                    {
                        if (n_1 == 4)
                        {
                            _gridView.Rows.Add(p_1, _name, _numberPerson, _sDate);
                            label10.Text = p_1 + "";
                            n_1 = 0;
                            p_1++;
                        }

                    }
                    else
                    {
                        if (n_2 == 4)
                        {
                            _gridView.Rows.Add(p_2, _name, _numberPerson, _eDate);
                            label11.Text = p_2 + "";
                            n_2 = 0;
                            p_2++;
                        }
                    }

                }
            }
        }
        private void button13_Click(object sender, EventArgs e)
        {
            new Form7().Show();
        }
    }
}