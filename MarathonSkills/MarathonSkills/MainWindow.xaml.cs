using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MarathonSkills
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Time
        {
            get
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = DateTime.Parse("2017-10-21 6:00");

                TimeSpan ts = dt2 - dt1;

                return string.Format("{0} дн {1} ч {2} мин {3} сек до старта  марафона", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext= this;
        }

        event PropertyChangedEventHandler? INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer tmr = new Timer();

            tmr.Interval = 1000;
            tmr.Elapsed += Tmr_Elapsed;

            tmr.Start();
        }

        private void Tmr_Elapsed(object sender, RoutedEventArgs e)
        {
            PropertyChange("Time");
        }
        private void PropertyChange(string name)
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
