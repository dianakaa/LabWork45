using System.Data;
using System.Text;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = DataAccessLayer.GetConnectionString();
            MessageBox.Show(connectionString);
        }

        //private void Button_Click2(object sender, RoutedEventArgs e)
        //{
        //    string sqlCommand = "SELECT COUNT(*) FROM Book"; // Количество книг

        //    try
        //    {
        //        object result = DataAccessLayer.ExecuteScalar(sqlCommand);
        //        MessageBox.Show(result.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void Button_Click3(object sender, RoutedEventArgs e)
        //{
        //    string sqlCommand = "SELECT * FROM Book"; // Все данные из Book

        //    try
        //    {
        //        DataTable result = DataAccessLayer.ExecuteQuery(sqlCommand);
        //        // Отобразить данные из DataTable в DataGrid или другой элемент управления
        //        resultDataGrid.ItemsSource = result.DefaultView;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void resultDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        //private void Button_Click4(object sender, RoutedEventArgs e)
        //{
        //    string sqlCommand = "SELECT * FROM Book"; // Замените на нужную SQL-команду

        //    try
        //    {
        //        List<Book> books = DataAccessLayer.ExecuteQueryForList(sqlCommand);
        //        // Отобразить данные из List<Book> в DataGrid или другой элемент управления
        //        resultDataGrid.ItemsSource = books;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void resultDataGrid_SelectionChanged2(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}