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

namespace passgen;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    //value class
    public static class PasswordCharacters
    {
        public static readonly string[] UpperChars = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
        public static readonly string[] LowerChars = ["a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"];
        public static readonly string[] Numbers = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
        public static readonly string[] Symbols = ["!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+", "=", "{", "}", "[", "]", "|", ":", ";", "\"", "'", "<", ">", "?", "/"];
    }

    //operation
    public interface IGenerate
    {
        public void GeneratePassword();
    }

    public class GenerateLowerCase : IGenerate
    {
        public void GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }

    public class GenerateUpperCase : IGenerate
    {
        public void GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }

    public class GenerateNumbers : IGenerate
    {
        public void GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }

    public class GenerateSymbols : IGenerate
    {
        public void GeneratePassword()
        {
            throw new NotImplementedException();
        }
    }
}

