using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace _20210224_L06_Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer Clock;
        public MainWindow()
        {
            InitializeComponent();
            Clock = new DispatcherTimer();
            StartClock();
        }

        private void StartClock()
        {
            Clock.Tick += new EventHandler(UpdateTime);
            Clock.Interval = new TimeSpan(0, 0, 1);
            Clock.Start();
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            clock.Text = $"{dt.Hour}:{dt.Minute}:{dt.Second}";
        }

    }
}
