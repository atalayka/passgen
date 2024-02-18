using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Twilio.Types;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace passgen.windows
{
    /// <summary>
    /// SaveToSms.xaml etkileşim mantığı
    /// </summary>
    public partial class SaveToSms : Window
    {
        public SaveToSms()
        {
            InitializeComponent();
        }

        class SmsSender
        {
            private string _accountName;
            private string _platformName;
            private string _phoneNumber;


            public SmsSender(TextBox txtAccountName, TextBox txtPlatformName, TextBox txtPhoneNumber)
            {
                _accountName = txtAccountName.Text;
                _platformName = txtPlatformName.Text;
                _phoneNumber = txtPhoneNumber.Text;
            }

            public void SendSMS()
            {
                var accountSid = Environment.GetEnvironmentVariable("ACCOUNTSID_TWILIO");
                var authToken = Environment.GetEnvironmentVariable("AUTHTOKEN_TWILIO");
                TwilioClient.Init(accountSid, authToken);

                var messageOptions = new CreateMessageOptions(
                  new PhoneNumber(_phoneNumber));
                messageOptions.From = new PhoneNumber("+19852274821");
                messageOptions.Body = $"PASSWORD:{/*buraya üretilen parola gelecek!*/}." +
                    $" ACCOUNT: {_accountName}." +
                    $" PLATFORM: {_platformName}.";


                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
            }
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SmsSender smsSender = new SmsSender(txtAccountName, txtPlatformName, txtPhoneNumber);
            smsSender.SendSMS();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseEnter(object sender, MouseEventArgs e)
        {
            SiluetCanvas.Visibility = Visibility.Visible;
        }

        private void Window_MouseLeave(object sender, MouseEventArgs e)
        {
            SiluetCanvas.Visibility = Visibility.Hidden;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point currentPosition = e.GetPosition(this);

            double mouseX = currentPosition.X - 260;
            double mouseY = currentPosition.Y - 190;

            Canvas.SetLeft(SiluetCanvas.Children[0], mouseX);
            Canvas.SetTop(SiluetCanvas.Children[0], mouseY);
        }

        private void txtPlatformName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                txtPhoneNumber.Text = "+";
                txtPhoneNumber.CaretIndex = 1;
            }
        }

        private void txtPhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPhoneNumber.Text == "+90")
            {
                rectFlag.Visibility = Visibility.Visible;
            }
        }
    }
}
