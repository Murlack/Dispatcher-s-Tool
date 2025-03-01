using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public class MysqlWork
    {
        public string port;
        public string name;
        public string password;
        public string hostname;
        public string database;
        public string dataBasefileforanalysis;
        public string dataBasedevicestatus;
        public string dataBaseusersdata;
        public void DatabaseOperation(string query, byte key) //key 1- dataBasefileforanalysis 2- dataBasedevicestatus 3- dataBaseusersdata 4- devices
        {
            string _strconnect = $"server={this.hostname};user={this.name};database={this.database};password={this.password};";
            MySqlConnection conn = new MySqlConnection(_strconnect);
            MySqlCommand command;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();



                reader.Close();
                conn.Close();
            }
        }
    }
}
