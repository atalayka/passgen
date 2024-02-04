using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace passgen
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static PasswordCharacters characters = new();
        public static Random random = new Random();
        public static string password = "";
        public static PasswordGenerator passwordGenerator = new();


        public class PasswordCharacters
        {
            public readonly string[] UpperChars = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
            public readonly string[] LowerChars = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
            public readonly string[] Numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
            public readonly string[] Symbols = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", ":", ";", "\"", "'", "<", ">", "?", "/"];
        }
        public class PasswordGenerator
        {
            public void UpperCaseGenerated()
            {
                int RIndex = random.Next(0, characters.UpperChars.Length);
                password += characters.UpperChars[RIndex];
            }
            public void LowerCaseGenerated()
            {
                int RIndex = random.Next(0, characters.LowerChars.Length);
                password += characters.LowerChars[RIndex];
            }
            public void NumberCaseGenerated()
            {
                int RIndex = random.Next(0, characters.Numbers.Length);
                password += characters.Numbers[RIndex];
            }
            public void SymbolCaseGenerated()
            {
                int RIndex = random.Next(0, characters.Symbols.Length);
                password += characters.Symbols[RIndex];
            }
        }
        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            password = "";
            txtResult.Clear();
            if (checkLowerCase.IsChecked == true)
            {
                passwordGenerator.LowerCaseGenerated();
            }
            if (checkUpperCase.IsChecked == true)
            {
                passwordGenerator.UpperCaseGenerated();
            }
            if (checkSymbols.IsChecked == true)
            {
                passwordGenerator.SymbolCaseGenerated();
            }
            if (checkNumbers.IsChecked == true)
            {
                passwordGenerator.NumberCaseGenerated();
            }
            txtResult.Text = password;
        }
    }
}

