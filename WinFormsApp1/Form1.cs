using System.Media;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenPanels? _openPanels;
        private Panel[]? Panels;
        private Settings? _settings = new();
        private GenerateColumn? _genColumn = new();
        DeviceDefinitionName _deviceDefinitionName = new();
        private string? _numberPerson = ""; // �����
        private string _deviceNumber = ""; // ����� ���������� -------------------------------------------------------------------------------------------------------
        private string _modeWork = ""; // �����
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
        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel1);
        }
        private void ��������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel2);
        }
        private void ��������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _openPanels.SetActivePanel(this.panel3);
        }
        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            label10.Text = "0";
            label11.Text = "0";
            _openPanels.SetActivePanel(this.panel4);
        }
        private void ������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel6);
        }
        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel10);
        }
        private void button1_Click_1(object sender, EventArgs e) // ����� �������
        {
            string _nameOfDevice = textBox1.Text;
            int _numberDataShow = (textBox2.Text == "") ? 1 : Convert.ToInt32(textBox2.Text);
            string query = $"select dt.{_nameOfDevice}.{_nameOfDevice}, dt.{_nameOfDevice}.deviceID,dt.{_nameOfDevice}.userID,dt.usersdata.UserNames,dt.usersdata.UserDepartment,dt.{_nameOfDevice}.sdatetimeSTR,dt.{_nameOfDevice}.edatetimeSTR" +
                $" from {_nameOfDevice} " +
                $"left join dt.usersdata on dt.usersdata.UserID = {_nameOfDevice}.userID " +
                $"order by dt.{_nameOfDevice}.{_nameOfDevice} desc " +
                $"limit {_numberDataShow};";

            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                ClearData(dataGridView1);
                _genColumn.GenCol(this.dataGridView1, 0); // ������� �������

                using MySqlCommand command = new MySqlCommand(query, connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]); // ��������� �����
                }

                reader.Close();
                connection.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private List<string> Device()
        {
            string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";
            List<string> dev = new List<string>();
            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                using MySqlCommand command = new MySqlCommand(queryfileforanalysis, connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dev.Add(reader[0].ToString());
                }

                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return dev;
        }
        private void button3_Click(object sender, EventArgs e) // �������������
        {
            try
            {
                ClearData(dataGridView2);
                _genColumn.GenCol(dataGridView2, 5);

                using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

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


                    connection.Open();
                    using MySqlCommand command = new MySqlCommand(query, connection);
                    using MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridView2.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6], reader[7], reader[8]);
                    }

                    reader.Close();
                    connection.Close();

                }
                dev.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void button4_Click(object sender, EventArgs e) // ������� ������������
        {
            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
            using MySqlConnection connection1 = new MySqlConnection(_settings._mysql._strconnect);
            
            string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";
            try
            {
                connection.Open();

                _numberPerson = (textBox3.Text != "") ? textBox3.Text : "0001"; // �����
                ClearData(dataGridView3);
                _genColumn.GenCol(dataGridView3, -1);

                using MySqlCommand command = new MySqlCommand(queryfileforanalysis, connection);
                using MySqlDataReader reader = command.ExecuteReader();

                List<string> dev = new List<string>();

                while (reader.Read())
                {
                    dev.Add(reader[0].ToString());
                }

                reader.Close();
                connection.Close();

                foreach (string d in dev)
                {
                    connection1.Open();
                    string queryDev = $"select {d}.{d}, {d}.deviceID, {d}.userID, {d}.sdatetimeSTR, " +
                            $"{d}.edatetimeSTR from {d} where {d}.userID = '{_numberPerson}' " +
                            $"order by {d}.{d} desc";

                    using MySqlCommand command1 = new MySqlCommand(queryDev, connection1);
                    using MySqlDataReader reader1 = command1.ExecuteReader();

                    while (reader1.Read())
                    {
                        dataGridView3.Rows.Add(reader1[0], reader1[1], reader1[2], reader1[3], reader1[4]);
                    }

                    reader1.Close();
                    connection1.Close();
                }

                dev.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button5_Click(object sender, EventArgs e) // ����������
        {
            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                ClearData(dataGridView4);
                ClearData(dataGridView5);
                _genColumn.GenCol(dataGridView4, 1);
                _genColumn.GenCol(dataGridView5, 2);
                string queryfileforanalysis = $"select NameOfDevice from fileforanalysis";
                using MySqlCommand command = new MySqlCommand(queryfileforanalysis, connection);
                using MySqlDataReader reader = command.ExecuteReader();

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
                    connection.Open();
                    
                    string queryDevq1 = $"select deviceID,userID,sdatetimeSTR,edatetimeSTR from {d} order by {d}.{d} desc limit 1;"; // ���
                    using MySqlCommand command1 = new MySqlCommand(queryDevq1, connection);
                    using MySqlDataReader reader1 = command1.ExecuteReader();

                    while (reader1.Read())
                    {
                        //MessageBox.Show($"{reader[0].ToString()} {reader[1].ToString()} {reader[2].ToString()} {reader[3].ToString()}");
                        if (reader1[2].ToString() != "" && reader1[3].ToString() == "")//������
                        {
                            dataGridView4.Rows.Add(reader1[0], reader1[1], reader1[2]);
                            label10.Text = $"{++counter1}";
                        }
                        else if (reader1[2].ToString() != "" && reader1[3].ToString() != "")//������
                        {
                            dataGridView5.Rows.Add(reader1[0], reader1[1], reader1[2], reader1[3]);
                            label11.Text = $"{++counter2}";
                        }
                    }

                    reader1.Close();
                    connection.Close();
                }

                dev.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e) //���� �����
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
                    case "�002":
                    case "�002":
                        _soundPlayerM002.Play();
                        label15.Text = "�����";
                        _modeWork = "M002";
                        label22.Text = "������� ����������";
                        break;

                    case "M001":
                    case "m001":
                    case "�001":
                    case "�001":
                        _soundPlayerM001.Play();
                        label15.Text = "������";
                        _modeWork = "M001";
                        label22.Text = "������� ����������";
                        break;

                    default:
                        if (_mode[0] > 47 && _mode[0] < 58)
                        {
                            _numberPerson = _mode;

                            label22.Text = "������� ���������� ��� �����";
                        }
                        else
                        {
                            _deviceNumber = _mode;
                            _deviceDefinitionName.DeviceDefinition(ref _deviceNumber);

                            if (_modeWork == "M001")
                            {
                                label22.Text = "������� ����� ��� �����";
                            }
                            else
                            {
                                label22.Text = "������� ���������� ��� �����";
                            }
                        }

                    break;
                }

                if (_modeWork == "M001" && _numberPerson != "" && _deviceNumber != "") // ������
                {
                    using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

                    try
                    {
                        connection.Open();
                        string query = $"insert into {_deviceNumber} (deviceID,userID,sdatetimeSTR,edatetimeSTR) values ('{_deviceNumber}','{_numberPerson}','{DateTime.Now}','');";

                        using MySqlCommand command = new MySqlCommand(query, connection);
                        using MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    _numberPerson = "";
                    _deviceNumber = "";
                }
                else if (_modeWork == "M002" && _deviceNumber != "") // �����
                {
                    using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

                    try
                    {
                        connection.Open();
                        string query = $"UPDATE {_deviceNumber} SET edatetimeSTR = '{DateTime.Now}' WHERE edatetimeSTR = '';";

                        using MySqlCommand command = new MySqlCommand(query, connection);
                        using MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    _numberPerson = "";
                    _deviceNumber = "";
                }
            }
        }
        private void button6_Click(object sender, EventArgs e) // ����� �� textBox4 ��� ������ �� ��������
        {
            textBox4.Focus();
        }
        private void button7_Click(object sender, EventArgs e) // ������ �����
        {
            string _deviceNumberCo, _personNumber;

            if (comboBox1.Text == "������")
            {
                _modeWork = "M001";

                if (_modeWork != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    _personNumber = textBox5.Text;
                    _deviceNumberCo = textBox6.Text;
                    using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
                    try
                    {
                        connection.Open();
                        string query = $"insert into {_deviceNumberCo} (deviceID,userID,sdatetimeSTR,edatetimeSTR) values ('{_deviceNumberCo}','{_personNumber}','{DateTime.Now}','');";

                        using MySqlCommand command = new MySqlCommand(query, connection);
                        using MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    label28.Text = $"{_deviceNumberCo} �����";
                }
                else
                {
                    MessageBox.Show("��������� ���� ��� �����");
                }
            }
            else if (comboBox1.Text == "�����")
            {
                _modeWork = "M002";

                if (textBox6.Text != "")
                {
                    _deviceNumberCo = textBox6.Text;

                    using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
                    try
                    {
                        connection.Open();
                        string query = $"UPDATE {_deviceNumberCo} SET edatetimeSTR = '{DateTime.Now}' WHERE edatetimeSTR = '';";

                        using MySqlCommand command = new MySqlCommand(query, connection);
                        using MySqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            MessageBox.Show(reader[0].ToString());
                        }

                        reader.Close();
                        connection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    label28.Text = $"{_deviceNumberCo} ������";
                }
                else
                {
                    MessageBox.Show("��������� ���� ��� �����");
                }
            }

            else
            {
                MessageBox.Show("��������� ���� ��� �����");
            }
        }
        private void button8_Click(object sender, EventArgs e) // �������� 3 �����
        {
            new Form3().Show();
        }
        private void button9_Click(object sender, EventArgs e) // ���������� ������������
        {
            string _names, _userId, _department;
            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (this.textBox8.Text != "" && this.textBox7.Text != "" && this.textBox9.Text != "")
            {
                string query = $"insert into usersdata (usersdata.UserID,usersdata.UserNames,usersdata.UserDepartment) values ('{textBox8.Text}','{textBox7.Text}', '{textBox9.Text}');";

                try
                {
                    connection.Open();
                    using MySqlCommand command = new MySqlCommand(query, connection);
                    using MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    label26.Text = "������� ��������";

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                label26.Text = "��������� ����";
            }
        }
        private void button10_Click(object sender, EventArgs e) // ���������� �������������
        {
            ClearData(this.dataGridView7);
            _genColumn.GenCol(this.dataGridView7, 3);
            string query = $"select * from {_settings._mysql.dataBaseusersdata};";
            using MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                using MySqlCommand command = new MySqlCommand(query, connection);
                using MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView7.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button11_Click(object sender, EventArgs e) // �������� 4 �����
        {
            new Form4().Show();
        }
        private void button12_Click(object sender, EventArgs e) // �������� 5 �����
        {
            new Form5().Show();
        }
        private void ClearData(DataGridView data) // ������� ������ � �������
        {
            data.Columns.Clear(); // ������ �������
            data.Rows.Clear(); // ������ ������ 
        }
    }
}