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

namespace Task1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            connectionLabel.Content = DataAccessLayer.ConnectionString;

            
        }

        private void complateButton_Click(object sender, RoutedEventArgs e)
        {
            infoTextBlock.Text =$"Вывод: \n{DataAccessLayer.GetValue(sqlCommandTextBox.Text)}";
            infoDataGrid.ItemsSource = DataAccessLayer.GetTable(sqlCommandTextBox.Text).DefaultView;
        }
    }
}