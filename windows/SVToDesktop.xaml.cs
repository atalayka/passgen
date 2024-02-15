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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            StartTextAnimation();
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
        private async void StartTextAnimation()
        {
            while (true)
            {
                for (int i = 0; i <= dynamicTextBlock.Text.Length; i++)
                {
                    dynamicTextBlock.Text = "gimme a account name".Substring(0, i);
                    await Task.Delay(200); // Değişiklik hızını ayarlayabilirsiniz
                }
                await Task.Delay(1000); // Metin sonuna ulaşıldıktan sonra bekleme süresi
            }

        }
    }
}
