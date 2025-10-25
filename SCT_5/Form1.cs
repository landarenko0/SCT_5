using Npgsql;
using System.Text;

namespace SCT_5
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Host=192.168.250.133;Port=5432;Database=sct_2025;Username=sct_2025_g5;Password=SCT&2025%5";

        public Form1()
        {
            InitializeComponent();
            Task.Run(SetTextToLabel);
        }

        private async Task SetTextToLabel()
        {
            using NpgsqlConnection connection = new(connectionString);
            await connection.OpenAsync();

            using NpgsqlCommand command = new("select * from carservice_5.clients", connection);
            using NpgsqlDataReader reader = await command.ExecuteReaderAsync();

            StringBuilder stringBuilder = new();

            while (await reader.ReadAsync())
            {
                int id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);

                stringBuilder.Append($"id: {id}, full name: {firstName} {lastName}\n");
            }

            label1.Invoke(() =>
            {
                label1.Text = stringBuilder.ToString();
            });
        }
    }
}
