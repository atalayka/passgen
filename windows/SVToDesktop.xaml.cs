using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static passgen.MainWindow;

namespace passgen.windows
{
    /// <summary>
    /// SVToDesktop.xaml etkileşim mantığı
    /// </summary>
    public partial class SVToDesktop : Window
    {
        public SVToDesktop()
        {
            InitializeComponent();
        }



        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(this);

            double mouseX = currentPosition.X - 260;
            double mouseY = currentPosition.Y - 190;

            Canvas.SetLeft(SiluetCanvas.Children[0], mouseX);
            Canvas.SetTop(SiluetCanvas.Children[0], mouseY);
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            SiluetCanvas.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            SiluetCanvas.Visibility = Visibility.Hidden;
        }


        public class SaveTODesktopFile : IRecord
        {
            public string platform { get; set; }
            public string account { get; set; }
            public string result { get; set; }

            string formattedDate = DateTime.Now.ToString("MM/dd/yyyy");

            public SaveTODesktopFile(TextBox txtPlatformName, TextBox txtAccountName, string resultText)
            {
                platform = txtPlatformName.Text;
                account = txtAccountName.Text;
                result = resultText.Trim(); // resultText parametresini result'e atayın

            }

            public void Save()
            {
                string text = result + " - " + formattedDate + " / " + platform + " : " + account;
                string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\passwords.txt";
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine(text);
                }
            }
        }
        public static string ResultText { get; set; }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = (MainWindow)Application.Current.MainWindow;
            ResultText = main.ResultText;

            SaveTODesktopFile save = new SaveTODesktopFile(txtPlatformName, txtAccountName, ResultText);
            save.Save();

        }
    }
}
