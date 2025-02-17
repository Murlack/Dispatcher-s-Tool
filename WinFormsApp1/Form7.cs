using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form7 : Form
    {
        static int _CcountElemOfDoc;
        public Form7()
        {
            InitializeComponent();
            _CcountElemOfDoc = WorkOnXml.CountElemOfDoc();
            label3.Text = _CcountElemOfDoc.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DSFV.LenghtAFAI = WorkOnXml.CountElemOfDoc();
            Console.WriteLine(DSFV.LenghtAFAI);
            DSFV.SetAFAI(textBox1.Text);
            _CcountElemOfDoc--;
            label3.Text = _CcountElemOfDoc.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearDataInTable();

            List<StatsDevices> arr = WorkOnXml.TakingDataFromDeviceStates();
            int _isExists = 0;

            List<StatsDevices> list = new List<StatsDevices>();
            List<string> NoList = new List<string>();
            StatsDevices itemStatsDevices = null;
            GenerateColumn GC = new GenerateColumn();

            for (int i = 0; i < DSFV._AFAI.Count && i < arr.Count; i++) //    Console.WriteLine(item + " нашлось");
            {
                if ((itemStatsDevices = ISNOEXIST_1(DSFV._AFAI[i], arr)) != null)
                {
                    itemStatsDevices._box = "НА МЕСТЕ";
                    list.Add(itemStatsDevices);
                }
            }

            for (int i = 0; i < DSFV._AFAI.Count; i++) //    Console.WriteLine(item + " не нашлось");
            {
                if (ISNOEXIST_2(DSFV._AFAI[i], arr))
                {
                    NoList.Add(DSFV._AFAI[i]);
                }
            }

            GC.GenCol(dataGridView1, 6);

            foreach (var item in list)
            {
                dataGridView1.Rows.Add(item._nameOfDevi, item._descriptionOfDevi, item._box);
            }
            foreach (var item in NoList)
            {
                dataGridView1.Rows.Add(item, "", "НЕТ");
            }
        }
        private StatsDevices ISNOEXIST_1(string _afaiItem, List<StatsDevices> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (_afaiItem == list[i]._nameOfDevi)
                {
                    return list[i];
                }
            }
            return null;

        }
        private bool ISNOEXIST_2(string _afaiItem, List<StatsDevices> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (_afaiItem == list[i]._nameOfDevi)
                {
                    return false;
                }
            }

            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DSFV.ClearData();
            ClearDataInTable();
            _CcountElemOfDoc = WorkOnXml.CountElemOfDoc();
            label3.Text = _CcountElemOfDoc.ToString();
        }
        private void ClearDataInTable()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }
    }
}
