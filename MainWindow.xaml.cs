using Microsoft.Win32;
using System.IO;
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

namespace _5Pi
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enscript(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(klucz.Text) && String.IsNullOrEmpty(wpiszSzyfr.Text))
            {
                MessageBox.Show("Klucz i tekst jest pusty");
                return;
            }
            else if (String.IsNullOrEmpty(klucz.Text))
            {
                MessageBox.Show("Klucz jest pusty");
                return;
            }
            else if (String.IsNullOrEmpty(wpiszSzyfr.Text))
            {
                MessageBox.Show("Tekst jest pusty");
                return;
            }
            szyfr.Text = Cesar.Szyfr(Convert.ToInt32(klucz.Text), wpiszSzyfr.Text);
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            try
            {
                string textToSave = szyfr.Text;

                var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    FileName = "MyText.txt",
                    Title = "Save your text file"
                };

                bool? result = saveFileDialog.ShowDialog();

                if (result == true)
                {
                    File.WriteAllText(saveFileDialog.FileName, textToSave);
                    MessageBox.Show("File saved successfully!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving file:\n{ex.Message}","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
    }
}