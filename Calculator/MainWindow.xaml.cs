using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Calc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in MainRoot.Children)
            {
                if(el is Button)
                {
                    ((Button)el).Click += ButtonClick;

                }
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            if (str == "C")
            {
                ClearTextLabel();
            }
            else if (str == "=")
            {
                Calculate();
            }

            else
            {
                WriteToTextLabel(str);
            }
        }

        private void WriteToTextLabel(string str) => textLabel.Text += str;

        private void Calculate()
        {
            string value = new DataTable().Compute(textLabel.Text, null).ToString();
            textLabel.Text = value;
        }

        private void ClearTextLabel() => textLabel.Text = "";
    }
}
