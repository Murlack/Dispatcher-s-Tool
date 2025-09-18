using System.Xml;

namespace WinFormsApp1
{
    static class WorkOnXml
    {
        public static int CountElemOfDoc()
        {
            XmlDocument _xDoc;
            XmlElement _xRoot;
            Settings _settings = new Settings();
            GetDocument _getDocument = new GetDocument();
            int _countDeviceiD = 0;

            _xDoc = _getDocument.GetXmlDocument(_settings._pathDeviceStatus, "DeviceStatus.xml");
            _xRoot = _xDoc.DocumentElement;

            if (_xRoot != null)
            {
                foreach (XmlElement _xElements in _xRoot.ChildNodes)
                {
                    foreach (XmlElement _xElement in _xElements.ChildNodes)
                    {
                        if (_xElement.Name == "DeviceID")
                        { 
                            _countDeviceiD++;
                        }
                    }
                }
            }

            return _countDeviceiD;
        }
        public static List<StatsDevices> TakingDataFromDeviceStates()
        {
            XmlDocument _xDoc;
            XmlElement _xRoot;
            Settings _settings = new Settings();
            GetDocument _getDocument = new GetDocument();
            _xDoc = _getDocument.GetXmlDocument(_settings._pathDeviceStatus, "DeviceStatus.xml");
            _xRoot = _xDoc.DocumentElement;
            List<StatsDevices> _devices = new List<StatsDevices>();
            string _nameOfDev = "";
            string _descriptionOfDev = "";
            string _box = "";

            try{
                if (_xRoot != null)
                {
                    foreach (XmlElement _xElements in _xRoot.ChildNodes)
                    {
                        foreach (XmlElement _xElement in _xElements.ChildNodes)
                        {
                            if (_xElement.Name == "DeviceID")
                            {
                                _nameOfDev = _xElement.InnerText;
                            }
                            if (_xElement.Name == "DeviceDescription")
                            {
                                _descriptionOfDev = _xElement.InnerText;
                                _devices.Add(new StatsDevices { _nameOfDevi = _nameOfDev, _descriptionOfDevi = _descriptionOfDev, _box = _box});
                            }
                        }
                    }
                    return _devices;
                }
            }
            catch (Exception e) 
            { 
                MessageBox.Show(e.ToString()); 
            }

            return new List<StatsDevices>();
        }
    }
}
