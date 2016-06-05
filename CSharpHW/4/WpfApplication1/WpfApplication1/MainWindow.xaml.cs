using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool flag = true;
        private string error = "";
        List<User> users = new List<User>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            error = "";
            string firstName = firstName_textBox.Text;
            string lastName = lastName_textBox1.Text;
            string birthDate = bDay_textBox.Text + '.' + bMonth_textBox.Text + '.' + bYear_textBox.Text;
            string gender = gender_textBox.Text;
            string email = email_textBox.Text;
            string phone = phone_textBox.Text;
            string additionalInfo = additionalInfo_textBox.Text;

            #region FirstName, LastName
            if (!Regex.Match(firstName, @"[A-Za-z]").Success)
            {
                flag = false;
                error = "Only letters! [FirstName]\n";
            }

            if (!Regex.Match(lastName, @"[A-Za-z]").Success)
            {
                flag = false;
                error += "Only letters! [LastName]\n";
            }

            #endregion

            #region BirthDate
            if (!Regex.Match(bDay_textBox.Text, @"[0-9]").Success)
            {
                flag = false;
                error += "Only digits! [bDay]\n";
            }
            else
            {
                int bDay = Convert.ToInt32(bDay_textBox.Text);
                if (bDay < 1 || bDay > 31)
                {
                    flag = false;
                    error += "0 < Day < 32\n";
                }
            }

            if (!Regex.Match(bMonth_textBox.Text, @"[0-9]").Success)
            {
                flag = false;
                error += "Only digits! [bMonth]\n";
            }
            else
            {
                int bMonth = Convert.ToInt32(bMonth_textBox.Text);
                if (bMonth < 1 || bMonth > 12)
                {
                    flag = false;
                    error += "0 < Month < 12\n";
                }
            }

            if (!Regex.Match(bYear_textBox.Text, @"[0-9]").Success)
            {
                flag = false;
                error += "Only digits! [bYear]\n";
            }
            else
            {
                int bYear = Convert.ToInt32(bYear_textBox.Text);
                if (bYear < 1990 || bYear > DateTime.Today.Year)
                {
                    flag = false;
                    error += "1990 < Year < " + DateTime.Today.Year + "\n";
                }
            }
            #endregion

            #region Gender, Email
            if (gender.ToLower() != "male" && gender.ToLower() != "female")
            {
                flag = false;
                error += "Only male or female [Gender]\n";
            }

            if (!email.Contains("@"))
            {
                flag = false;
                error += "Must contain '@' [Email]\n";
            }
            #endregion

            #region Phone,Additional Info
            if (!Regex.Match(phone, @"[0-9]{12}").Success)
            {
                flag = false;
                error += "Only 12 digits! [Phone]\n";
            }

            if (additionalInfo.Length > 2000)
            {
                flag = false;
                error += "<2000 symbols! [bDay]\n";
            }
            #endregion

            #region Status
            if (flag)
            {
                MessageBox.Show("Congratulations!");
                users.Add(new User(firstName, lastName, birthDate, gender, email, phone, additionalInfo));
            }
            else
            {
                MessageBox.Show(error);
            }
        }
        #endregion

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var u in users)
            {
                MessageBox.Show(u.FirstName + '\n' +
                                u.LastName + '\n' +
                                u.BirthDate + '\n' +
                                u.Gender + '\n'
                                + u.Email + '\n'
                                + u.PhoneNumber + '\n' +
                                u.AdditionalInfo);
            }
        }
    }
}
