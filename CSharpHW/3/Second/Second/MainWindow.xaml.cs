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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyLib_Age_Zodiac;

namespace Second
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckAge_And_ZodiacSign myClass = new CheckAge_And_ZodiacSign();

            textBox.Text = myClass.UserInfo(DatePicker1.SelectedDate.Value);
            //BitmapImage b = new BitmapImage();
            //b.BeginInit();
            //b.UriSource = new Uri();
            //b.EndInit();
            //image.Source = b;
        }
    }
}
