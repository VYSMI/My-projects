using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Practic
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void WriteToFileButton_Click(object sender, RoutedEventArgs e)
        {
            string textToWrite = textBox.Text;
            try
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    FileName = "Новый_файл"
                };

                if (butTxt.IsChecked == true)
                {
                    saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                }
                else if (butDoc.IsChecked == true)
                {
                    saveFileDialog.Filter = "Документы Word (*.doc)|*.doc|Все файлы (*.*)|*.*";
                }

                bool? result = saveFileDialog.ShowDialog();

                if (result == true)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(textToWrite);
                    }
                    label.Content = $"Файл сохранен по пути: {filePath}";
                    MessageBox.Show("Текст успешно записан в файл.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}
