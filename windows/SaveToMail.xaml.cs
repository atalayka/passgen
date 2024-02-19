using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MailKit.Net.Smtp;
using MimeKit;

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
            public static void SendMail()
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Sender Name", "passgen2024@gmail.com"));
                email.To.Add(new MailboxAddress("Receiver Name", "kabakciatalay@gmail.com"));

                email.Subject = "Testing out email sending";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "<b>Hello all the way from the land of C#</b>"
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, false);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate("passgen2024@gmail.com", "kPTIt4ESMsvreKHp");

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
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
            MailSender.SendMail();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
