using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    static class DSFV // device storage for verification запоминающее устройство для проверки
    {
        public static List<string> _AFAI = new List<string>(); // array for analysis inventorization массив для анализа и инвентаризации
        public static int LenghtAFAI;
        public static void ClearData() // очищает данные из массива вводимых данных
        {
            _AFAI.Clear();
        }
        public static void SetAFAI(string str) // устанавливает данные в массив 
        {
            if (str != null && str != "")
            {
                _AFAI.Add(str);
            }
        }
        public static int GetLengthAFAI() // возвращает длину массива вводимах данных
        { 
            return _AFAI.Count;
        }
    }
}
