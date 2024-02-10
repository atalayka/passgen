using System;
using System.Linq;
using System.Windows;
using System.Collections.Generic;

namespace passgen;
public partial class MainWindow : Window
{
    public static int passwordLength = 0;
    public static List<string> password = [];
    public static List<string> result = [];

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

    public class Shuffle(List<string> password)
    {
        public List<string> ShuffleList(List<string> password)
        {
            return new List<string>(password.OrderBy(x => Guid.NewGuid()));
        }
    }

    int counter = 0;
    private void btnGenerate_Click(object sender, RoutedEventArgs e)
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
            Shuffle shuffle = new Shuffle(password);
            password = shuffle.ShuffleList(password);

            Random random = new Random();
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(password.Count - 1);
                result.Add(password[randomIndex]);
            }

            txtResult.Text = string.Join("", result.ToArray());
            counter++;
            password.Clear();
            result.Clear();
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
            Shuffle shuffle = new Shuffle(password);
            password = shuffle.ShuffleList(password);

            Random random = new Random();
            for (int i = 0; i < passwordLength; i++)
            {
                int randomIndex = random.Next(password.Count - 1);
                result.Add(password[randomIndex]);
            }

            txtResult.Text = string.Join("", result.ToArray());
            counter++;
            password.Clear();
            result.Clear();
        }
    }
}

