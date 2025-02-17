using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class GenerateColumn
    {
        public void GenCol(DataGridView dataGridView,int _numberGen)
        {
            switch (_numberGen)
            {
                case 0:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("nameOfDevaces", "Номер устройства");
                    dataGridView.Columns.Add("numberOfUser", "Номер бейджа");
                    dataGridView.Columns.Add("nameOfUser", "Фио");
                    dataGridView.Columns.Add("departmentOfUser", "Отдел");
                    dataGridView.Columns.Add("timeStart", "Время выдачи");
                    dataGridView.Columns.Add("timeEnd", "Время приема");
                    break;
                case 1:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("nameOfDevaces", "Номер устройства");
                    dataGridView.Columns.Add("numberOfUser", "Номер бейджа");
                    dataGridView.Columns.Add("timeStart", "Время выдачи");
                    break;
                case 2:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("nameOfDevaces", "Номер устройства");
                    dataGridView.Columns.Add("numberOfUser", "Номер бейджа");
                    dataGridView.Columns.Add("timeEnd", "Время приема");
                    break;
                case 3:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("numberOfUser", "Номер бейджа");
                    dataGridView.Columns.Add("namesOfUser", "Фио");
                    dataGridView.Columns.Add("departmentOfUser", "Отдел");
                    break;
                case 4:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("numberOfDevice", "Номер устройства");
                    dataGridView.Columns.Add("numberOfUser", "Описание устройства");
                    dataGridView.Columns.Add("namesOfUser", "Комментарий");
                    break;
                case 5:
                    dataGridView.Columns.Add("number", "№");
                    dataGridView.Columns.Add("nameOfDevaces", "Номер устройства");
                    dataGridView.Columns.Add("numberOfUser", "Номер бейджа");
                    dataGridView.Columns.Add("nameOfUser", "Фио");
                    dataGridView.Columns.Add("departmentOfUser", "Отдел");
                    dataGridView.Columns.Add("timeStart", "Время выдачи");
                    dataGridView.Columns.Add("timeEnd", "Время приема");
                    dataGridView.Columns.Add("definition", "Описание");
                    dataGridView.Columns.Add("comment", "Комментарий");
                    break;
                case 6:
                    dataGridView.Columns.Add("_nameOfDevi", "Номер устройства");
                    dataGridView.Columns.Add("_descriptionOfDevi", "Состояние");
                    dataGridView.Columns.Add("_box", "В отделе");
                    break;
            }
        }

    }
}
