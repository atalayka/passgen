using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace passgen;
public partial class MainWindow : Window
{
    public static int passwordLength = 0;
    public static List<string> password = [];

    public MainWindow()
    {
        InitializeComponent();

        passwordLength = (int)CharCount.Value;
        password = new List<string>();
    }

    //operation
    public interface IGenerate
    {
        public void GeneratePassword();
    }

    public class GenerateLowerCase : IGenerate
    {
        private Random random = new Random();
        private readonly string[] LowerChars = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(LowerChars.Length - 1);
                password.Add(LowerChars[randomIndex]);
            }
        }
    }

    public class GenerateUpperCase : IGenerate
    {
        private Random random = new Random();
        private readonly string[] UpperChars = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(UpperChars.Length - 1);
                password.Add(UpperChars[randomIndex]);
            }
        }
    }

    public class GenerateNumbers : IGenerate
    {
        private Random random = new Random();
        private readonly string[] Numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(Numbers.Length - 1);
                password.Add(Numbers[randomIndex]);
            }
        }
    }

    public class GenerateSymbols : IGenerate
    {
        private Random random = new Random();
        private readonly string[] Symbols = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", ":", ";", "\"", "'", "<", ">", "?", "/"];
        public void GeneratePassword()
        {
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(Symbols.Length - 1);
                password.Add(Symbols[randomIndex]);
            }
        }
    }

    int counter = 0;
    private void btnGenerate_Click(object sender, RoutedEventArgs e)
    {
        passwordLength = (int)CharCount.Value;
        if (counter % 2 == 0)
        {
            if (checkLowerCase.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateLowerCase generateLowerCase = new GenerateLowerCase();
                generateLowerCase.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
            if (checkUpperCase.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateUpperCase generateUpperCase = new GenerateUpperCase();
                generateUpperCase.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
            if (checkNumbers.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateNumbers generateNumbers = new GenerateNumbers();
                generateNumbers.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
            if (checkSymbols.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateSymbols generateSymbols = new GenerateSymbols();
                generateSymbols.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }


        }
        else
        {
            if (checkLowerCase.IsChecked == true)
            {
                txtResult.Text = "";
                GenerateLowerCase generateLowerCase = new GenerateLowerCase();
                generateLowerCase.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                password.Clear();
            }
            if (checkUpperCase.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateUpperCase generateUpperCase = new GenerateUpperCase();
                generateUpperCase.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
            if (checkNumbers.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateNumbers generateNumbers = new GenerateNumbers();
                generateNumbers.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
            if (checkSymbols.IsChecked == true)
            {

                txtResult.Text = "";
                GenerateSymbols generateSymbols = new GenerateSymbols();
                generateSymbols.GeneratePassword();
                txtResult.Text = string.Join("", password.ToArray());
                counter++;
                password.Clear();
            }
        }
    }
}

