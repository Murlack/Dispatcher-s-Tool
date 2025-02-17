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

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private GetDocument _getDocument = new GetDocument();
        private Settings _settings = new Settings();
        private XmlDocument _xDocument;
        private XmlElement _xRoot;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _xDocument = _getDocument.GetXmlDocument(_settings._pathDeviceStatus, "DeviceStatus.xml");
            _xRoot = _xDocument.DocumentElement;

            if (_xRoot != null && textBox1.Text != "")
            {
                int i = 0;

                foreach (XmlElement _xElements in _xRoot.ChildNodes)
                {
                    if (i == Convert.ToInt32(textBox1.Text))
                    {
                        _xRoot.RemoveChild(_xElements);
                        break;
                    }
                    i++;
                }

                _xDocument.Save(_settings._pathDeviceStatus + "DeviceStatus.xml");

                label3.Text = "Удалено";
            }
        }
    }
}
