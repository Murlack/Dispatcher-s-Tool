using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        private Settings _settings = new();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateDataTeble();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);
            label3.Text = "*";

            if (textBox1.Text != "")
            {
                try
                {
                    connection.Open();
                    string query = $"delete from fileforanalysis where fileforanalysis.NameOfDevice = '{textBox1.Text}' limit 1;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                    label3.Text = "Удалено";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) // Данные из файла анализа 
        {
            UpdateDataTeble();
        }

        private void UpdateDataTeble()
        {
            string query = $"select * from fileforanalysis";
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("", "id");
                dataGridView1.Columns.Add("", "Устройства");
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (textBox2.Text != "")
            {
                try
                {
                    connection.Open();
                    string query = $"insert into fileforanalysis (fileforanalysis.NameOfDevice) values ('{textBox2.Text}'); " +
                        $"CREATE TABLE if not exists `{textBox2.Text}` (" +
                        $"`{textBox2.Text}` int NOT NULL AUTO_INCREMENT," +
                        $"`deviceID` varchar(45) NOT NULL," +
                        $"`userID` varchar(45) NOT NULL," +
                        $" `sdatetimeSTR` varchar(45) DEFAULT NULL," +
                        $"  `edatetimeSTR` varchar(45) DEFAULT NULL," +
                        $"  PRIMARY KEY (`{textBox2.Text}`)" +
                        $" ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                    label6.Text = "Добавлено";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else 
            {
                label6.Text = "Не добавлено";
            }
        }
    }
}
