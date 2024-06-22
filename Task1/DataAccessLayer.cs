using Microsoft.Data.SqlClient;
using System.Data;
using System.Threading.Channels;
using System.Windows.Documents;

namespace Task1
{
    public static class DataAccessLayer
    {
        //Task1

        public static string DataSource { get; set; } = @"prserver\SQLEXPRESS";
        public static string UserID { get; set; } = "ispp2103";
        public static string Password { get; set; } = "2103";
        public static string InitialCatalog { get; set; } = "ispp2103";
        public static bool TrustServerCertificate { get; set; } = true;

        public static SqlConnectionStringBuilder ConnectionString { get; } = new()
        {
            DataSource = DataSource,
            UserID = UserID,
            Password = Password,
            InitialCatalog = InitialCatalog,
            TrustServerCertificate = TrustServerCertificate
        };

        //Task2

        public static string GetValue(string query)
        {
            using SqlConnection connection = new(ConnectionString.ToString());
            connection.Open();
            SqlCommand command = new(query, connection);
            return command.ExecuteScalar().ToString();
        }

        //Task3

        public static DataTable GetTable(string query)
        {
            using SqlConnection connection = new(ConnectionString.ToString());
            connection.Open();
            DataTable table = new();
            using SqlDataAdapter adapter = new(query, connection);
            adapter.Fill(table);
            return table;
        }

        //Task4

        static List<Book> books = new();
        public static List<Book> GetList(string query)
        {
            using SqlConnection connection = new(ConnectionString.ToString());
            connection.Open();
            using SqlCommand cmd = new(query, connection);
            var reader = cmd.ExecuteReader();
            DataTable table = new();
            table.Load(reader);
            return table;
        }
    }
}
