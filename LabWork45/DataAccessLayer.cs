using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabWork45
{
    public static class DataAccessLayer
    {
        //1
        public static string ServerName { get; set; } = @"prserver\SQLEXPRESS";
        public static string DatabaseName { get; set; } = "ispp2104";
        public static string Username { get; set; } = "ispp2104";
        public static string Password { get; set; } = "2104";

        public static string ConnectionString
        {
            get
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                {
                    DataSource = ServerName,
                    InitialCatalog = DatabaseName,
                    UserID = Username,
                    Password = Password
                };
                return builder.ConnectionString;
            }
        }

        //2
        public static object ExecuteScalar(string sqlCommandText)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlCommandText, connection);
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        //3
        public static DataTable ExecuteQuery(string sqlCommandText)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommandText, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        //4
        public static List<Book> GetBooksInfo()
        {
            List<Book> books = new List<Book>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("SELECT Id, Title, Price FROM Books", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string title = reader.GetString(1);
                    double price = reader.GetDouble(2);

                    books.Add(new Book { Id = id, Title = title, Price = price });
                }

                reader.Close();
            }

            return books;
        }
    }
}
