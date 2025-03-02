using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{
    public class Settings
    {
        private string _pathOfSettings = "Settings";
        public string _pathPhones;
        public string _pathPhoneTables;
        public string _pathPowerbank;
        public string _pathFileAnalysis;
        public string _NameFileAnalyser;
        public string _pathDataUses;
        public string _pathUsersData;
        public string _pathDeviceStatus;
        public MysqlWork _mysql = new MysqlWork();

        public Settings()
        {
            SetPathDevice(); // устанавливает пути в переменные из файла настроек при создании объекта класса - экземпляра
        }
        public void SetPathDevice()
        {
            GetDocument _getDoc = new GetDocument();
            XmlDocument _xDoc = _getDoc.GetXmlDocument(_pathOfSettings, "\\Setings.xml");
            XmlElement _xElem = _xDoc.DocumentElement;

            foreach (XmlNode _xNode in _xElem.ChildNodes) // этап установки путей в переменные класса из файла настроек
            {
                if (_xNode.Name == "PathOfPhones")
                    _pathPhones = _xNode.InnerText;

                if (_xNode.Name == "PathOfTables")
                    _pathPhoneTables = _xNode.InnerText;

                if (_xNode.Name == "PathOfPowerBanks")
                    _pathPowerbank = _xNode.InnerText;

                if (_xNode.Name == "FileForAnalysis")
                {
                    _pathFileAnalysis = _xNode.InnerText;
                    _NameFileAnalyser = _xNode.Attributes.GetNamedItem("Filename").InnerText;
                }

                if (_xNode.Name == "FileForDataUse")
                    _pathDataUses = _xNode.InnerText;

                if (_xNode.Name == "PathUsersData")
                    _pathUsersData = _xNode.InnerText;

                if (_xNode.Name == "PathdefviceStatus")
                    _pathDeviceStatus = _xNode.InnerText;

                // новые настройки 

                if (_xNode.Name == "port")
                   _mysql.port = _xNode.InnerText;

                if (_xNode.Name == "name")
                    _mysql.name = _xNode.InnerText;

                if (_xNode.Name == "password")
                    _mysql.password = _xNode.InnerText;

                if (_xNode.Name == "hostname")
                    _mysql.hostname = _xNode.InnerText;

                if (_xNode.Name == "database")
                    _mysql.database = _xNode.InnerText;

                if (_xNode.Name == "dataBasefileforanalysis")
                    _mysql.dataBasefileforanalysis = _xNode.InnerText;

                if (_xNode.Name == "dataBasedevicestatus")
                    _mysql.dataBasedevicestatus = _xNode.InnerText;

                if (_xNode.Name == "dataBaseusersdata")
                    _mysql.dataBaseusersdata = _xNode.InnerText;
            }

            _mysql._strconnect = $"server={_mysql.hostname};user={_mysql.name};database={_mysql.database};password={_mysql.password};";
        }
    }
}
