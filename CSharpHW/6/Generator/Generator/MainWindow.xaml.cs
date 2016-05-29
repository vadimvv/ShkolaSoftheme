using System;
using System.Windows;


namespace Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "";
            int userNumber = 0;
            Random rand = new Random();
            int computerNumber = rand.Next(0, 11);
            
            try
            {
                userNumber = Convert.ToInt32(textBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            CheckResult(computerNumber, userNumber);
        }

        private void CheckResult(int computerNumber, int userNumber)
        {
            if (computerNumber == userNumber)
            {

                label2.Content = "Congratulation!";
                result.Content = computerNumber.ToString();
            }
            else
            {
                result.Content = computerNumber.ToString();
                label2.Content = "Wrong..";
            }
        }
    }
}
