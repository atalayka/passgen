using System;
using System.Windows;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using System.IO;
using System.Security.Principal;

namespace passgen;
public partial class MainWindow : Window
{
    public static int passwordLength = 0;
    public static List<string> crudePassword = [];
    public static List<string> password = [];

    public MainWindow()
    {
        InitializeComponent();
        passwordLength = (int)CharCount.Value;
    }

    //operation
    public interface IGenerate
    {
        public void GeneratePassword();
    }

    public class GenerateLowerCase : IGenerate
    {
        private Random random = new Random((int)DateTime.Now.Ticks + 123);
        private List<string> LowerChars = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(LowerChars.Count - 1);
                crudePassword.Add(LowerChars[randomIndex]);
                LowerChars.Remove(LowerChars[randomIndex]);
            }
        }
    }

    public class GenerateUpperCase : IGenerate
    {
        private Random random = new Random((int)DateTime.Now.Ticks + 234);
        private List<string> UpperChars = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(UpperChars.Count - 1);
                crudePassword.Add(UpperChars[randomIndex]);
                UpperChars.Remove(UpperChars[randomIndex]);
            }
        }
    }

    public class GenerateNumbers : IGenerate
    {
        private Random random = new Random((int)DateTime.Now.Ticks + 345);
        private List<string> Numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
        public void GeneratePassword()
        {
            for (int i = 0; i < 10; i++)
            {
                int randomIndex = random.Next(Numbers.Count - 1);
                crudePassword.Add(Numbers[randomIndex]);
                Numbers.Remove(Numbers[randomIndex]);
            }
        }
    }

    public class GenerateSymbols : IGenerate
    {
        private Random random = new Random((int)DateTime.Now.Ticks + 456);
        private List<string> Symbols = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", ":", ";", "\"", "'", "<", ">", "?", "/"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(Symbols.Count - 1);
                crudePassword.Add(Symbols[randomIndex]);
                Symbols.Remove(Symbols[randomIndex]);
            }
        }
    }


    int counter = 0;

    private async void btnGenerate_Click(object sender, RoutedEventArgs e)
    {
        passwordLength = (int)CharCount.Value;
        if (counter % 2 == 0)
        {
            txtResult.Text = "";
            if (checkLowerCase.IsChecked == true)
            {
                GenerateLowerCase generateLowerCase = new GenerateLowerCase();
                generateLowerCase.GeneratePassword();
            }
            if (checkUpperCase.IsChecked == true)
            {
                GenerateUpperCase generateUpperCase = new GenerateUpperCase();
                generateUpperCase.GeneratePassword();
            }
            if (checkNumbers.IsChecked == true)
            {
                GenerateNumbers generateNumbers = new GenerateNumbers();
                generateNumbers.GeneratePassword();
            }
            if (checkSymbols.IsChecked == true)
            {
                GenerateSymbols generateSymbols = new GenerateSymbols();
                generateSymbols.GeneratePassword();
            }
            try
            {
                Random random = new Random((int)DateTime.Now.Ticks + 567);
                for (int i = 0; i < passwordLength; i++)
                {
                    int randomIndex = random.Next(crudePassword.Count - 1);
                    password.Add(crudePassword[randomIndex]);
                    crudePassword.Remove(crudePassword[randomIndex]);
                }
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
                crudePassword.Clear();
            }
            catch
            {
                txtResult.Text = "Don't waste my time.";
            }
        }

        else
        {
            txtResult.Text = "";
            if (checkLowerCase.IsChecked == true)
            {
                GenerateLowerCase generateLowerCase = new GenerateLowerCase();
                generateLowerCase.GeneratePassword();
            }
            if (checkUpperCase.IsChecked == true)
            {
                GenerateUpperCase generateUpperCase = new GenerateUpperCase();
                generateUpperCase.GeneratePassword();
            }
            if (checkNumbers.IsChecked == true)
            {
                GenerateNumbers generateNumbers = new GenerateNumbers();
                generateNumbers.GeneratePassword();
            }
            if (checkSymbols.IsChecked == true)
            {
                GenerateSymbols generateSymbols = new GenerateSymbols();
                generateSymbols.GeneratePassword();
            }

            try
            {
                Random random = new Random((int)DateTime.Now.Ticks + 678);
                for (int i = 0; i < passwordLength; i++)
                {
                    int randomIndex = random.Next(crudePassword.Count - 1);
                    password.Add(crudePassword[randomIndex]);
                    crudePassword.Remove(crudePassword[randomIndex]);
                }
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
                crudePassword.Clear();
            }
            catch
            {
                txtResult.Text = "Don't waste my time.";
            }
        }
        btnGenerate.Visibility = Visibility.Hidden;
        await Task.Delay(400);
        btnGenerate.Visibility = Visibility.Visible;

    }
    private async void copyToClipB_Click(object sender, RoutedEventArgs e)
    {
        try
        {
          

            rectTickClipB.Visibility = Visibility.Visible;
            Clipboard.SetText(txtResult.Text);
            await Task.Delay(1050);
        }
        catch (Exception)
        {
        }
        finally
        {
            rectTickClipB.Visibility = Visibility.Hidden;
        }
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

    public interface IRecord
    {
        public void Save();
    }

    public class SaveTODesktopFile : IRecord
    {
        public TextBox TxtResult { get; set; }
        public string platform { get; set; }
        public string account { get; set; }

        string formattedDate = DateTime.Now.ToString("MM/dd/yyyy");

        public SaveTODesktopFile(TextBox txtResult, string platform, string account)
        {
            TxtResult = txtResult;
            this.platform = platform;
            this.account = account;
        }

        public void Save()
        {
            string text = TxtResult.Text + " - " + formattedDate + " / " + platform + " : " + account;
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

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnToDesktop_Click(object sender, RoutedEventArgs e)
    {
        SaveTODesktopFile saveTOdeskFile = new(txtResult, "atalay", "google"); //BURAYI DÜZENLE!!!
        saveTOdeskFile.Save();
    }
}

