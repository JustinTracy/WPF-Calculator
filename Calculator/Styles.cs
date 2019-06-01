using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Calculator
{
    public partial class Styles
    {
        private bool hovering;
        private Brush originalColor;
        private void Button_OnHover(object sender, MouseEventArgs e)
        {
            hovering = true;
            Button srcButton = e.Source as Button;
            originalColor = srcButton.Background;
            srcButton.Background = Brushes.Chartreuse;
        }

        private void Button_OnLeave(object sender, MouseEventArgs e)
        {
            hovering = false;
            Button srcButton = e.Source as Button;
            srcButton.Background = originalColor;
        }
    }
}