using Npgsql;

namespace SCT_5
{
    public partial class Form1 : Form
    {
        private static string connectionString = "Host=192.168.250.133;Port=5432;Database=sct_2025;Username=sct_2025_g5;Password=SCT&2025%5";

        public Form1()
        {
            InitializeComponent();
            using NpgsqlConnection connection = new(connectionString);
        }

        //private async Task<bool> TryConnectToDatabase()
        //{
        //}
    }
}
