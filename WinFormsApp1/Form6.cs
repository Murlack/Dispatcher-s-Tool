using MySql.Data.MySqlClient;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        private Settings _settings = new Settings();
        public Form6()
        {
            InitializeComponent();
            label3.Text = "*";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection(_settings._mysql._strconnect);

            if (textBox1.Text != "")
            {
                try
                {
                    connection.Open();
                    string query = $"delete from devicestatus where devicestatus.DeviceID = '{textBox1.Text}';";
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

                label3.Text = "Удалено";
            }
        }
    }
}
