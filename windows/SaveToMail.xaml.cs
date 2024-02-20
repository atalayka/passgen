using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace passgen.windows
{
    /// <summary>
    /// SaveToMail.xaml etkileşim mantığı
    /// </summary>
    public partial class SaveToMail : Window
    {
        public SaveToMail()
        {
            InitializeComponent();
        }


        public class MailSender
        {
            private string AccountName { get; set; }
            private string PlatformName { get; set; }
            private string MailAddress { get; set; }
            private string Password { get; set; }

            public MailSender(TextBox txtAccountName, TextBox txtPlatformName, TextBox txtMailAddress)
            {
                MainWindow main = (MainWindow)Application.Current.MainWindow;

                AccountName = txtAccountName.Text;
                PlatformName = txtPlatformName.Text;
                MailAddress = txtMailAddress.Text;
                Password = main.ResultText;
            }

            public void SendMail()
            {
                string fromMail = "passgen2024@gmail.com";
                string fromPassword = "jbtmbdvgtjnxoxvv";

                MailMessage mail = new();
                mail.From = new MailAddress(fromMail);
                mail.Subject = "password changes";
                mail.To.Add(new MailAddress($"{MailAddress}"));
                mail.Body = "<h2>Passgen</h2> </br>" +
                    $"<h4> Account:   {AccountName} </h4> </br>" +
                    $"<h4> Platform:  {PlatformName} </h4> </br>" +
                    $"<h4> Password:  {Password} </h4> </br>" +
                    $"For your security, please avoid keeping passwords in email accounts that have low security.";

                mail.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(mail);
            }
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

        private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MailSender mailSender = new MailSender(txtAccountName, txtPlatformName, txtMailAddress);
            mailSender.SendMail();

            rectTickSubmit.Visibility = Visibility.Visible;
            await Task.Delay(400);
            rectTickSubmit.Visibility = Visibility.Hidden;
            await Task.Delay(150);
            this.Close();


        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
