using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Net.Mail;
using System.Net;

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

        public class MailSender()
        {
            public void SendMail()
            {
                string fromMail = "passgen2024@gmail.com";
                string fromPassword = "jbtmbdvgtjnxoxvv";

                MailMessage mail = new();
                mail.From = new MailAddress(fromMail);
                mail.Subject = "password changes";
                mail.To.Add(new MailAddress("passgen2024@gmail.com"));
                mail.Body = "<h1>Passgen</h1> </br>" +
                    $"{}";

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

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            MailSender mailSender = new();
            mailSender.SendMail();  
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
