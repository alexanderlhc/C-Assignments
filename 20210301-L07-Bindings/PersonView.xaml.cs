using System;
using System.Collections.Generic;
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

namespace _20210301_L07_Bindings
{
    /// <summary>
    /// Interaction logic for Person.xaml
    /// </summary>
    public partial class PersonView : Page
    {
        PersonGUI PersonSelected;
        public PersonView(string name, int age, double weight, int score)
        {
            InitializeComponent();
            PersonSelected = new PersonGUI("Alexander", 0, 3.2, 9);
            this.DataContext = PersonSelected;
        }

        public static implicit operator PageContent(PersonView v)
        {
            throw new NotImplementedException();
        }
    }
}
