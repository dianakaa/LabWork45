using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Windows;

namespace Task2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog dialog = new()
            {
                Filter = "файлы|*.png;*.jpg;*.jpeg;*.bmp",
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Выбор изображений",
                Multiselect = true
            };

            if (dialog.ShowDialog() == true)
                ImageListView.ItemsSource = dialog.FileNames;
        }
    }
}