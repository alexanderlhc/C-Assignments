using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace _20210224_L06_RadioButtons
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //foreach (RadioButton rb in doughs.Children)
            //    rb.Click = UpdatePrice;
            //foreach (CheckBox cb in toppings.Children)
            //   cb.Click = UpdatePrice;
        }

        private int GetDoughPrice()
        {
            RadioButton selectedDough = default;
            RadioButton curDough;
            int i = 0;
            while(selectedDough == default && i < doughs.Children.Count)
            {
                curDough = (RadioButton)doughs.Children[i];
                if ((bool)curDough.IsChecked) selectedDough = curDough;
                i++;
            }

            return Int32.Parse((string)selectedDough.Tag);
        }

        private int GetToppingPrice()
        {
            int price = 0;

            foreach (CheckBox cbTopping in toppings.Children)
            {
                if ((bool)cbTopping.IsChecked) price += Int32.Parse((string)cbTopping.Tag);
            }

            return price;
        }
        private void UpdatePrice(object sender, EventArgs e) => result.Text = GetDoughPrice() + GetToppingPrice() + ",-";

        private void UpdateClickHandler(object sender, RoutedEventArgs e) => UpdatePrice(sender, e);
    }
}
