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
using System.Xml;
using System.Text.Json;
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
        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string formattedDate = DateTime.Now.ToString("MM/dd/yyyy");

            MainWindow main = (MainWindow)Application.Current.MainWindow;
            ResultText = main.ResultText;

            SaveTODesktopFile save = new SaveTODesktopFile(txtPlatformName, txtAccountName, ResultText);
            save.Save();


            if (chkXML.IsChecked == true)
            {
                string xmlFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\passwords.xml";

                if (File.Exists(xmlFilePath))
                {
                    // XML dosyasını yükle ve yeni veriyi ekle
                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlFilePath);

                    XmlElement element = doc.CreateElement("password");
                    element.SetAttribute("password", ResultText);
                    element.SetAttribute("date", formattedDate);
                    element.SetAttribute("platform", txtPlatformName.Text);
                    element.SetAttribute("account", txtAccountName.Text);
                    doc.DocumentElement.AppendChild(element);

                    doc.Save(xmlFilePath);
                }
                else
                {
                    // Yeni XML dosyası oluştur
                    XmlDocument doc = new XmlDocument();
                    XmlElement rootElement = doc.CreateElement("passwords");
                    doc.AppendChild(rootElement);

                    // Verileri XML'e ekleyin
                    XmlElement element = doc.CreateElement("password");
                    element.SetAttribute("password", ResultText);
                    element.SetAttribute("date", formattedDate);
                    element.SetAttribute("platform", txtPlatformName.Text);
                    element.SetAttribute("account", txtAccountName.Text);
                    rootElement.AppendChild(element);

                    doc.Save(xmlFilePath);
                }
            }

            if (chkJSON.IsChecked == true)
            {
                string jsonFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\passwords.json";

                if (File.Exists(jsonFilePath))
                {
                    // JSON dosyasını oku
                    string json = File.ReadAllText(jsonFilePath);

                    // Deserializasyon ile oku
                    var data = JsonSerializer.Deserialize<object[]>(json);

                    // Yeni veriyi oluştur
                    var newData = new[]
                    {
            new { password = ResultText, date = formattedDate, platform = txtPlatformName.Text, account = txtAccountName.Text  }
        };

                    // Verileri birleştir
                    data = data.Concat(newData).ToArray();

                    // Formatlama seçenekleri ile Serialize
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string updatedJson = JsonSerializer.Serialize(data, options);

                    // JSON dosyasına kaydet
                    File.WriteAllText(jsonFilePath, updatedJson);
                }
                else
                {
                    // Yeni JSON dosyası oluştur
                    var data = new[]
                    {
            new { password = ResultText, date = formattedDate, platform = txtPlatformName.Text, account = txtAccountName.Text }
        };

                    // Formatlama seçenekleri ile Serialize
                    var options = new JsonSerializerOptions { WriteIndented = true };
                    string json = JsonSerializer.Serialize(data, options);

                    // JSON dosyasına kaydet
                    File.WriteAllText(jsonFilePath, json);
                }
            }


            if (chkCSV.IsChecked == true)
            {
                string csvFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\passwords.csv";

                if (File.Exists(csvFilePath))
                {
                    // CSV dosyasını oku ve yeni veriyi ekle
                    var lines = File.ReadAllLines(csvFilePath);

                    using (StreamWriter sw = new StreamWriter(csvFilePath))
                    {
                        foreach (var line in lines)
                        {
                            sw.WriteLine(line);
                        }

                        sw.WriteLine($"{ResultText},{formattedDate},{txtPlatformName.Text},{txtAccountName.Text}");
                    }
                }
                else
                {
                    // Yeni CSV dosyası oluştur
                    using (StreamWriter sw = new StreamWriter(csvFilePath))
                    {
                        sw.WriteLine("Password,Date,Platform,Account");
                        sw.WriteLine($"{ResultText},{formattedDate},{txtPlatformName.Text},{txtAccountName.Text}");
                    }
                }
            }



            rectTickSubmit.Visibility = Visibility.Visible;
            await Task.Delay(400);
            rectTickSubmit.Visibility = Visibility.Hidden;
            await Task.Delay(150);
            this.Close();
        }
    }
}
