using System.Xml;
using System.Media;

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
        private string _deviceNumber = ""; // номер устройства
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
            Panels = new Panel[7] {
                this.panel1,
                this.panel2,
                this.panel3,
                this.panel4,
                this.panel5,
                this.panel6,
                this.panel10
            };

            _openPanels = new(Panels);
            _openPanels.SetActivePanel(this.panel1);
        }
        private void историяУстройствToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData(dataGridView1);
            _openPanels.SetActivePanel(this.panel1);
        }
        private void инвентаризацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData(dataGridView2);
            _openPanels.SetActivePanel(this.panel2);
        }
        private void историяПользователейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData(dataGridView3);
            _openPanels.SetActivePanel(this.panel3);
        }
        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearData(dataGridView4);
            ClearData(dataGridView5);
            label10.Text = "0";
            label11.Text = "0";
            _openPanels.SetActivePanel(this.panel4);
        }
        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel5);
        }
        private void добавитьУстройствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel6);
        }
        private void пользователиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openPanels.SetActivePanel(this.panel10);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            List<XmlElement> _dataXml = new();
            string _nameOfDevice = textBox1.Text;
            int _numberDataShow;

            ClearData(dataGridView1);
            _genColumn.GenCol(this.dataGridView1, 0); // создаем колонны

            try
            {
                _numberDataShow = (textBox2.Text == "") ? 1 : Convert.ToInt32(textBox2.Text);

                _xDoc = _getDocument.GetXmlDocument(_deviceDefinitionName.DeviceDefinition(ref _nameOfDevice), _nameOfDevice + ".xml");
                _xRoot = _xDoc.DocumentElement; // устаналиваем коллекцию элементов

                if (_xRoot.ChildNodes.Count != 0)
                {
                    if (_xRoot.ChildNodes != null)
                    {
                        foreach (XmlElement _xElem in _xRoot.ChildNodes)
                        {
                            _dataXml.Add(_xElem);
                        }

                        _dataXml.Reverse();

                        if (_numberDataShow <= _dataXml.Count)
                        {
                            for (_counter = 0; _counter < _numberDataShow; _counter++)
                            {
                                foreach (XmlNode _xNode in _dataXml[_counter].ChildNodes)
                                {
                                    switch (_xNode.Name)
                                    {
                                        case "userID":
                                            _numberPerson = _xNode.InnerText;
                                            _chkData.CheckDataOfUsers(ref _dataUsers);
                                            foreach (User u in _dataUsers)
                                            {
                                                if (u._idUser == _numberPerson)
                                                {
                                                    _nameOfPerson = u._names;
                                                    _departmentOfUser = u._departmentUser;
                                                }
                                            }

                                            break;

                                        case "sdatetimeSTR":
                                            _sDate = _xNode.InnerText;
                                            break;

                                        case "edatetimeSTR":
                                            _eDate = _xNode.InnerText;
                                            break;
                                    }

                                }
                                if (_nameOfPerson == "" || _departmentOfUser == "")
                                {
                                    _nameOfPerson = "Нет Данных";
                                    _departmentOfUser = "Нет Данных";
                                }

                                dataGridView1.Rows.Add(_counter, _nameOfDevice, _numberPerson, _nameOfPerson, _departmentOfUser, _sDate, _eDate); // генерация строк
                                _numberPerson = ""; _nameOfPerson = ""; _sDate = ""; _eDate = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("введите число поменьше");
                        }
                    }
                }
                else {
                    MessageBox.Show("Нет данных");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            List<string>? _namesOfdevices = new(); // список для наиминований устройств
            string _comment = "", _description = "", _department = "";

            ClearData(dataGridView2);
            _genColumn.GenCol(dataGridView2, 5);

            _namesOfdevices = AnalysisFileSorting(_namesOfdevices);

            _counter = 0;
            try
            {
                foreach (string name in _namesOfdevices) // определение типа устройства и последующий вывод последней записи истории данного устройства
                {
                    _counter++;
                    _name = name;
                    _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _name);

                    if (_pathOfDevace != null)
                    {
                        _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, _name + ".xml");
                        _xAnyDoc = _xDoc.DocumentElement;

                        _chkData.CheckDataDeviceStaus(ref _deviceStatus);
                        foreach (DeviceStatus _ds in _deviceStatus)
                        {
                            if (_ds._idDevice == _name)
                            {
                                _comment = _ds._comment;
                                _description = _ds._deviceDescription;
                            }
                        }
                        try
                        {
                            if (_xAnyDoc.LastChild != null && _xAnyDoc != null)
                            {

                                foreach (XmlElement _xElems in _xAnyDoc.LastChild)
                                {
                                    if (_xElems.Name == "userID")
                                    {
                                        _numberPerson = _xElems.InnerText;
                                        _chkData.CheckDataOfUsers(ref _dataUsers);
                                        foreach (User u in _dataUsers)
                                        {
                                            if (u._idUser == _numberPerson)
                                            {
                                                _nameOfPerson = u._names;
                                                _department = u._departmentUser;
                                            }
                                        }
                                    }

                                    if (_xElems.Name == "sdatetimeSTR")
                                        _sDate = _xElems.InnerText;

                                    if (_xElems.Name == "edatetimeSTR")
                                        _eDate = _xElems.InnerText;
                                }
                                if (_nameOfPerson == "" || _department == "")
                                {
                                    _nameOfPerson = "Нет Данных";
                                    _department = "Нет Данных";
                                }

                                _comment = (_comment == "") ? "нет данных" : _comment;
                                _description = (_description == "") ? "нет данных" : _description;

                                dataGridView2.Rows.Add(_counter, _name, _numberPerson, _nameOfPerson, _department, _sDate, _eDate, _description, _comment);
                                _numberPerson = ""; _nameOfPerson = ""; _sDate = ""; _eDate = ""; _description = ""; _comment = "";

                            }
                        }
                        catch (Exception ty) { MessageBox.Show($"+{_name} ! " + _xAnyDoc.InnerXml + ty.ToString()); }
        }
                }
            }
            catch (Exception er) { MessageBox.Show(_xAnyDoc.InnerXml + er.ToString()); }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            List<string>? _namesOfdevices = new(); // список для наиминований устройств
            List<DataDev>? _storageHistoryDevice = new();
            string _department = "";

            _numberPerson = (textBox3.Text != "") ? textBox3.Text : "0001";

            ClearData(dataGridView3);
            _genColumn.GenCol(dataGridView3, 0);

            _namesOfdevices = AnalysisFileSorting(_namesOfdevices);

            _counter = 0;
            foreach (string name in _namesOfdevices) // определение типа устройства и последующий вывод последней записи истории данного устройства
            {
                _name = name;
                _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _name);

                if (_pathOfDevace != null)
                {
                    _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, _name + ".xml");
                    _xAnyDoc = _xDoc.DocumentElement;

                    if (_xAnyDoc.ChildNodes != null)
                    {
                        foreach (XmlElement _xElems in _xAnyDoc.ChildNodes)
                        {
                            if (_xElems != null)
                            {
                                try
                                {
                                    foreach (XmlElement item in _xElems)
                                    {
                                        if (item.Name == "userID" && item.InnerText == _numberPerson)
                                        {
                                            _storageHistoryDevice.Add(new() { _element = _xElems, _nameDev = name });
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Возникла ошибочка) " + ex.Message + " " + _xElems.InnerXml);
                                }
                            }
                        }
                    }
                }
            }
            foreach (DataDev item in _storageHistoryDevice)
            {
                foreach (XmlElement _xnode in item._element)
                {
                    if (_xnode.Name == "deviceID")
                        _name = item._nameDev;

                    if (_xnode.Name == "userID")
                    {
                        _numberPerson = _xnode.InnerText;
                        _chkData.CheckDataOfUsers(ref _dataUsers);
                        foreach (User u in _dataUsers)
                        {
                            if (u._idUser == _numberPerson)
                            {
                                _nameOfPerson = u._names;
                                _department = u._departmentUser;
                            }
                        }
                    }

                    if (_xnode.Name == "sdatetimeSTR")
                        _sDate = _xnode.InnerText;

                    if (_xnode.Name == "edatetimeSTR")
                        _eDate = _xnode.InnerText;
                }
                if (_nameOfPerson == "" || _department == "")
                {
                    _nameOfPerson = "Нет Данных";
                    _department = "Нет Данных";
                }
                _counter++;
                dataGridView3.Rows.Add(_counter, _name, _numberPerson, _nameOfPerson, _department, _sDate, _eDate);
                _name = ""; _numberPerson = ""; _nameOfPerson = ""; _sDate = ""; _eDate = "";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            List<string>? _namesOfdevices = new(); // список для наиминований устройств
            List<DataDev>? _dataHistoryDevTrue = new(); // принятые
            List<DataDev>? _dataHistoryDevFalse = new(); // выданные;

            ClearData(dataGridView4);
            ClearData(dataGridView5);
            _genColumn.GenCol(dataGridView4, 1);
            _genColumn.GenCol(dataGridView5, 2);

            _namesOfdevices = AnalysisFileSorting(_namesOfdevices);

            foreach (string name in _namesOfdevices) // определение типа устройства и последующий вывод последней записи истории данного устройства
            {
                _counter++;
                _name = name;
                _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _name);

                if (_pathOfDevace != null)
                {
                    _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, _name + ".xml");
                    _xAnyDoc = _xDoc.DocumentElement;

                    if (_xAnyDoc.LastChild != null)
                    {
                        int _counter = 0;
                        foreach (XmlElement _xElems in _xAnyDoc.LastChild)
                        {
                            if (_xElems.Name == "sdatetimeSTR" && _xElems.InnerText != "")
                                ++_counter;

                            if (_xElems.Name == "edatetimeSTR" && _xElems.InnerText == "" && _counter == 1)
                                _dataHistoryDevFalse.Add(new() { _element = _xAnyDoc.LastChild, _nameDev = _name });

                            if (_xElems.Name == "edatetimeSTR" && _xElems.InnerText != "")
                                _dataHistoryDevTrue.Add(new() { _element = _xAnyDoc.LastChild, _nameDev = _name });
                        }

                    }
                }
            }

            RenderingDataGread(_dataHistoryDevFalse, dataGridView4, 1); // выданные
            RenderingDataGread(_dataHistoryDevTrue, dataGridView5, 2); // принятые
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
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
                    AddDataInDocument(_xDoc, _modeWork, _deviceNumber, _numberPerson, _pathOfDevace + $"\\{_deviceNumber}.xml");
                    _numberPerson = "";
                    _deviceNumber = "";
                }
                else if (_modeWork == "M002" && _deviceNumber != "")
                {
                    AddDataInDocument(_xDoc, _modeWork, _deviceNumber, _numberPerson, _pathOfDevace + $"\\{_deviceNumber}.xml");
                    _deviceNumber = "";
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Focus();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string _deviceNumber, _personNumber;

            if (comboBox1.Text == "Выдача")
            {
                _modeWork = "M001";

                if (_modeWork != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                    _personNumber = textBox5.Text;
                    _deviceNumber = textBox6.Text;

                    _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _deviceNumber);
                    _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, $"\\{_deviceNumber}.xml");

                    AddDataInDocument(_xDoc, _modeWork, _deviceNumber, _personNumber, _pathOfDevace + $"\\{_deviceNumber}.xml");

                    label28.Text = $"{_deviceNumber} выдан";
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
                    _deviceNumber = textBox6.Text;

                    _pathOfDevace = _deviceDefinitionName.DeviceDefinition(ref _deviceNumber);
                    _xDoc = _getDocument.GetXmlDocument(_pathOfDevace, $"\\{_deviceNumber}.xml");

                    AddDataInDocument(_xDoc, _modeWork, _deviceNumber, "", _pathOfDevace + $"\\{_deviceNumber}.xml");

                    label28.Text = $"{_deviceNumber} принят";
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

            if (this.textBox8.Text != "" && this.textBox7.Text != "" && this.textBox9.Text != "")
            {
                _userId = this.textBox8.Text;
                _names = this.textBox7.Text;
                _department = this.textBox9.Text;

                _xDoc = _getDocument.GetXmlDocument(_settings._pathUsersData, "UsersData.xml");
                _xRoot = _xDoc.DocumentElement;

                XmlElement _xParent = _xDoc.CreateElement("Users");
                XmlElement _xIdUser = _xDoc.CreateElement("UserID");
                XmlElement _xNamesOfUser = _xDoc.CreateElement("UserNames");
                XmlElement _xDepartmentOfUser = _xDoc.CreateElement("UserDepartment");

                XmlText _xIdUserText = _xDoc.CreateTextNode(_userId);
                XmlText _xNamesOfUserText = _xDoc.CreateTextNode(_names);
                XmlText _xDepartmentOfUserText = _xDoc.CreateTextNode(_department);

                _xIdUser.AppendChild(_xIdUserText);
                _xNamesOfUser.AppendChild(_xNamesOfUserText);
                _xDepartmentOfUser.AppendChild(_xDepartmentOfUserText);

                _xParent.AppendChild(_xIdUser);
                _xParent.AppendChild(_xNamesOfUser);
                _xParent.AppendChild(_xDepartmentOfUser);

                _xRoot.AppendChild(_xParent);

                _xDoc.Save(_settings._pathUsersData + "UsersData.xml");
                label26.Text = "Успешно добавлен";
            }
            else
            {
                label26.Text = "Заполните поля";
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            ClearData(this.dataGridView7);

            string _idUser = "", _names = "", _department = "";
            int i = 0;

            _xDoc = _getDocument.GetXmlDocument(_settings._pathUsersData, "UsersData.xml");
            _xRoot = _xDoc.DocumentElement;
            _genColumn.GenCol(this.dataGridView7, 3);

            foreach (XmlElement _xElems in _xRoot.ChildNodes)
            {
                foreach (XmlNode _xNode in _xElems.ChildNodes)
                {
                    if (_xNode.Name == "UserID")
                        _idUser = _xNode.InnerText;

                    if (_xNode.Name == "UserNames")
                        _names = _xNode.InnerText;

                    if (_xNode.Name == "UserDepartment")
                        _department = _xNode.InnerText;
                }

                this.dataGridView7.Rows.Add(++i, _idUser, _names, _department);
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