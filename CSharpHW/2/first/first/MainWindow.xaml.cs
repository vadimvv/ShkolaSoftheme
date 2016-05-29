using System;
using System.Windows;
using System.Windows.Controls;


namespace first
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

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBoxChangeItem(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (listBox.SelectedItem as ListBoxItem);
            switch (selectedItem.Content.ToString())
            {
                case "sbyte":
                    ShowSbyteValues();
                    break;
                case "short":
                    ShowShortValues();
                    break;
                case "int":
                    ShowIntValues();
                    break;
                case "long":
                    ShowLongValues();
                    break;
                case "byte":
                    ShowByteValues();
                    break;
                case "ushort":
                    ShowUshortValues();
                    break;
                case "uint":
                    ShowUintValues();
                    break;
                case "ulong":
                    ShowUlongValues();
                    break;
                case "float":
                    ShowFloatValues();
                    break;
                case "double":
                    ShowDoubleValues();
                    break;
                case "decimal":
                    ShowDecimalValues();
                    break;
            }

        }

        private void ShowUlongValues()
        {
            min.Text = ulong.MinValue + "";
            max.Text = ulong.MaxValue + "";
            Def.Text = 13UL + "";
        }

        private void ShowUintValues()
        {
            min.Text = uint.MinValue + "";
            max.Text = uint.MaxValue + "";
            Def.Text = 13U + "";
        }

        private void ShowUshortValues()
        {
            min.Text = ushort.MinValue + "";
            max.Text = ushort.MaxValue + "";
            Def.Text = 13 + "";
        }

        private void ShowByteValues()
        {
            min.Text = byte.MinValue + "";
            max.Text = byte.MaxValue + "";
            Def.Text = 13 + "";
        }

        private void ShowShortValues()
        {
            min.Text = short.MinValue + "";
            max.Text = short.MaxValue + "";
            Def.Text = 13 + "";
        }

        private void ShowSbyteValues()
        {
            Random rand = new Random();

            min.Text = sbyte.MinValue + "";
            max.Text = sbyte.MaxValue + "";
            Def.Text = 13 + "";
        }

        private void ShowDecimalValues()
        {
            min.Text = decimal.MinValue + "";
            max.Text = decimal.MaxValue + "";
            Def.Text = 0.13M + "";
        }

        private void ShowDoubleValues()
        {
            min.Text = double.MinValue + "";
            max.Text = double.MaxValue + "";
            Def.Text = 0.13 + "";
        }

        private void ShowFloatValues()
        {
            min.Text = float.MinValue + "";
            max.Text = float.MaxValue + "";
            Def.Text = 0.13F + "";
        }

        private void ShowLongValues()
        {
            min.Text = long.MinValue + "";
            max.Text = long.MaxValue + "";
            Def.Text = 13L + "";
        }

        private void ShowIntValues()
        {
            min.Text = Int32.MinValue + "";
            max.Text = Int32.MaxValue + "";
            Def.Text = 13 + "";
        }

        private void ListBoxChangeItem(object sender, RoutedEventArgs e)
        {

        }
    }
}
