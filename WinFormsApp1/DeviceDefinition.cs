using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class DeviceDefinitionName
    {
        public void DeviceDefinition(ref string _nameOfDevice)
        {
            Settings _settings = new Settings();
            char[] _str = _nameOfDevice.ToCharArray();

            try
            {
                if (_nameOfDevice[0] == 'T' || _nameOfDevice[0] == 'Е')
                {

                    if ((_nameOfDevice[1] == 'A' && _nameOfDevice[2] == 'B') || _nameOfDevice[1] == 'Ф' && _nameOfDevice[2] == 'И')
                    {
                        _str[0] = 'T';
                        _str[1] = 'A';
                        _str[2] = 'B';
                        _nameOfDevice = GenName(_str);
                        //return _settings._pathPhoneTables;
                    }
                    else
                    {
                        _str[0] = 'T';
                        _nameOfDevice = GenName(_str);
                        //return _settings._pathPhones;
                    }
                }

                else if (_nameOfDevice[0] == 'P' || _nameOfDevice[0] == 'З')
                {
                    _str[0] = 'P';
                    _nameOfDevice = GenName(_str);
                    //return _settings._pathPowerbank;
                }

                
            }
            catch (IndexOutOfRangeException exeption)
            {
                MessageBox.Show($"Введите название устройства, ОШИБКА {exeption}");
            }

            //return "";
        }

        private string GenName(char[] chars)
        {
            string _str = "";

            for (int i = 0; i < chars.Length; i++)
            {
                _str += chars[i];
            }

            return _str;
        }
    }
}
