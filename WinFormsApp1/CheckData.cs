using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{
    internal class CheckData
    {
        XmlDocument _xDoc;
        XmlElement _xRoot;
        Settings _settings = new Settings();
        GetDocument _getDocument = new GetDocument();

        public void CheckDataDeviceStaus(ref List<DeviceStatus> _deviceStatus)
        {
            _xDoc = _getDocument.GetXmlDocument(_settings._pathDeviceStatus, "DeviceStatus.xml");
            _xRoot = _xDoc.DocumentElement;
            string _id = "", _commentDevice = "", _description = "";

            if (_xRoot != null)
            {
                foreach (XmlElement _xElements in _xRoot.ChildNodes)
                {
                    _id = _xElements.ChildNodes.Item(0).InnerText;
                    _description = _xElements.ChildNodes.Item(1).InnerText;
                    _commentDevice = _xElements.ChildNodes.Item(2).InnerText;

                    if (_id != "" && _description != "")
                    {
                        _deviceStatus.Add(new DeviceStatus { _idDevice = _id, _comment = _commentDevice, _deviceDescription = _description });
                        _commentDevice = ""; _description = ""; _id = "";
                    }
                }
            }
        }
        public void CheckDataOfUsers(ref List<User> _dataUsers)
        {
            _xDoc = _getDocument.GetXmlDocument(_settings._pathUsersData, "UsersData.xml");
            _xRoot = _xDoc.DocumentElement;
            string id = "", name = "", department = "";

            if (_xRoot != null)
            {
                foreach (XmlElement _xElements in _xRoot.ChildNodes)
                {
                    foreach (XmlElement _xElement in _xElements.ChildNodes)
                    {
                        if (_xElement.Name == "UserID")
                            id = _xElement.InnerText;

                        if (_xElement.Name == "UserNames")
                            name = _xElement.InnerText;

                        if (_xElement.Name == "UserDepartment")
                            department = _xElement.InnerText;

                        if (id != "" && name != "" && department != "")
                        {
                            _dataUsers.Add(new User { _idUser = id, _names = name, _departmentUser = department });
                            id = ""; name = ""; department = "";
                        }
                    }

                }
            }

        }

    }
}
