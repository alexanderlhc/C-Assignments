using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _20210301_L07_ListView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> people;
        public MainWindow()
        {
            InitializeComponent();
            people = new ObservableCollection<Person>()
            {
                new Person("Alexander", 12, 20, 32),
                new Person("Alexandra", 22, 28, 16),
                new Person("Josefine", 50, 49, 12),
                new Person("Sarah", 39, 56, 88)
            };

            lstPeople.ItemsSource = people;

        }

        private void AddPersonHandler(object sender, RoutedEventArgs e)
        {
            CreatePerson windowCreatePerson = new CreatePerson();
            windowCreatePerson.ShowDialog();
            Person personNew = windowCreatePerson.Person;
            people.Add(personNew);
        }
    }

}
