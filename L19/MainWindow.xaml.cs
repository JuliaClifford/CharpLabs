using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace L19
{
    public partial class MainWindow : Window
    {
        private string fileName = @"C:\YourJson.json";
        public MainWindow() => InitializeComponent();

        private void WriteDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            WindowSettings data = new WindowSettings();
            data.FirstTaskCheckBox = (bool)FirstTaskCheckBox.IsChecked;
            data.SecondTaskCheckBox = (bool)SecondTaskCheckBox.IsChecked;
            data.ThirdTaskCheckBox = (bool)ThirdTaskCheckBox.IsChecked;

            data.Text = Text.Text;

            data.ScreenHeight = Height;
            data.ScreenWidth = Width;
            
            try
            {
                using StreamWriter streamWriter = new StreamWriter(fileName);
                string settings = JsonSerializer.Serialize(data);
                streamWriter.Write(settings);
                MessageBox.Show($"Check {fileName}");
            }
            catch
            {
                MessageBox.Show("Failed. Try Again");
            }
        }
    }
}