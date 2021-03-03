using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace _20210301_L07_Bindings
{
    class PersonGUI : Person, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public PersonGUI(string name, int age, double weight, int score) : base(name, age, weight, score)
        {
        }

        public new string Name
        {
            get { return base.Name;  }
            set { base.Name = value; PropertyChangedEventHandler("Print"); }
        }


        private void PropertyChangedEventHandler(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
