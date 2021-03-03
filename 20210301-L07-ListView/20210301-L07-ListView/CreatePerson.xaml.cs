using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _20210301_L07_ListView
{
    /// <summary>
    /// Interaction logic for CreatePerson.xaml
    /// </summary>
    public partial class CreatePerson : Window
    {
        public Person Person { get { return personInTheMaking; } }

        private Person personInTheMaking;
        public CreatePerson()
        {
            InitializeComponent();
            personInTheMaking = new Person("", 0, 0.0, 0);
            this.DataContext = personInTheMaking;
        }

        private void SubmitPersonHandler(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
