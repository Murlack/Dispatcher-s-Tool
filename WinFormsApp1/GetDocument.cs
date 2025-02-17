using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WinFormsApp1
{
    public class GetDocument
    {
        public XmlDocument GetXmlDocument(string _path, string _nameOfFile) // метод для загрузки документа
        {
            try
            {
                XmlDocument _xDoc = new XmlDocument();
                _xDoc.Load(_path + _nameOfFile);

                return _xDoc; // возвращает загруженный документ
            }
            catch (FileNotFoundException exeption)
            { 
                return new XmlDocument();
            }
        }
    }
}
