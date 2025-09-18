using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        private Settings _settings = new Settings();
        private GenerateColumn _generateColumn = new GenerateColumn();
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string query = $"insert into devicestatus (devicestatus.DeviceID, devicestatus.DeviceDescription, devicestatus.Comment) values ('{textBox1.Text}', '{textBox2.Text}','{textBox3.Text}');";
                MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

                try
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        MessageBox.Show(reader[0].ToString());
                    }

                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполните поля для ввода");
            }
        }
        private void button2_Click(object sender, EventArgs e)// просмотр данных о состоянии
        {
            string query = $"select * from devicestatus";
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                dataGridView1.Columns.Clear();
                _generateColumn.GenCol(this.dataGridView1, 4);

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader[0], reader[1], reader[2], reader[3]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            new Form6().Show();
        }
    }
}
