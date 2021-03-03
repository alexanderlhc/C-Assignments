using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _20210224_L06_FileBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenHandler(object sender, RoutedEventArgs e)
        {
            txtContent.Text = ReadFile(getFileFromDialog(new OpenFileDialog()));
        }

        private void SaveAsHandler(object sender, RoutedEventArgs e)
        {
            string content = txtContent.Text;
            WriteFile(getFileFromDialog(new SaveFileDialog()), content);
        }
        private void ExitHandler(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void AboutHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("C# not so sharp");
        }

        //////////////////////////////////////////////////////////
        // HELPER METHODS

        private string ReadFile(string filepathAndName) => string.Join("\n", File.ReadAllLines(filepathAndName));

        private void WriteFile(string filepathAndName, string content) => System.IO.File.WriteAllText(filepathAndName, content);

        private string getFileFromDialog(FileDialog fileDialog)
        {
            string file = default;
            fileDialog.Title = "Select text file";
            fileDialog.Filter = "txt file (*.txt)|*.txt";
            fileDialog.ShowDialog();
            if (!String.IsNullOrEmpty(fileDialog.FileName))
                file = fileDialog.FileName;
            return file;
        }

    }
}
